using KegelFreundeHorw.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace KegelFreundeHorw.Controllers
{
	public class MembersController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public MembersController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

	}
}
