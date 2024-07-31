using BuisnessLayer.Interfaces.Notes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Model;
using RepositoryLayer.Interfaces.Notes;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class notesController : ControllerBase
    {
        private readonly InoteServicesBL _inoteServicesBL;
       
        public notesController(InoteServicesBL inoteServicesBL) 
        {
            _inoteServicesBL = inoteServicesBL;
        }

        [HttpGet("{UserId}")]
        public IActionResult GetNoteById(int  UserId ) 
        {   
            var data  = _inoteServicesBL.GetAllNotesById(UserId);
            return Ok(data);
        }

        [HttpPost("create/{UserId}")]
        public IActionResult addnote(int UserId , CreateNote note)
        {
            var result =    _inoteServicesBL.createNotes(UserId, note);
            return Ok(result);
        }

        [HttpPut("update/{UserId}/{noteID}")]
        public IActionResult updateNote(int UserId , int noteID, CreateNote note)
        {            
            var result = _inoteServicesBL.updateNote(noteID, note);
            return Ok(result);
        }

        // delete archive and pin 
        [HttpPut("archived/{userID}/{noteID}")]
        public async Task<IActionResult> archvieveSelectedNote(int userID ,int noteID, bool isArchive)
        {
            var noteModel = _inoteServicesBL.archvieveSelectedNote(noteID, isArchive);
            return Ok(noteModel);
        }
        [HttpDelete("delete/{userID}/{noteID}")]
        public async Task<IActionResult> deleteSelectedNote(int userID, int noteID, bool isArchive)
        {
            var noteModel = _inoteServicesBL.deleteSelectedNote(noteID, isArchive);
            return Ok(noteModel);
        }
        [HttpPut("pinned/{userID}/{noteID}")]
        public async Task<IActionResult> PinnedSelectedNote(int userID , int noteID, bool isPinned)
        {
            var note = _inoteServicesBL.PinnedSelectedNote(noteID, isPinned);
            return Ok(note);
        }


    }
}
