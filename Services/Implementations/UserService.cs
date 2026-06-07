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

namespace Services.Implementations;

public class UserService : IUserService
{

    private Dictionary<Guid, User> _users;
    private readonly FileStorage _storage;

    public UserService()
    {
        _storage = new FileStorage("users.json");
        _users = _storage.Load<Dictionary<Guid, User>>()?? new Dictionary<Guid, User>();

        if (_users.Count == 0)
            SeedDefaultAdmin();
    }

    






    public void DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Admin> GetAllAdmins()
    {
        throw new NotImplementedException();
    }

    public List<Customer> GetAllCustomers()
    {
        throw new NotImplementedException();
    }

    public List<RestaurantOwner> GetAllRestaurantOwners()
    {
        throw new NotImplementedException();
    }

    public List<User> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public User GetUserById(Guid dd)
    {
        throw new NotImplementedException();
    }

    public bool IsEmailExists(string email)
    {
        throw new NotImplementedException();
    }

    public User Login(string email, string password)
    {
        throw new NotImplementedException();
    }

    public User Register(string fullName, string email, string password, string phone, UserRole role)
    {
        throw new NotImplementedException();
    }

    public void UpdateUser(User user)
    {
        throw new NotImplementedException();
    }
}