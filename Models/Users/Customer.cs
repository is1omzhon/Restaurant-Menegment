using System.Collections.Generic;
using Models.Base;
using Models.Reservation;  // Reservation uchun
using Models.Order;       // Order uchun
using Models.Review;      // Review uchun
using Models.Users;

namespace RestaurantReservationSystem.Models.Users
{
    public class Customer : User
    {
        // ✅ Property (method emas!)
        public List<Reservation> Reservations { get; set; }
        public List<Order> Orders { get; set; }
        public List<Review> Reviews { get; set; }
        public double TotalSpent { get; set; }
        
        // Constructor
        public Customer()
        {
            Reservations = new List<Reservation>();
            Orders = new List<Order>();
            Reviews = new List<Review>();
            TotalSpent = 0;
        }
        
        // ✅ Abstract metodni to'ldirish
        public override string GetRoleName()
        {
            return "Customer";
        }
        
        // Qo'shimcha metod (property emas, harakat!)
        public void AddOrder(Order order)
        {
            Orders.Add(order);
            TotalSpent += order.TotalAmount;
        }
        
        public void AddReservation(Reservation reservation)
        {
            Reservations.Add(reservation);
        }
    }

    public class Order
    {
    }
}