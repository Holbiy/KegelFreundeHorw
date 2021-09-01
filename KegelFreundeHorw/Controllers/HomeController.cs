using KegelFreundeHorw.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using KegelFreundeHorw.DataAccess;
using KegelFreundeHorw.Models.Domain;

namespace KegelFreundeHorw.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private IStatsRepository _statsRepository;

		public HomeController(ILogger<HomeController> logger, IStatsRepository statsRepository)
		{
			_logger = logger;
			_statsRepository = statsRepository;
		}

		public IActionResult Index()
		{
			Stats beersDrunk = _statsRepository.GetStatsByDescription("BeersDrunk");
			return View(beersDrunk);
		}

		public IActionResult Imprint()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
