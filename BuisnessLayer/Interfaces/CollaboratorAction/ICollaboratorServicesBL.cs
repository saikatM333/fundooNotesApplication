using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Interfaces.CollaboratorAction
{
    public  interface ICollaboratorServicesBL
    {
        Task<Collaborator> AddCollaboratorAsync(CollaboratorModel model);
        Task<IEnumerable<Collaborator>> GetCollaboratorByNoteId(int noteId);
        Task<Collaborator> removeCollaborator(int id);
    }
}
