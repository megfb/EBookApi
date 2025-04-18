using EBookApi.Application.Features.Publishers.Create;
using EBookApi.Application.Features.Publishers.Update;

namespace EBookApi.Application.Features.Publishers
{
    public interface IPublisherService
    {
        Task<ServiceResult<List<PublisherResponse>>> GetAllAsync();
        Task<ServiceResult<CreatePublisherResponse>> CreateAsync(CreatePublisherRequest createPublisherRequest);
        Task<ServiceResult<PublisherResponse>> GetByIdAsync(int id);
        Task<ServiceResult> UpdateAsync(int id, UpdatePublisherRequest updatePublisherRequest);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
