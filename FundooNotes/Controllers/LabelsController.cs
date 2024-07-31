using BuisnessLayer.Interfaces.LabelAction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabelsController : ControllerBase
    {
        private readonly ILabelBL _labelBL;

        public LabelsController(ILabelBL labelBL)
        {
            _labelBL = labelBL;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetLabelsAsync(int userId)
        {
            var labels = _labelBL.GetLabelsAsync(userId);
            return Ok(labels);
        }
        [HttpGet("{UserId}/{labelId}")]
        public async Task<IActionResult> GetNoteByLabelIdAsync( int UserId , int labelId)
        {
            var label = _labelBL.GetNoteByLabelIdAsync(labelId, UserId);
            return Ok(label);
        }
        [HttpPost("add/{userId}")]
        public async Task<IActionResult> AddLabelAsync([FromRoute]int userId, string name)
        {
            var label = _labelBL.AddLabelAsync(userId, name);
            return Ok(label);
        }
        [HttpPut("update/{UserId}/{labelId}")]
        public async Task<IActionResult> UpdateLabelAsync([FromRoute]int UserId ,[FromRoute]int labelId , [FromBody]string name)
        {
            var label = _labelBL.UpdateLabelAsync(name);
            return Ok(label);
        }
        [HttpDelete("delete/{userId}/{labelId}")]
        public async Task<IActionResult> DeleteLabelAsync([FromRoute]int userId ,[FromRoute] int labelId)
        {
            var label = _labelBL.DeleteLabelAsync(labelId);
            return Ok(label);
        }

    }
}
