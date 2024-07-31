using BuisnessLayer.Interfaces.CollaboratorAction;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces.CollaboratorAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Services.CollaboratorAction
{
    public class CollaboratorServicesBL : ICollaboratorServicesBL
    {
        private readonly ICollaboratorServicesRL _collaboratorServicesRL;

        public CollaboratorServicesBL(ICollaboratorServicesRL collaboratorServicesRL)
        {
            _collaboratorServicesRL = collaboratorServicesRL;
        }

        public async Task<Collaborator> AddCollaboratorAsync(CollaboratorModel model)
        {
            var colloborator = await _collaboratorServicesRL.AddCollaboratorAsync(model);
            return colloborator;
        }
        public async Task<IEnumerable<Collaborator>> GetCollaboratorByNoteId(int noteId)
        {
            var colloborator = await _collaboratorServicesRL.GetCollaboratorByNoteId(noteId);
            return colloborator;
        }
        public async Task<Collaborator> removeCollaborator(int id)
        {
            var colloborator = await  _collaboratorServicesRL.removeCollaborator(id);
            return colloborator;
        }
    }
}
