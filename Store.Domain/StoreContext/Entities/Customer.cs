using System;

namespace Store.Domain.StoreContext.Entities
{
    public class Customer
    {
        public string FirstName { get; private set; }
        public string Lastname { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
    }
}