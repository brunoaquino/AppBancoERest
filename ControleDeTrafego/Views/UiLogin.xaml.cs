using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SQLite;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ControleDeTrafego
{
	public partial class UiLogin : ContentPage
	{
		public UiLogin ()
		{
			InitializeComponent ();

			RestService apiCall = new RestService ();

			Usuario usuario = new Usuario ();
			usuario.login = "admin";
			usuario.senha = "1";

			apiCall.GetResponse<Usuario> ("autenticacao/autentica", usuario).ContinueWith (t => {

				if (t.IsFaulted) {
					Debug.WriteLine (t.Exception.InnerExceptions [0].Message);
					Device.BeginInvokeOnMainThread (() => {
						DisplayAlert ("Atenção", t.Exception.InnerExceptions [0].Message, "Ok");
					});
				} else if (t.IsCanceled) {
					Debug.WriteLine ("requisição cancelada.");

					Device.BeginInvokeOnMainThread (() => {
						DisplayAlert ("Cancelada", "Requisição Cancelada :O", "Ok");	
					});
				} else {
					Usuario teste = t.Result;
					Device.BeginInvokeOnMainThread (() => {
						
						DisplayAlert ("Carregado", usuario.login, "OK");
					});
					
				}
			});

//			UsuarioDao dao = new UsuarioDao (DbHelper.Conexao);
//
//			Usuario usuario = new Usuario ();
//			usuario.Login = "bruno";
//			usuario.Matricula = "mex6787";
//			usuario.Senha = "123546";
//
//			dao.Insert (usuario);
//			dao.SelectAll<Usuario> ();
		}
	}
}

