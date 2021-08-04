using KegelFreundeHorw.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KegelFreundeHorw.Controllers
{
    public class GalleryAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ImageEditorViewModel vm = new ImageEditorViewModel();
            return PartialView(vm);
        }

        [HttpPost]
        public ActionResult Create(ImageEditorViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ImageGalleryEntities db = new ImageGalleryEntities();
                    var fileModel = WebFileViewModel.getEntityModel(model.FileImage);
                    db.WebFiles.Add(fileModel);
                    db.SaveChanges();

                    var entity = ImageEditorViewModel.getEnityModel(model);
                    entity.WebImageId = fileModel.Id;
                    entity.OrderNo = db.Galleries.Count() > 0 ? db.Galleries.Max(x => x.OrderNo) + 1 : 1;
                    db.Galleries.Add(entity);
                    db.SaveChanges();

                    return Json(new { success = true, Caption = model.Caption });
                }

                return Json(new { success = false, ValidationMessage = "Please check validation messages" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, ExceptionMessage = "Some error here" });
            }
        }

        public ActionResult _List()
        {
            ImageGalleryEntities db = new ImageGalleryEntities();
            var list = db.Galleries.OrderBy(x => x.OrderNo)
                                 .Select(x => new ImageList
                                 {
                                     Id = x.Id,
                                     IsActive = x.IsActive,
                                     OrderNo = x.OrderNo,
                                     WebImageId = x.WebImageId,
                                     Title = x.Title
                                 }).ToList();

            return PartialView(list);
        }
    }
}

