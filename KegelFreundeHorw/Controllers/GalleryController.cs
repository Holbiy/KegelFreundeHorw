using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KegelFreundeHorw.DataAccess;
using KegelFreundeHorw.Models.Domain;
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
            viewModel.PhotoGraphyList = _galleryRepository.GetAllPhotographies().ToList();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddPhotos(PhotoGraphy model)
        {
            if (!ModelState.IsValid)
                return Redirect("Index");
            var Files = model.filePhoto;

            if (Files.Count > 0)
            {
                foreach (var item in Files)
                {
                    var photography = new PhotoGraphy();
                    var guid = Guid.NewGuid().ToString();
                    var filePath = "wwwroot/img/photography/" + guid + item.FileName;
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

        public IActionResult Add()
        {
	        return View();
        }

        public IActionResult DeletePhoto(int id)
        {
            _galleryRepository.DeletePhotography(id);
            return RedirectToAction("index");

        }
    }

}
