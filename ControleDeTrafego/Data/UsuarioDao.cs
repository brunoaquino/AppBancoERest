using System;
using SQLite;
using Xamarin.Forms;

namespace ControleDeTrafego
{
	public class UsuarioDao : Persistence<Usuario>
	{
		public UsuarioDao(SQLiteConnection conexao) : base(conexao) { } 
	}
}

