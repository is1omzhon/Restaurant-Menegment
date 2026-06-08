using System.Collections.Generic;
using RestaurantReservationSystem.Models.Common;

namespace RestaurantReservationSystem.Models.Users
{
    public class RestaurantOwner : User
    {
        public List<object> Restaurants { get; set; }
        public double AverageRating { get; set; }
        public DateTime JoinedDate { get; set; }
        
        public RestaurantOwner()
        {
            Restaurants = new List<object>();
            AverageRating = 0;
            JoinedDate = DateTime.UtcNow;
        }
        
        public override string GetRoleName()
        {
            return "Restaurant Owner";
        }
    }
}