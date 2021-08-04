

using System.ComponentModel.DataAnnotations;

namespace KegelFreundeHorw.Models
{
    public class ImageEditorViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Caption { get; set; }

        [Required]
        public HttpPostedFileBase FileImage { get; set; }

        internal static Gallery getEnityModel(ImageEditorViewModel model)
        {
            return new Gallery
            {
                IsActive = true,
                Title = model.Caption,
                OrderNo = 0,
            };
        }
    }
}
