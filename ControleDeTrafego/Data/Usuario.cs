using System;
using SQLite;

namespace ControleDeTrafego
{
	public class Usuario
	{

		[AutoIncrement, PrimaryKey]
		public String id {
			get;
			set;
		}

		public string matricula {
			get;
			set;
		}

		public string login {
			get;
			set;
		}

		public string senha {
			get;
			set;
		}

		public Usuario ()
		{
		}
	}
}

