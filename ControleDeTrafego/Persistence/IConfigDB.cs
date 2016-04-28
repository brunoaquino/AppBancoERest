using System;
using SQLite;

namespace ControleDeTrafego
{
	public interface IConfigDB
	{
		SQLiteConnection GetConnection ();
	}
}

