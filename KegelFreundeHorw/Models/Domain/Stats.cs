using System.ComponentModel.DataAnnotations;

namespace KegelFreundeHorw.Models.Domain
{
	public class Stats
	{
		[Key]
		public int Id { get; set; }

		public string Description { get; set; }

		public int Value { get; set; }
	}
}
