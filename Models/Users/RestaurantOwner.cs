using System.Collections.Generic;
using Models.Base;
using Models.Restaurant;
using Models.Users;

namespace Models.RestaurantOwner;

public class RestaurantOwner : User
{
    public List<Restaurant> Restaurants {get; set;}
    public double AverageRating {get;set;}
    public DateTime JoinedData {get; set;}

    public RestaurantOwner()
    {
        Restaurants = new List<Restaurant> ();
        AverageRating = 0;
        JoinedData = DateTime.UtcNow;
    }

    public override string GetRoleName()
    {
        return "RestourantOwner";
    }

    public void UpdateAverageRating()
    {
        if ( Restaurants.Count == 0)
        {
            AverageRating = 0;
            return;
        }

        double total = 0;

        foreach ( var r in Restaurants)
        {
            total += r.Rating;
        }
        AverageRating = total / Restaurants.Count;
    }
}