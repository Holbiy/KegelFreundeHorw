using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KegelFreundeHorw.DataAccess;
using KegelFreundeHorw.Models.VieModel;

namespace KegelFreundeHorw.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IGalleryRepository _galleryRepository;

        public GalleryController(IGalleryRepository galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }
        public IActionResult Index()
        {
            var viewModel = new GalleryViewModel();
            viewModel.photoGraphyList = _galleryRepository.GetAllPhotographies().ToList();
            viewModel.photoGraphy = new Photography();
            return View(viewModel);

            return View();
        }
        [HttpPost]
        public IActionResult AddPhotos(GalleryViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);
            var Files = model.photoGraphy.filePhoto;

            if (Files.Count > 0)
            {
                foreach (var item in Files)
                {
                    var photography = new Photography();
                    var guid = Guid.NewGuid().ToString();
                    var filePath = "wwwroot/photography/" + guid + item.FileName;
                    var fileName = guid + item.FileName;
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        item.CopyTo(stream);
                        photography.Name = fileName;
                        photography.Path = filePath;
                        photography.Title = item.FileName;
                        photography.NoOfViews = 1;
                        _galleryRepository.AddPhotography(photography);
                    }
                }
                return RedirectToAction("Index");
            }


            return RedirectToAction("Index");
        }

        public IActionResult DeletePhoto(int id)
        {
            _galleryRepository.DeletePhotography(id);
            return RedirectToAction("index");

        }
    }

}
