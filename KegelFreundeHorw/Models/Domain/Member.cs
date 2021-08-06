using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace KegelFreundeHorw.Models.Domain
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Prename { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public string Path { get; set; }

        public int? NoOfViews { get; set; }

        public string ImageName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Photo is required.")]
        public List<IFormFile> filePhoto { get; set; }
    }
}
