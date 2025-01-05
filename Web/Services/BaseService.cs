using Newtonsoft.Json;
using System.Net;
using System.Text;
using Web.Interfaces.Services;
using Web.Models;
using Web.Utilities.Enums;

namespace Web.Services;

public class BaseService : IBaseService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BaseService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ResponseDto> SendAsync(RequestDto request)
    {
        HttpClient client = _httpClientFactory.CreateClient("API");

        HttpRequestMessage requestMessage = new HttpRequestMessage();
        requestMessage.Headers.Add("Accept", "application/json");
        requestMessage.RequestUri = new Uri(request.Url);

        if (request.Data != null)
        {
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(request.Data), Encoding.UTF8, "application/json");
        }

        switch (request.ApiType)
        {
            case ApiType.POST:
                requestMessage.Method = HttpMethod.Post;
                break;
            case ApiType.PUT:
                requestMessage.Method = HttpMethod.Put;
                break;
            case ApiType.DELETE:
                requestMessage.Method = HttpMethod.Delete;
                break;
            default:
                requestMessage.Method = HttpMethod.Get;
                break;
        }

        try
        {
            HttpResponseMessage? response = await client.SendAsync(requestMessage);
            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new ResponseDto() { IsSuccess = false, Message = "Not Found" };
                case HttpStatusCode.Unauthorized:
                    return new ResponseDto() { IsSuccess = false, Message = "UnAuthorized" };
                case HttpStatusCode.InternalServerError:
                    return new ResponseDto() { IsSuccess = false, Message = "Internal Server Error" };
                default:
                    var apiContent = await response.Content.ReadAsStringAsync();
                    var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                    return apiResponseDto;
            }
        }
        catch (Exception ex) { 
            return new ResponseDto() { IsSuccess = false, Message= ex.Message };
        }
    }
}
