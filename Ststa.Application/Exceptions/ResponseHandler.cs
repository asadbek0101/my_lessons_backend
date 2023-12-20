namespace Ststa.WebApi.Exceptions;

public class ResponseHandler
{
    public static ApiResponse GetExceptionResponse(Exception ex)
    {
        ApiResponse response = new ApiResponse();
        response.Code = "2";
        response.Message = ex.Message;
        return response;    
    }

    public static PaginatorApiResponse GetExceptionResponseWithPages(Exception ex)
    {
        PaginatorApiResponse response = new PaginatorApiResponse();
        response.Code = "2";
        response.Message = ex.Message;
        response.TotalRowCount = 0;
        response.TotalPageCount = 0;
        return response;
    }

    public static ApiResponse GetAppResponse(ResponseType type, object? contract) 
    {
        ApiResponse response;
        response= new ApiResponse { Data = contract };
        switch (type)
        {
            case ResponseType.Success:
                response.Code = "1";
                response.Message = "Success";
                break;
            case ResponseType.NotFound:
                response.Code = "0";
                response.Message = "No Record Aviable";
                break;
        }
        return response;
    }

    public static PaginatorApiResponse GetAppResponseWithPages(ResponseType type, int TotalPageCount, int TotalRowCount, object? contract)
    {
        PaginatorApiResponse response;
        response = new PaginatorApiResponse { Data = contract, TotalPageCount = TotalPageCount, TotalRowCount = TotalRowCount };
        switch (type)
        {
            case ResponseType.Success:
                response.Code = "1";
                response.Message = "Success";
                break;
            case ResponseType.NotFound:
                response.Code = "0";
                response.Message = "No Record Aviable";
                break;
        }
        return response;
    }

    internal static object? GetExceptionResponse(object ex)
    {
        throw new NotImplementedException();
    }
}
