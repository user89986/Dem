using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Models;

namespace WpfApp1.Data
{
    // получение роли
    internal class AuthService
    {
        public User TryAuth(string login,string password)
        {
            using (var context = new TestDem1Context())
            {
                User user = context.Users.Include(u => u.Role).FirstOrDefault(u => u.Login == login && u.Password == password);
                if (user == null) return null;
                return user;
            }
        }
    }
}
