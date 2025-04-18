using EBookApi.Application.Contracts.Persistence;
using EBookApi.Application.Features.Publishers.Create;
using EBookApi.Application.Features.Publishers.Update;
using EBookApi.Domain.Entities;

namespace EBookApi.Application.Features.Publishers
{
    public class PublisherService(IPublisherRepository publisherRepository, IUnitOfWork unitOfWork) : IPublisherService
    {
        public async Task<ServiceResult<CreatePublisherResponse>> CreateAsync(CreatePublisherRequest createPublisherRequest)
        {
            var publisher = new Publisher()
            {
                Name = createPublisherRequest.Name
            };
            await publisherRepository.AddAsync(publisher);
            await unitOfWork.SaveChanges();
            return ServiceResult<CreatePublisherResponse>.Success(new CreatePublisherResponse(publisher.Id));
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var publisher = await publisherRepository.GetByIdAsync(id);
            if (publisher is null)
            {
                return ServiceResult.Fail("Publisher not found", System.Net.HttpStatusCode.NotFound);
            }
            publisherRepository.Delete(publisher);
            await unitOfWork.SaveChanges();
            return ServiceResult.Success(System.Net.HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<PublisherResponse>>> GetAllAsync()
        {
            var publishers = await publisherRepository.GetAllAsync();
            var publishersAsDto = publishers.Select(p => new PublisherResponse(p.Id, p.Name));
            return ServiceResult<List<PublisherResponse>>.Success(publishersAsDto.ToList());
        }

        public async Task<ServiceResult<PublisherResponse>> GetByIdAsync(int id)
        {
            var publisher = await publisherRepository.GetByIdAsync(id);

            if (publisher is null)
            {
               return ServiceResult<PublisherResponse>.Fail("Publisher not found", System.Net.HttpStatusCode.NotFound);
            }
            var publisherAsDto = new PublisherResponse(publisher.Id, publisher.Name);
            return ServiceResult<PublisherResponse>.Success(publisherAsDto);

        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdatePublisherRequest updatePublisherRequest)
        {
            var publisher = await publisherRepository.GetByIdAsync(id);
            if (publisher is null)
            {
                return ServiceResult.Fail("Publisher not found", System.Net.HttpStatusCode.NotFound);
            }
            publisher.Name = updatePublisherRequest.Name;
            publisherRepository.Update(publisher);
            await unitOfWork.SaveChanges();
            return ServiceResult.Success(System.Net.HttpStatusCode.NoContent);
        }
    }
}
