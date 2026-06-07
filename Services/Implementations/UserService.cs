using System;
using System.Collections.Generic;
using System.Linq;
using Models.Users;
using Models.Base;
using Enums;
using Services.Helpers;
using Services.Interfaces;
using RestaurantReservationSystem.Models.Users;
using Models.RestaurantOwner;
using Enums.UserRole;
using System.Data.Common;
using System.Collections;

namespace Services.Implementations;

public class UserService : IUserService
{

    private Dictionary<Guid, User> _users;
    private readonly FileStorage _storage;

    public UserService()
    {
        _storage = new FileStorage("users.json");
        _users = _storage.Load<Dictionary<Guid, User>>() ?? new Dictionary<Guid, User>();

        if (_users.Count == 0)
            SeedDefaultAdmin();
    }

    private void SeedDefaultAdmin()
    {
        var admin = new Admin
        {
            Id = new Guid(),
            FullName = "Super Admin",
            Email = "admin@restaurant.com",
            Phone = "+992 98 729 81 99",
            Role = UserRole.Admin,
            IsActive = true,
            AdminLevel = "SuperAdmin"
        };

        admin.SetPassword("admin123");

        _users.Add(admin.Id, admin);
        SaveChanges();
    }

    private void SaveChanges()
    {
        _storage.Save(_users);
    }

    // REGISTER 
    public User Register(string fullName, string email, string password, string phone, UserRole role)
    {
        if (IsEmailExists(email))
        {
            Console.WriteLine("Email is already exists");
            return null;
        }

        User newUser = role switch
        {
            UserRole.Customer => new Customer(),
            UserRole.RestaurantOwner => new RestaurantOwner(),
            UserRole.Admin => new Admin(),
            _ => null
        };

        if (newUser == null)
        {
            Console.WriteLine("Invalid role");
            return null;
        }

        newUser.Id = Guid.NewGuid();
        newUser.FullName = fullName;
        newUser.Email = email;
        newUser.Phone = phone;
        newUser.Role = role;
        newUser.IsActive = true;
        newUser.SetPassword(password);

        _users.Add(newUser.Id, newUser);
        SaveChanges();

        Console.WriteLine($"{role} is registired successfully!!!");
        return newUser;

    }

    // =====LOGIN=====
    public User Login(string email, string password)
    {
        var user = _users.Values.FirstOrDefault(u => u.Email == email);

        if (user == null)
        {
            Console.WriteLine("User not found!!!");
            return null;
        }

        if (!user.IsActive)
        {
            Console.WriteLine("User uis disactived!!!");
            return null;
        }
        
        if (!user.CheckPassword(password))
        {
            Console.WriteLine("Invalid password!!!");
            return null;
        }

        Console.WriteLine($"Welcome back, {user.FullName}");
        return user;
    }

    // ========== CRUD ==========
    public User GetUserById(Guid id)
    {
        return _users.TryGetValue(id, out var user) ?   user : null;
    }

    public List<User> GetAllUsers()
    {
        return _users.Values.ToList();
    }

    public void UpdateUser(User user)
    {
        if (!_users.ContainsKey(user.Id))
        {
            Console.WriteLine($"User not found!!!");
            return;
        }

        _users[user.Id] = user;
        SaveChanges();
        Console.WriteLine("User updated successfully!");
    }

    public void DeleteUser(Guid id)
    {
        if (_users.Remove(id))
        {
            SaveChanges();
            Console.WriteLine("User deleted successfully!");
        }
        else
        {
            Console.WriteLine("User not found!");
        }
    }

    public bool IsEmailExists(string email)
    {
        return _users.Values.Any(u => u.Email == email);
    }

    public List<Customer> GetAllCustomers()
    {
        return _users.Values.OfType<Customer>().ToList();
    }

    public List<RestaurantOwner> GetAllRestaurantOwners()
    {
        return _users.Values.OfType<RestaurantOwner>().ToList();
    }

    public List<Admin> GetAllAdmins()
    {
        return _users.Values.OfType<Admin>().ToList();
    }    
}