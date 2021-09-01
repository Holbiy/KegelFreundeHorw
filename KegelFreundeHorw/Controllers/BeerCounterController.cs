using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KegelFreundeHorw.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KegelFreundeHorw.Controllers
{
	public class BeerCounterController : Controller
	{
		private readonly ILogger<BeerCounterController> _logger;
		private IStatsRepository _statsRepository;

		public BeerCounterController(IStatsRepository statsRepository, ILogger<BeerCounterController> logger)
		{
			_statsRepository = statsRepository;
			_logger = logger;
		}

		public IActionResult Index()
		{
			var beersDrunk = _statsRepository.GetStatsByDescription("BeersDrunk");
			return View(beersDrunk);
		}

		public IActionResult Increment()
		{ 
			_statsRepository.IncrementByDescription("BeersDrunk");
			return RedirectToAction("Index");
		}
	}
}
