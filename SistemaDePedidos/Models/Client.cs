using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Client
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ID { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }

        public Client(string name, string lastname, string id, string adress, string email)
        {
            this.Name = name;
            this.LastName = lastname;
            this.ID = id;
            this.Adress = adress;
            this.Email = email;
        }
    }
}
