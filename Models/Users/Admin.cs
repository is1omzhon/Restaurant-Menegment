using System.Collections.Generic;
using RestaurantReservationSystem.Models.Common;

namespace RestaurantReservationSystem.Models.Users
{
    public class Admin : User
    {
        public List<string> Permissions { get; set; }
        public string AdminLevel { get; set; }
        
        public Admin()
        {
            Permissions = new List<string>
            {
                "manage_users",
                "manage_restaurants",
                "view_reports"
            };
            AdminLevel = "Moderator";
        }
        
        public override string GetRoleName()
        {
            return $"Admin ({AdminLevel})";
        }
    }
}