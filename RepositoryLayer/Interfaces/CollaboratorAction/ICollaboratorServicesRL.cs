using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces.CollaboratorAction
{
    public interface ICollaboratorServicesRL
    {
         Task<Collaborator> AddCollaboratorAsync(CollaboratorModel model);
         Task<IEnumerable<Collaborator>> GetCollaboratorByNoteId(int  noteId);
         Task<Collaborator> removeCollaborator(int id );
    }
}
