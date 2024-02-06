namespace Common.BaseApi.Exceptions
{
    public class HttpResponseException : Exception
    {
        public int Status { get; set; }
        public object? Details { get; set; }
    }
}
