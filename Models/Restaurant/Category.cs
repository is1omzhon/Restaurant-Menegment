using System;
using System.Collections.Generic;
using RestaurantReservationSystem.Models.Common;

namespace RestaurantReservationSystem.Models.Restaurant
{
    public class Category : BaseEntity
    {
        // ========== ASOSIY MA'LUMOTLAR ==========
        public string Name { get; set; }              // Kategoriya nomi (Salads, Soups, Main, Dessert, Drinks)
        public string Description { get; set; }       // Tavsifi
        public string Icon { get; set; }              // Icon nomi (🥗, 🍲, 🍜, 🍰, 🥤)
        public int DisplayOrder { get; set; }         // Chiqish tartibi (1, 2, 3...)
        
        // ========== QO'SHIMCHA ==========
        public bool IsActive { get; set; }            // Faolmi?
        
        // ========== NAVIGATION ==========
        public List<MenuItem> MenuItems { get; set; } // Shu kategoriyadagi taomlar
        
        // ========== KONSTRUKTOR ==========
        public Category()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
            DisplayOrder = 0;
            MenuItems = new List<MenuItem>();
        }
        
        // ========== METHODLAR ==========
        
        public override string GetDisplayInfo()
        {
            return $"{Icon} {Name} - {MenuItems.Count} items";
        }
        
        public string GetFullInfo()
        {
            return $"""
                    📂 CATEGORY INFO:
                    📛 Name: {Name}
                    📝 Description: {Description}
                    🖼️ Icon: {Icon}
                    📦 Items: {MenuItems.Count}
                    📊 Status: {(IsActive ? "Active" : "Inactive")}
                    """;
        }
        
        // Taom qo'shish
        public void AddMenuItem(MenuItem item)
        {
            if (!MenuItems.Contains(item))
            {
                MenuItems.Add(item);
                UpdatedAt = DateTime.UtcNow;
            }
        }
        
        // Taom o'chirish
        public void RemoveMenuItem(MenuItem item)
        {
            if (MenuItems.Contains(item))
            {
                MenuItems.Remove(item);
                UpdatedAt = DateTime.UtcNow;
            }
        }
        
        // Aktiv/deaktiv qilish
        public void ToggleActive()
        {
            IsActive = !IsActive;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}