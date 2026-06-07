using System;
using System.Collections.Generic;
using Models.Users;
using Enums;
using Enums.UserRole;
using Models.RestaurantOwner;
using RestaurantReservationSystem.Models.Users;

namespace Services.Interfaces;

public interface IUserService
{
    // AUTANTIFICATION
    User Register(string fullName, string email, string password, string phone, UserRole role);
    User Login(string email, string password);

    // CRUD
    User GetUserById(Guid dd);
    List<User> GetAllUsers();
    void UpdateUser(User user);
    void DeleteUser(Guid id);

    // HELPER
    List<Customer> GetAllCustomers();
    List<RestaurantOwner> GetAllRestaurantOwners();
    List<Admin> GetAllAdmins();
    bool IsEmailExists(string email);
}