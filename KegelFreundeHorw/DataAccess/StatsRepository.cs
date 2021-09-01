using System.Linq;
using KegelFreundeHorw.Models.Domain;

namespace KegelFreundeHorw.DataAccess
{
	public class StatsRepository : IStatsRepository
	{
		private readonly ApplicationDbContext _context;
		public StatsRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public Stats GetStatsByDescription(string description)
		{
			return _context.Stats.First(x => x.Description == description);
		}

		public void IncrementByDescription(string description)
		{
			var stats = _context.Stats.First(x => x.Description == description);
			stats.Value++;
			_context.SaveChanges();
		}
	}

}




