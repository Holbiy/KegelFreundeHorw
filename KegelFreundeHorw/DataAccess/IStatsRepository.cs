using KegelFreundeHorw.Models.Domain;

namespace KegelFreundeHorw.DataAccess
{
    public interface IStatsRepository
    {
	    Stats GetStatsByDescription(string description);
		void IncrementByDescription(string description);
	}
}
