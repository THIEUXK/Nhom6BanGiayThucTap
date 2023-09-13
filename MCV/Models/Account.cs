namespace MCV.Models
{
    public class Account
    {
        public Guid id { get; set; }
        public Guid? RoleId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public bool Status { get; set; }




        public Role? Role { get; set; }
        public List<Address> Address { get; set; }
        public List<Order> Order { get; set; }

    }
}
