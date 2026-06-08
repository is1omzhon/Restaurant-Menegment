using System;
using System.Collections.Generic;
using RestaurantReservationSystem.Models.Common;
using RestaurantReservationSystem.Models.Restaurant;  // ✅ Table uchun

namespace RestaurantReservationSystem.Models.Restaurant
{
    public class Restaurant : BaseEntity
    {
        // ========== ASOSIY MA'LUMOTLAR ==========
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string CuisineType { get; set; }

        // ========== REYTING ==========
        public double Rating { get; set; }
        public int TotalReviews { get; set; }

        // ========== EGASI ==========
        public Guid OwnerId { get; set; }

        // ========== HOLATI ==========
        public bool IsActive { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }

        // ========== NAVIGATION PROPERTY'LAR ==========
        // ✅ ENDI Table classi BOR!
        public List<Table> Tables { get; set; }           // object → Table
        public List<MenuItem> MenuItems { get; set; }
        public List<object> Reviews { get; set; }         // keyin o'zgartiramiz

        // ========== KONSTRUKTOR ==========
        public Restaurant()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
            Rating = 0;
            TotalReviews = 0;
            OpeningTime = DateTime.Today.AddHours(9);
            ClosingTime = DateTime.Today.AddHours(22);

            Tables = new List<Table>();           // ✅ Endi Table list!
            MenuItems = new List<MenuItem>();
            Reviews = new List<object>();
        }

        // ========== METHODLAR ==========

        public override string GetDisplayInfo()
        {
            return $"{Name} - {CuisineType} - ⭐ {Rating:F1} - {Address}";
        }

        public string GetFullInfo()
        {
            return $"""
                    🍽️ RESTAURANT INFO:
                    📛 Name: {Name}
                    📝 Description: {Description}
                    📍 Address: {Address}
                    📞 Phone: {Phone}
                    🍜 Cuisine: {CuisineType}
                    ⭐ Rating: {Rating:F1} ({TotalReviews} reviews)
                    🕐 Hours: {OpeningTime:HH:mm} - {ClosingTime:HH:mm}
                    📊 Status: {(IsActive ? "OPEN" : "CLOSED")}
                    🪑 Tables: {Tables.Count}
                    """;
        }

        public void UpdateRating(double newRating)
        {
            var total = Rating * TotalReviews + newRating;
            TotalReviews++;
            Rating = total / TotalReviews;
        }

        public bool IsOpen()
        {
            var now = DateTime.Now.TimeOfDay;
            var open = OpeningTime.TimeOfDay;
            var close = ClosingTime.TimeOfDay;
            return IsActive && now >= open && now <= close;
        }

        public void AddTable(Table table)
        {
            Tables.Add(table);
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            MenuItems.Add(menuItem);
        }

        public List<Table> GetAvailableTables()
        {
            return Tables.Where(t => t.IsAvailable).ToList();
        }

        public List<Table> GetAvailableTablesByCapacity(int partySize)
        {
            return Tables.Where(t => t.IsAvailable && t.Capacity >= partySize).ToList();
        }

        // Kategoriya bo'yicha taomlar
        public List<MenuItem> GetMenuItemsByCategory(Guid categoryId)
        {
            return MenuItems.Where(m => m.CategoryId == categoryId && m.IsAvailable).ToList();
        }

        // Barcha kategoriyalar (unique)
        public List<Category> GetCategories()
        {
            return MenuItems.Select(m => m.Category).Where(c => c != null).Distinct().ToList();
        }
    }
}