using System;
using Models.Base;  // BaseEntity uchun
using Enums.UserRole;

namespace Models.Users;  // ✅ bir marta User


public abstract class User : BaseEntity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    protected string PasswordHash { get; set; }  // Child class lar ko'radi
    public string Phone { get; set; }
    public UserRole Role { get; set; }
    public bool IsActive { get; set; } = true;
    
    public override string GetDisplayInfo()
    {
        return $"{FullName} ({Email}) - {GetRoleName()}";
    }
    
    public abstract string GetRoleName();
    
    // Parol bilan ishlash uchun metodlar
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
        // Oddiy hash (real loyihada SHA256 ishlating)
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var bytes = System.Text.Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}
