using EBookApi.Entities.Entities;
using EBookApi.Repositories.DbEntities.Publishers;
using EBookApi.Repositories.DbUnitOfWork;
using EBookApi.Services.Results;
using EBookApi.Services.ServicesEntities.Publishers.Requests;
using EBookApi.Services.ServicesEntities.Publishers.Responses;
using Microsoft.EntityFrameworkCore;

namespace EBookApi.Services.ServicesEntities.Publishers
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
            var publishers = await publisherRepository.GetAll().ToListAsync();
            var publishersAsDto = publishers.Select(p => new PublisherResponse(p.Id, p.Name));
            return ServiceResult<List<PublisherResponse>>.Success(publishersAsDto.ToList());
        }

        public async Task<ServiceResult<PublisherResponse>> GetByIdAsync(int id)
        {
            var publisher = await publisherRepository.GetByIdAsync(id);
            
            if(publisher is null)
            {
               ServiceResult.Fail("Publisher not found", System.Net.HttpStatusCode.NotFound);
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
