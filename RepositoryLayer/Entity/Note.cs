using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public  class Note
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsArchived { get; set; } = false;
        public bool IsPinned { get; set; } = false;
        public bool IsTrash { get; set; } =false;
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<Label> Labels { get; set; }
        public ICollection<Collaborator> Collaborators { get; set; }
    }
}
