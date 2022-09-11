using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace BLL
{
    public class GuestService : BaseService // Mb auth service?
    {
        public bool RegisterNewAccount(UserEntity newAccount, IDataContext context)
        {
            if (context.Customers.Find(c => c.Email == newAccount.Email) != null)
                return false;
            newAccount.Id = context.Customers.LastOrDefault().Id + 1; // context.Customers.LastOrDefault().Id -> context.LastUserId (think about concurrency)
            context.Customers.Add(newAccount); // encapsulation violation
            // My proposal to implement Repository pattern for each context entity 
            return true;
        }
        public AccountEntity LogIn(string email, string password, IDataContext context)
        {
            // I think it's exist more suitable data modeling 
            // Have you thought about something like that User -> UserRoles -> Roles
            // Let's image then in future you will have database and each call to db it's time 
            // In this solution you make 2 calls to db, but you can do it once if you remodel data
            return (AccountEntity) context.Customers
                       .Find(c => c.Email == email && c.Password == password) ??
                context.Admins.Find(c => c.Email == email && c.Password == password);
        }
    }
}
