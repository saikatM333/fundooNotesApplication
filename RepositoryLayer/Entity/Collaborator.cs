using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public  class Collaborator
    {
        public int CollaboratorId { get; set; }
        public string Email { get; set; }
        public int NoteId { get; set; }

        public Note Note { get; set; }
    }
}
