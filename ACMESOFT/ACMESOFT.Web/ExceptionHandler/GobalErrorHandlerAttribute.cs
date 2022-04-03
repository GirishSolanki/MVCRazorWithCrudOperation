using ACMESOFT.Common;
using ACMESOFT.Entity;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

public class GobalErrorHandlerAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        string errorLog = "ACMESOFT.Web : Message : "
                            + context.Exception.Message + " StackTrace: "
                            + context.Exception.StackTrace + " ControllerName : "
                            + context.RouteData.Values["controller"].ToString();

        ErrorLog.WriteLog(errorLog);
    }
}
