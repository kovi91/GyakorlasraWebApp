using GyakorlasraWebApp.Models;
using GyakorlasraWebApp.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GyakorlasraWebApp.Controllers
{
    public class HomeController : Controller
    {
        ICharacterRepository _repo;
        public HomeController(ICharacterRepository repo)
        {

            _repo = repo;
        }
        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        public IActionResult Export()
        {
            _repo.Export();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CharacterModel model)
        {
            //add parameter model object to the collection
            var ff = model.Picture;

            var filePath = Path.GetTempFileName();

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/HeroImages",
                        ff.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                //await ff.CopyToAsync(stream);
                ff.CopyToAsync(stream);
            }

            model.ImageUrl = ff.FileName;
            _repo.Add(model);
            return RedirectToAction("Index");
        }

    }
}
