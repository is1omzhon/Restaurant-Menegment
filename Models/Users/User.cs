using System;
using Models.Base.BaseEntity;  // BaseEntity uchun
using Enums.UserRole;

namespace Models.Users  // ✅ bir marta User
{
    public abstract class User : BaseEntity
    {
        // ❌ Id, CreatedAt, UpdatedAt BaseEntity da bor! Qayta yozma!
        
        public string FullName { get; set; }
        public string Email { get; set; }
        protected string PasswordHash { get; set; }  // ✅ protected (child class lar ko'radi)
        public string Phone { get; set; }
        public UserRole Role { get; set; }
        public bool IsActive { get; set; } = true;   // ✅ default true
        
        // ✅ To'g'ri GetDisplayInfo
        public override string GetDisplayInfo()
        {
            return $"{FullName} ({Email}) - {Role}";
        }
        
        // ✅ Abstract metod (child class lar to'ldiradi)
        public abstract string GetRoleName();
    }
}