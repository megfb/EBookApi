﻿using EBookApi.Services.ServicesEntities.Publishers;
using EBookApi.Services.ServicesEntities.Publishers.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBookApi.API.Controllers
{
    public class PublishersController(IPublisherService publisherService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await publisherService.GetAllAsync());
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => CreateActionResult(await publisherService.GetByIdAsync(id));
        [HttpPost]
        public async Task<IActionResult> Create(CreatePublisherRequest createPublisherRequest) => CreateActionResult(await publisherService.CreateAsync(createPublisherRequest));
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePublisherRequest updatePublisherRequest) => CreateActionResult(await publisherService.UpdateAsync(id, updatePublisherRequest));
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => CreateActionResult(await publisherService.DeleteAsync(id));

    }
}
