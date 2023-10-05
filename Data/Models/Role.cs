namespace MCV.Models
{
    public class Role
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public bool Status { get; set; }

        public virtual List<Account>? Accounts { get; set; }
    }
}
