namespace MessageAPI.Models
{
    public class Poruka
    {
        public int Id { get; set; }
        public string? Sadrzaj { get; set; }
        public Email? EmailOd { get; set; }
        public int? EmailOdId { get; set; }
        public Email? EmailPrema { get; set; }
        public int? EmailPremaId { get; set; }
    }
}
