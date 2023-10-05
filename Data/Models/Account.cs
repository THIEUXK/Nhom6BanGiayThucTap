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




        public virtual Role? Role { get; set; }
        public virtual IQueryable<Address>? Address { get; set; }
        public virtual IQueryable<Order>? Order { get; set; }
        public virtual IQueryable<Cart>? Carts { get; set; }

    }
}
