using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<Note> Notes { get; set; }
        public ICollection<Label> Labels { get; set; }
    }
}
