using EBookApi.Entities.Entities;
using EBookApi.Repositories.GenericRepository;
using Microsoft.AspNetCore.Mvc;

namespace EBookApi.API.Controllers
{
    public class TestController : Controller
    {
        private readonly IGenericRepository<Author> _authorRepository;
        public TestController(IGenericRepository<Author> genericRepository)
        {
            _authorRepository = genericRepository;
        }
        public IActionResult Index()
        {
            Author author = new Author()
            {
                Biography = "Biography",
                Name = "FirstName",
            };
            _authorRepository.AddAsync(author);

            return View();
        }
    }
}
