using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace DPY2.WebAdmin.Models.AuthFilters
{
    public class Watchdog : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization.Parameter != null)
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:26282/token/authenticate");
                request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + actionContext.Request.Headers.Authorization.Parameter);
                request.Method = "GET";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                
                if (response.StatusCode == HttpStatusCode.OK)
                    return true;
            }

            return base.IsAuthorized(actionContext);
        }
    }
}