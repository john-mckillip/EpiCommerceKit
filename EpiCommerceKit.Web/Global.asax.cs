using System;
using System.Web;

namespace Shoup
{
    public class EPiServerApplication : EPiServer.Global
    {               
        protected void Application_Start()
        {
           
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            HttpException httpException = exception as HttpException;
        }
    }
}