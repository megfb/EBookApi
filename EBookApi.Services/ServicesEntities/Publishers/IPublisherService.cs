using EBookApi.Services.Results;
using EBookApi.Services.ServicesEntities.Publishers.Requests;
using EBookApi.Services.ServicesEntities.Publishers.Responses;

namespace EBookApi.Services.ServicesEntities.Publishers
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
