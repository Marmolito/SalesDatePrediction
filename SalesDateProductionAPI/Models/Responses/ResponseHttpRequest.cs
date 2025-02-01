namespace SalesDateProductionAPI.Models.Responses
{
    public class ResponseHttpRequest<T>
    {
        public bool isError { get; set; }
        public T data { get; set; }
        public string messagge {  get; set; }
    }
}
