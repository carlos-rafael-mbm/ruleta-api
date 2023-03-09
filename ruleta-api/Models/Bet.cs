using System.ComponentModel.DataAnnotations;

namespace ruleta_api.Models
{
    public class Bet
    {
        [Key]
        [Required]
        [MaxLength(20)]
        public string User { get; set; }

        [Required]
        public float Amount { get; set; }
    }
}
