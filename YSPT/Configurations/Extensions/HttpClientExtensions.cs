using Microsoft.AspNetCore.Components.Forms;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using YSPT.Configurations.Common;

namespace YSPT.Configurations.Extensions;

public static class HttpClientExtensions
{
    /// <summary>
    /// Check if json is Null or not if null it returns Invalid Response with No Content
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="content"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<ApiResponse<T>> GetApiResponseFromJsonAsync<T>(this HttpResponseMessage message, CancellationToken cancellationToken = default)
    {
        try
        {
            if (message is null)
            {
                return ApiResponse.InvalidResponse<T>(HttpStatusCode.NoContent);
            }
            if (message.StatusCode == HttpStatusCode.Unauthorized)
            {
                return ApiResponse.UnAuthorized<T>();
            }

#if DEBUG
            var x = message.Content.ReadAsStringAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
#endif

            var result = await message.Content.ReadFromJsonAsync<ApiResponse<T>>(cancellationToken: cancellationToken).ConfigureAwait(false);
            if (result is null)
            {
                return ApiResponse.InvalidResponse<T>(HttpStatusCode.NoContent);
            }

            return result;
        }
        catch (Exception ex)
        {
            return ApiResponse.UnexpectedResponse<T>(message: ex.Message);
        }
    }

    /// <summary>
    /// Check if json is Null or not if null it returns Invalid Response with No Content
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<EmptyApiResponse> GetEmptyApiResponseFromJsonAsync(this HttpResponseMessage message, CancellationToken cancellationToken = default)
    {
        try
        {
            if (message is null)
            {
                return EmptyApiResponse.InvalidResponse(HttpStatusCode.NoContent);
            }
            if (message.StatusCode == HttpStatusCode.Unauthorized)
            {
                return EmptyApiResponse.UnAuthorized();
            }

#if DEBUG
            var x = message.Content.ReadAsStringAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
#endif

            var result = await message.Content.ReadFromJsonAsync<EmptyApiResponse>(cancellationToken: cancellationToken).ConfigureAwait(false);
            if (result is null)
            {
                return EmptyApiResponse.InvalidResponse(HttpStatusCode.NoContent);
            }

            return result;
        }
        catch (Exception ex)
        {
            return EmptyApiResponse.UnexpectedResponse(message: ex.Message);
        }
    }

    public static void GetMultipartFormDataContent<T>(this MultipartFormDataContent formData, T model)
    {
        var properties = typeof(T).GetProperties();

        foreach (var property in properties)
        {
            var value = property.GetValue(model);

            if (value is IBrowserFile browserFile)
            {
                var fileStream = browserFile.OpenReadStream(maxAllowedSize: 10_000_000);
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(browserFile.ContentType);
                formData.Add(fileContent, property.Name, browserFile.Name);
            }
            else if (value is not null)
            {
                formData.Add(new StringContent(value.ToString() ?? string.Empty), property.Name);
            }
        }
    }
}
