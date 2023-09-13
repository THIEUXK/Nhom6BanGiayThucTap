namespace MCV.Models
{
    public class Address
    {
        public Guid id { get; set; }
        public Guid? AccountId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string SpecificAddress { get; set; }
        public string Ward { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string Note { get; set; }

        public virtual Account? Account { get; set; }
        
    }
}
