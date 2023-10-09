namespace Domain.DTOs.Wrappers;

public class Response<T>
{
    public T? Data { get; set; }
    public string? Messsage { get; set; }
    public Response(T data, string message)
    {
        Data = data;
        Messsage = message;
    }
    public Response(T data)
    {
        Data = data;
    }
    public Response(string message)
    {
        Messsage = message;
    }
}
