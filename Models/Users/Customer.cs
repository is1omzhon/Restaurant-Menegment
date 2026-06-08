using System.Collections.Generic;
using RestaurantReservationSystem.Models.Common;

namespace RestaurantReservationSystem.Models.Users
{
    public class Customer : User
    {
        public List<object> Reservations { get; set; }
        public List<object> Orders { get; set; }
        public List<object> Reviews { get; set; }
        public double TotalSpent { get; set; }
        
        public Customer()
        {
            Reservations = new List<object>();
            Orders = new List<object>();
            Reviews = new List<object>();
            TotalSpent = 0;
        }
        
        public override string GetRoleName()
        {
            return "Customer";
        }
    }
}