using System;
using SQLite;
using Xamarin.Forms;

namespace ControleDeTrafego
{
	public class DbHelper
	{
		public DbHelper ()
		{
		}

		public static SQLiteConnection Conexao;

		public static void carregaBanco ()
		{
			Conexao = DependencyService.Get<IConfigDB> ().GetConnection ();

			carregaTabelas ();
		}

		private static void carregaTabelas ()
		{
			Conexao.CreateTable<Usuario> ();
		}
			
	}
}

