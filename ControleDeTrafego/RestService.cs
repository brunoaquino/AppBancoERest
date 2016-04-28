using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Collections.Generic;
using Plugin.Connectivity;
using System.Reflection;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace ControleDeTrafego
{
	public class RestService
	{

		public async Task<T> GetResponse<T> (String url, Object obj) where T : class
		{

			if (!CrossConnectivity.Current.IsConnected) {
				throw new System.Exception ("Sem conexão com internet. Por favor tente novamente mais tarde.");
			}

			HttpClient client = new HttpClient ();
			client.DefaultRequestHeaders.Accept.Add (new MediaTypeWithQualityHeaderValue ("application/json"));

			client.BaseAddress = new Uri ("http://192.168.1.132:8080/gspm/rest/");

			HttpContent content = new StringContent (JsonConvert.SerializeObject (obj));
			content.Headers.ContentType = new MediaTypeHeaderValue ("application/json");

			var postData = new List<KeyValuePair<string, string>> ();

			Type myTypeObj = obj.GetType ();
			var assembly = myTypeObj.GetTypeInfo ();


			IEnumerable<PropertyInfo> lista = assembly.DeclaredProperties;
			foreach (var propertyInfo in lista) {
				if (propertyInfo.GetValue (obj) != null) {
					postData.Add (new KeyValuePair<string, string> (propertyInfo.Name.ToLower (), propertyInfo.GetValue (obj).ToString ()));
				} else {
					postData.Add (new KeyValuePair<string, string> (propertyInfo.Name.ToLower (), null));
				}
			}
				
			var formContent = new FormUrlEncodedContent (postData);

			var response = await client.PostAsync (url, formContent);

			var jsonResult = response.Content.ReadAsStringAsync ().Result;

			if (typeof(T) == typeof(String)) {
				return null;
			}

			if (!response.IsSuccessStatusCode) {
				JObject json = JObject.Parse (jsonResult);
				String id = json.GetValue ("erro").First.SelectToken ("id").ToString ();
				String tipo = json.GetValue ("erro").First.SelectToken ("tipo").ToString ();
				String texto = json.GetValue ("erro").First.SelectToken ("texto").ToString ();
				throw new System.Exception (texto);
			} else {
				var objRetorno = JsonConvert.DeserializeObject<T> (jsonResult);
				return objRetorno;
			}

		}

		public RestService ()
		{
		}
	}
}

