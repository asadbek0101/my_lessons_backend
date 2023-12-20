namespace Ststa.WebApi.Exceptions;

public class ApiResponse
{
    public string Code { get; set; }
    public string Message { get; set; }
    public object? Data { get; set; }

}

public class PaginatorApiResponse : ApiResponse
{
    public int TotalRowCount { get; set; }
    public int TotalPageCount { get; set; }
}

public enum ResponseType 
{ 
        Success, NotFound, Failure
}
