using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamBasicTools
{
	class Configuration
	{
		public const string WEB_API_KEY = "WEB_KEY_API_STEAM";
		public const string CHECK_UPDATES_URL = "YOUR_UPDATE_XML_LINK";
		public const string DB_TABLE = "TABLE_NAME";
		public const string DB_CONNECTION =
			"Server=localhost;" +
			"Database=database_name;" +
			"Uid=username;" +
			"Pwd=password_username";
		//Remember put wildcard '%' to remote mysql
	}
}
