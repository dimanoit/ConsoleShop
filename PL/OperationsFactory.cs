using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;
using BLL;
using PL;

namespace PL
{
    // Different file and class name 
    public static class OperationsSelector
    {
        private static Dictionary<string, IOperations> keyValuePairs = new Dictionary<string, IOperations>
        {
            // Antipattern try to avoid use string literals better
            // to use something like this typeof(UserEntity) Dictionary<Type, IOperations>
            {"UserEntity", new CustomerOperations() }, 
            {"AdminEntity", new AdminOperations() } 
        };

        public static IOperations GetOperations(string accountType)
        {
            // Just a note) Try catch it's really heavy stuff in .Net, try to avoid it as much as possible
            try
            {
                return keyValuePairs[accountType];
            }
            catch
            {
                return new GuestOperations();
            }
        }
    }
}
