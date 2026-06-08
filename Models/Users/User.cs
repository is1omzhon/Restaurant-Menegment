using System;
using RestaurantReservationSystem.Models.Common;
using RestaurantReservationSystem.Enums;

namespace RestaurantReservationSystem.Models.Users
{
    public abstract class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        protected string PasswordHash { get; set; }
        public string Phone { get; set; }
        public UserRole Role { get; set; }
        public bool IsActive { get; set; } = true;
        
        public override string GetDisplayInfo()
        {
            return $"{FullName} ({Email}) - {GetRoleName()}";
        }
        
        public abstract string GetRoleName();
        
        public void SetPassword(string password)
        {
            PasswordHash = HashPassword(password);
        }
        
        public bool CheckPassword(string password)
        {
            return PasswordHash == HashPassword(password);
        }
        
        private string HashPassword(string password)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
