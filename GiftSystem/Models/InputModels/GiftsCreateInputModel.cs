using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GiftSystem.Models.InputModels
{
    public class GiftsCreateInputModel
    {
        public string Id { get; set; }

        public int Credits { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Comment")]
        public string Comment { get; set; }

        [Required]
        public GiftSystemUser Beneficiary { get; set; }

        [Required]
        public GiftSystemUser Sender { get; set; } // the currently logged credentials
    }
}
