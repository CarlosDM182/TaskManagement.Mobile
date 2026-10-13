using System.Net;

namespace TaskManagement.Mobile.Models;

public class ApiResponse<T>
{
    public T? Data { get; init; }

    public HttpStatusCode StatusCode { get; init; }

    public bool IsSuccess =>
        (int)StatusCode >= 200 && (int)StatusCode < 300;

    public string? ErrorMessage { get; init; }
}