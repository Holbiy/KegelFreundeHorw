using KegelFreundeHorw.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace KegelFreundeHorw.Controllers
{
	public class MemberShipController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public MemberShipController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

	}
}
