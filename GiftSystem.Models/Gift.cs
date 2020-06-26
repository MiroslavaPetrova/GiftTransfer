namespace GiftSystem.Models
{
    public class Gift
    {
        public string Id { get; set; }

        public int Credits { get; set; }

        public string Comment { get; set; }

        public string BeneficiaryId { get; set; }

        public GiftSystemUser Beneficiary { get; set; }

        public string SenderId { get; set; }

        public GiftSystemUser Sender { get; set; } // the currently logged credentials
    }
}
