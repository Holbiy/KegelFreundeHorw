using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using KegelFreundeHorw.DataAccess;
using KegelFreundeHorw.Models.Domain;
using KegelFreundeHorw.Models.VieModel;

namespace KegelFreundeHorw.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberRepository _memberRepository;

        public MembersController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public IActionResult Index()
        {
            var viewModel = new MemberViewModel();
            viewModel.MemberList = _memberRepository.GetAllMembers().ToList();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddMembers(Member model)
        {
            if (!ModelState.IsValid)
                return Redirect("Index");
            var Files = model.filePhoto;

            if (Files.Count > 0)
            {
                foreach (var item in Files)
                {
                    var member = model;
                    var guid = Guid.NewGuid().ToString();
                    var filePath = "wwwroot/img/members/" + guid + item.FileName;
                    var fileName = guid + item.FileName;
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        item.CopyTo(stream);
                        member.ImageName = fileName;
                        member.Path = filePath;
                        member.NoOfViews = 1;
                        _memberRepository.AddMember(member);
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

        public IActionResult DeleteMember(int id)
        {
            _memberRepository.DeleteMember(id);
            return RedirectToAction("index");

        }
    }

}
