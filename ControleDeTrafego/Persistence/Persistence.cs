using System;
using SQLite;
using System.Linq;
using Xamarin.Forms;

namespace ControleDeTrafego
{
	public class Persistence<T> : IDisposable
	{
		protected SQLiteConnection Conexao;

		public Persistence (SQLiteConnection con)
		{
			Conexao = con;
		}
			
		public void OpenTransaction(){
			Conexao.BeginTransaction ();
		}

		public void CloseTransaction(){
			Conexao.Close ();
		}

		public void Commit(){
			Conexao.Commit ();
		}

		public T Insert<T>(T model)
		{
			int iRes = Conexao.Insert(model);
			return model;
		}

		public T Update<T>(T model)
		{
			int iRes = Conexao.Update(model);
			return model;
		}

		public bool Delete<T>(T model)
		{
			int iRes = Conexao.Delete(model);
			return iRes.Equals(1);
		}

		public T Select<T>(int pk) where T : new()
		{
			var map = Conexao.GetMapping(typeof(T));
			return Conexao.Query<T>(map.GetByPrimaryKeySql, pk).First();
		}

		public T[] SelectAll<T>() where T : new()
		{
			return new TableQuery<T>(Conexao).ToArray();
		}

		public void Dispose ()
		{
			Conexao.Dispose ();
		}
			
	}
}

