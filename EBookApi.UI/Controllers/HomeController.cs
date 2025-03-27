using System.Diagnostics;
using EBookApi.Entities.Entities;
using EBookApi.Repositories.GenericRepository;
using EBookApi.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EBookApi.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericRepository<Author> _authorRepository;
        public HomeController(IGenericRepository<Author> genericRepository)
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
