using System.ComponentModel.DataAnnotations;

namespace KegelFreundeHorw.Models{
    public class MailViewModel{
        [StringLength(50, ErrorMessage = "Betreff darf maximal {1} Zeichen beinhalten.")]
        [Required(ErrorMessage = "Betreff muss angegeben werden.")]
        [Display(Name = "Betreff")]
        public string Subject { get; set; }

        [StringLength(50, ErrorMessage = "Name darf maximal {1} Zeichen beinhalten.")]
        [Required(ErrorMessage = "Name muss angegeben werden")]
        [RegularExpression("^([a-zA-Z]{2,}\\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?)", ErrorMessage = "Erlaubte Zeichen: (A-Z) (a-z) (' space -)")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email muss angegeben werden.")]
        [EmailAddress(ErrorMessage = "Falsches Format.")]
        [Display(Name = "E-Mail Adresse")]
        public string Sender { get; set; }
        
        [Required(ErrorMessage = "Nachricht muss angegeben werden.")]
        [StringLength(500, ErrorMessage = "Inhalt darf nicht mehr als {1} Zeichen beinhalten.")]
        [Display(Name = "Nachricht")]
        public string  Content { get; set; }


    }

}