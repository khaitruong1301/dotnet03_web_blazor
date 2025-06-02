public class ResponseApiType<T>
{
    public int statusCode { get; set; }
    public string message { get; set; }
    public T? content { get; set; }
    public DateTime dateTime { get; set; }
}