using Web.Models;

namespace Web.Interfaces.Services;

public interface IBaseService
{
    Task<ResponseDto> SendAsync(RequestDto request);
}
