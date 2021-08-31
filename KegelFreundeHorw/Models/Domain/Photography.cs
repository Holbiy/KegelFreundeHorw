using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace KegelFreundeHorw.Models.Domain
{
    public class PhotoGraphy
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Path { get; set; }
        public int? NoOfViews { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Photo is required.")]
        public List<IFormFile> filePhoto { get; set; }
    }
}