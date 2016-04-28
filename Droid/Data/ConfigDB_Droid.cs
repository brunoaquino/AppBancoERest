using System;
using SQLite;
using System.IO;
using ControleDeTrafego.Droid;
using Xamarin.Forms;

[assembly :Dependency (typeof(ConfigDB_Droid))]

namespace ControleDeTrafego.Droid
{
	public class ConfigDB_Droid : IConfigDB
	{
		public ConfigDB_Droid (){}

		public SQLiteConnection GetConnection(){
			var fileName = "ControleTrafego.db3";
			var documents = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			//var path = Path.Combine(documents,"..", "Library", fileName); vai ser usado em IOS
			var path = Path.Combine(documents, fileName);

			return new SQLiteConnection (path);
		}
	}
}

