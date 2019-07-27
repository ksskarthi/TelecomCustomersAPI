using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace TelecomDataServices
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);
		}
		protected void Application_Error(object sender, EventArgs e)
		{
			Exception unhandledException = Server.GetLastError();
			//just to track the applicatin exception
		}
	}
}
