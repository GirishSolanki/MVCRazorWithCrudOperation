using Microsoft.AspNetCore.Mvc.Filters;
public class GobalErrorHandlerAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        string errorLog = "ACMESOFT.Api : Message : "
                            + context.Exception.Message + " StackTrace: "
                            + context.Exception.StackTrace + " ControllerName : "
                            + context.RouteData.Values["controller"].ToString();

        ErrorLog.WriteLog(errorLog);
    }
}

