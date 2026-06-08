using System;
using RestaurantReservationSystem.Models.Common;

namespace RestaurantReservationSystem.Models.Restaurant
{
    public class MenuItem : BaseEntity
    {
        // ========== ASOSIY MA'LUMOTLAR ==========
        public string Name { get; set; }              // Taom nomi (masalan: "Lag'mon", "Osh", "Manti")
        public string Description { get; set; }       // Tavsifi
        public decimal Price { get; set; }            // Narxi

        // ========== CATEGORY ==========
        public Guid CategoryId { get; set; }           
        public Category Category { get; set; }

        // ========== QO'SHIMCHA ==========
        public bool IsAvailable { get; set; }         // Mavjudmi?
        public bool IsVegetarian { get; set; }        // Vegetarianmi?
        public bool IsSpicy { get; set; }             // Achchiqmi?
        public int PreparationTime { get; set; }      // Tayyorlash vaqti (daqiqada)
        public string ImageUrl { get; set; }          // Rasm manzili (keyin)

        // ========== QAYSI RESTORANGA TEGISHLI ==========
        public Guid RestaurantId { get; set; }

        // ========== KONSTRUKTOR ==========
        public MenuItem()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            IsAvailable = true;
            IsVegetarian = false;
            IsSpicy = false;
            PreparationTime = 15;  // Default 15 daqiqa
        }

        // ========== METHODLAR ==========
        public override string GetDisplayInfo()
        {
            return $"{Name} - {Price:C} - {(IsAvailable ? "✅ Available" : "❌ Sold out")}";
        }

        public string GetFullInfo()
        {
            return $"""
                    🍽️ MENU ITEM INFO:
                    📛 Name: {Name}
                    📝 Description: {Description}
                    💰 Price: {Price:C}
                    📂 Category: {Category}
                    🕐 Prep time: {PreparationTime} min
                    🌱 Vegetarian: {(IsVegetarian ? "Yes" : "No")}
                    🌶️ Spicy: {(IsSpicy ? "Yes" : "No")}
                    📊 Status: {(IsAvailable ? "Available" : "Sold out")}
                    """;
        }

        // Narxni o'zgartirish
        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice <= 0)
            {
                Console.WriteLine("❌ Price must be greater than 0!");
                return;
            }
            Price = newPrice;
            UpdatedAt = DateTime.UtcNow;
        }

        // Mavjudligini o'zgartirish
        public void ToggleAvailability()
        {
            IsAvailable = !IsAvailable;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}