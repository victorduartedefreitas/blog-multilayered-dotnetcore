using System.Collections.Generic;

namespace Blog.Data.Model
{
    public class User : ICopiableModel<User>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public ICollection<Address> Adresses { get; set; }
        public ICollection<Phone> Phones { get; set; }

        public void CopyFrom(User source)
        {
            this.Name = source.Name;
            this.UserName = source.UserName;
            this.Email = source.Email;
            this.Adresses = source.Adresses;
            this.Phones = source.Phones;
        }
    }
}
