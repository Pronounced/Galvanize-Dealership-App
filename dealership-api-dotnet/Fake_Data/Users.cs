using System;
using System.Collections.Generic;
using dealership_app.Models;

namespace dealership_app.Fake_Data
{
    public class Users
    {
        static private List<User> users = new List<User>();

        static public List<User> GetUsers()
        {
            var count = 0;

            if(users.Count > 0)
            {
                return users;
            }

            for (int i = 0; i < 5; i++)
            {
                var user = new User();
                user.username = $"{count++}";
                user.email = $"{count}@test.com";
                user.password = "1";
                user.creationdate = DateTime.Now;
                user.updatedate = DateTime.Now;
                user.isAdmin = false;
                users.Add(user);
            }

            var admin = new User(){
                username = "admin",
                email = "admin@test.com",
                password = "1",
                creationdate = DateTime.Now,
                updatedate = DateTime.Now,
                isAdmin = true
            };
            users.Add(admin);

            return users;
        }
    }
}