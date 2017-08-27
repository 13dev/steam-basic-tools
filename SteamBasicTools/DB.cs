using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SteamBasicTools
{
	class DB
	{

		private MySqlConnection connect;
		private bool bConnected = false;
		private string connectiondetails = Configuration.DB_CONNECTION;

		public bool Connect()
		{
			try
			{
				MySqlConnection connection = new MySqlConnection(connectiondetails);
				connection.Open();
				connect = connection;
				bConnected = true;
				return true;
			}
			catch (MySqlException ex)
			{
				string exception = "Exception : " + ex.Message.ToString() + "\n\rApplication will close now. \n\r";
				MessageBox.Show(exception, "Uncaught MYSQL Exception");

				Environment.Exit(1);
			}
			bConnected = false;
			return false;
		}

		public string getConnectionString()
		{
			return connectiondetails;
		}

		public MySqlConnection getMysqlConnection()
		{
			if(bConnected)
				return new MySqlConnection(getConnectionString());


			return null;
		}
	}
}
