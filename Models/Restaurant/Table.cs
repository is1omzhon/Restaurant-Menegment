using System;
using RestaurantReservationSystem.Models.Common;
using RestaurantReservationSystem.Enums;

namespace RestaurantReservationSystem.Models.Restaurant
{
    public class Table : BaseEntity
    {
        // ========== ASOSIY MA'LUMOTLAR ==========
        public int TableNumber { get; set; }      // Stol raqami (1, 2, 3...)
        public int Capacity { get; set; }         // Necha kishilik (2, 4, 6, 8...)
        public string Location { get; set; }      // Joylashuvi (Indoor, Outdoor, Balcony, VIP)
        public bool IsAvailable { get; set; }     // Hozir bandmi?
        
        // ========== QAYSI RESTORANGA TEGISHLI ==========
        public Guid RestaurantId { get; set; }    // Qaysi restoranga tegishli
        
        // ========== QO'SHIMCHA MA'LUMOTLAR ==========
        public string Description { get; set; }   // Masalan: "Window view", "Near stage"
        public decimal PricePerHour { get; set; } // Soatlik narx (agar premium stol bo'lsa)
        
        // ========== KONSTRUKTOR ==========
        public Table()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            IsAvailable = true;
            PricePerHour = 0;
        }
        
        // ========== METHODLAR ==========
        public override string GetDisplayInfo()
        {
            return $"Table #{TableNumber} - Capacity: {Capacity} - Location: {Location} - {(IsAvailable ? "✅ Available" : "❌ Booked")}";
        }
        
        public string GetFullInfo()
        {
            return $"""
                    🪑 TABLE INFO:
                    📌 Number: {TableNumber}
                    👥 Capacity: {Capacity} people
                    📍 Location: {Location}
                    💰 Price/hour: {PricePerHour:C}
                    📊 Status: {(IsAvailable ? "Available" : "Booked")}
                    """;
        }
        
        // Stolni band qilish
        public void Book()
        {
            IsAvailable = false;
            UpdatedAt = DateTime.UtcNow;
        }
        
        // Stolni bo'shatish
        public void Release()
        {
            IsAvailable = true;
            UpdatedAt = DateTime.UtcNow;
        }
        
        // Sig'im yetarlimi?
        public bool CanAccommodate(int partySize)
        {
            return Capacity >= partySize;
        }
    }
}