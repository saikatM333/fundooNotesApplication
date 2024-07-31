using BuisnessLayer.Interfaces.CollaboratorAction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorServicesBL _collaboratorServicesBL;
        public CollaboratorController(ICollaboratorServicesBL collaboratorServicesBL)
        {
            _collaboratorServicesBL = collaboratorServicesBL;
        }

        [HttpGet("collaboratorNotes/{noteid}")]
        public async Task<IActionResult> GetCollaborator(int noteid) 
        { 
            var data = await _collaboratorServicesBL.GetCollaboratorByNoteId(noteid);
            return Ok(new { data= data});    
        }

        [HttpDelete("deleteCollaborator/{id}")]
        public async Task<IActionResult> deleteCollaborator(int id)
        {
            var data  = _collaboratorServicesBL.removeCollaborator(id);
            return Ok(new { data= data});
        }

        [HttpPost("addColllaborator/{noteId}")]
        public async Task<IActionResult> addColloborator(int noteId, string email)
        {
              CollaboratorModel model  = new CollaboratorModel()
            {
                NoteId = noteId,
                Email = email
            };

            var data = _collaboratorServicesBL.AddCollaboratorAsync(model);
            return Ok(data);
        }
    }
}
