namespace MCV.Models
{
    public class Sole
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public bool Status { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
