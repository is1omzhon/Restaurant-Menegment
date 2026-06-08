using System;
using RestaurantReservationSystem.Enums;
using RestaurantReservationSystem.Services.Interfaces;
using RestaurantReservationSystem.Services.Implementations;

// ========== TOP-LEVEL STATEMENTS (Main yo'q) ==========
IUserService userService = new UserService();

Console.WriteLine("=== RESTAURANT RESERVATION SYSTEM ===\n");

// Register
Console.WriteLine("--- REGISTER ---");
var customer = userService.Register("Ali Valiyev", "ali@mail.com", "123456", "+998901234567", UserRole.Customer);

// Login
Console.WriteLine("\n--- LOGIN ---");
var user = userService.Login("ali@mail.com", "123456");

if (user != null)
{
    Console.WriteLine($"\n✅ Welcome: {user.FullName}");
    Console.WriteLine($"📌 Role: {user.GetRoleName()}");
}

// All users
Console.WriteLine("\n--- ALL USERS ---");
var allUsers = userService.GetAllUsers();
foreach (var u in allUsers)
{
    Console.WriteLine($"- {u.FullName} ({u.Email}) - {u.GetRoleName()}");
}

Console.WriteLine($"\n📊 Total users: {allUsers.Count}");
