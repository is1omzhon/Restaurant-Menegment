using System;
using System.Collections.Generic;
using RestaurantReservationSystem.Models.Users;
using RestaurantReservationSystem.Enums;

namespace RestaurantReservationSystem.Services.Interfaces
{
    public interface IUserService
    {
        User Register(string fullName, string email, string password, string phone, UserRole role);
        User Login(string email, string password);
        User GetUserById(Guid id);
        List<User> GetAllUsers();
        void UpdateUser(User user);
        void DeleteUser(Guid id);
        List<Customer> GetAllCustomers();
        List<RestaurantOwner> GetAllRestaurantOwners();
        List<Admin> GetAllAdmins();
        bool IsEmailExists(string email);
    }
}