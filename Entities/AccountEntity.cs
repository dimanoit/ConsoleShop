using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    // Better to group all inheritance objects in one folder ( for example yll have AccountEntities folder
    // and all classes in this folder 
    public abstract class AccountEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Name} - {Surname} - {DateOfBirth} - {Email}";
        }
        
        // And what we should do if derived entities have more fields for example admin have 'rules'
        // hint ( we have 1 interesting behavioural pattern) 
        public void Update(AccountEntity account)
        {
            if(account.Name != null) // string.IsNullOrEmpty(account.Name)
                this.Name = account.Name;
            if (account.Surname != null)
                this.Surname = account.Surname;
            if (account.DateOfBirth != null)
                this.DateOfBirth = account.DateOfBirth;
            if (account.Email != null)
                this.Email = account.Email;
            if (account.Password != null)
                this.Password = account.Password;
        }
    }
}
