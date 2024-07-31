using Microsoft.Extensions.Configuration;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.FundooDbContext;
using RepositoryLayer.Interfaces.CollaboratorAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services.CollaboratorAction
{
    public  class CollaboratorServices : ICollaboratorServicesRL
    { private readonly FundooNotesDBContext _fundooNotesDBContext;
        private readonly IConfiguration _configuration;
        public CollaboratorServices(FundooNotesDBContext fundooNotesDBContext,  IConfiguration configuration) 
        { 
            _configuration = configuration;
            _fundooNotesDBContext = fundooNotesDBContext;
        }

        public async Task<Collaborator> AddCollaboratorAsync(CollaboratorModel model)
        {  
             Collaborator collaborator = new Collaborator();
             collaborator.Email = model.Email;
             collaborator.NoteId = model.NoteId;
             _fundooNotesDBContext.Collaborators.Add(collaborator);
             return collaborator;
        }
        public async  Task<IEnumerable<Collaborator>> GetCollaboratorByNoteId(int noteId)
        {
             IEnumerable<Collaborator> collaboratorList = _fundooNotesDBContext.Collaborators.Where(x=>x.NoteId == noteId).ToList();
             return collaboratorList;
        }
        public async Task<Collaborator> removeCollaborator(int id )
        {
            var collaborator =  _fundooNotesDBContext.Collaborators.Find(id);
            if (collaborator != null)
            {
                return null;
            }
            else
            {
                _fundooNotesDBContext.Collaborators.Remove(collaborator);
                 
                _fundooNotesDBContext.SaveChangesAsync();  
                return collaborator;
            }
        }
    }
}
