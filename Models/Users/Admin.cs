using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Models.Base;

namespace Models.Users;

public class Admin : User
{
    public List<string> Permissions {get; set;}
    public string AdminLevel {get; set;} // SuperAdmin, Moderator, Support

    public Admin()
    {
        Permissions = new List<string>
        {
            "manage_users",
            "manage_restaurants",
            "view_supports",
            "manage_admins"
        };
        AdminLevel = "Moderator";
    }

    public override string GetRoleName()
    {
    
        return "Admin";
    }

    public void AddPermissions(string permission)
    {   
        if(! Permissions.Contains(permission))
            Permissions.Add(permission);
    }

    public void RemovePermission(string permission)
    {
        Permissions.Remove(permission);
    }

    public bool HasPermission(string permission)
    {
        return Permissions.Contains(permission);
    }

}