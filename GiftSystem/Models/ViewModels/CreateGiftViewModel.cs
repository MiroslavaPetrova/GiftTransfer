namespace GiftSystem.Models.ViewModels
{
    public class CreateGiftViewModel
    {
        public string Id { get; set; }

        public int Credits { get; set; }

        public string Comment { get; set; }

        public GiftSystemUser Beneficiary { get; set; }

        public GiftSystemUser Sender { get; set; }
    }
}
