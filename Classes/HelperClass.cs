using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TelecomCustomersAPI.DataServices;

namespace TelecomCustomersAPI.Classes
{
	public static class HelperClass
	{
		public static string GetConfigurationStringData(string configKey)
		{
			return ConfigurationManager.AppSettings[configKey];
		}

		public static SqlCredentials GetSQLCredentials()
		{
			SqlCredentials credentials = new SqlCredentials();
			credentials.DataSource = ConfigurationManager.AppSettings["DataSource"];
			credentials.UserId = ConfigurationManager.AppSettings["UserId"];
			credentials.Password = ConfigurationManager.AppSettings["Password"];
			credentials.InitialCatalog = ConfigurationManager.AppSettings["InitialCatalog"];
			return credentials;
		}

	}
}