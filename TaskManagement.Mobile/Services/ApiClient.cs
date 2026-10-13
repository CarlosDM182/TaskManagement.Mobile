using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using TaskManagement.Mobile.Models;
using TaskManagement.Mobile.Services.Interfaces;
#if ANDROID
using Plugin.Firebase.Crashlytics;
#endif

namespace TaskManagement.Mobile.Services;

public class ApiClient : IApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ApiResponse<T>> GetAsync<T>(string endpoint)
    {
        try
        {
            var response = await _httpClient.GetAsync(endpoint);

            return await MapResponseAsync<T>(response);
        }
        catch(Exception ex)
        {
#if ANDROID
            
            CrossFirebaseCrashlytics.Current.RecordException(ex);

#endif
            throw;
        }
        
    }


    public async Task<ApiResponse<TResponse>> PostAsync<TRequest, TResponse>(
        string endpoint,
        TRequest request)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync(endpoint, request);

            return await MapResponseAsync<TResponse>(response);
        }
        catch(Exception ex)
        {
#if ANDROID
            CrossFirebaseCrashlytics.Current.RecordException(ex);
#endif
            throw;
        }
       
    }

    public async Task<ApiResponse<TResponse>> PutAsync<TRequest, TResponse>(
        string endpoint,
        TRequest request)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync(endpoint, request);
            return await MapResponseAsync<TResponse>(response);

        }
        catch (Exception ex)
        {
#if ANDROID
            CrossFirebaseCrashlytics.Current.RecordException(ex);
#endif
            throw;
        }
            
    }

    public async Task<ApiResponse<bool>> DeleteAsync(string endpoint)
    {
        try
        {
            var response = await _httpClient.DeleteAsync(endpoint);

            return await MapResponseAsync<bool>(response);
        }
        catch(Exception ex)
        {
#if ANDROID
            CrossFirebaseCrashlytics.Current.RecordException(ex);
#endif
            throw;
        }
        
    }

    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        Converters =
        {
            new JsonStringEnumConverter()
        }
    };

    private static async Task<ApiResponse<T>> MapResponseAsync<T>(
        HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();

        T? data = default;
        string? errorMessage = null;

        if (response.IsSuccessStatusCode)
        {
            if (!string.IsNullOrWhiteSpace(content))
            {
                data = JsonSerializer.Deserialize<T>(content, JsonOptions);
            }
        }
        else
        {
            errorMessage = content;
        }

        return new ApiResponse<T>
        {
            Data = data,
            StatusCode = response.StatusCode,
            ErrorMessage = errorMessage
        };
    }
}