namespace ACMESOFT.Common
{
    public class GenericResponse<T> where T : class
    {
        public string Message { get; protected set; }
        public bool Success { get; protected set; }
        public string StatusCode { get; protected set; }
        public T Result { get; protected set; }

        public GenericResponse(string message, bool success, string statusCode, T result)
        {
            this.Message = message;
            this.Success = success;
            this.StatusCode = statusCode;
            this.Result = result;
        }
    }
}