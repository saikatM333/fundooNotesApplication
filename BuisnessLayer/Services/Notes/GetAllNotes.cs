using BuisnessLayer.Interfaces.Notes;
using ModelLayer.Model;
using RepositoryLayer.Interfaces.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Services.Notes
{
    public  class GetAllNotes: IgetAllNotesBL
    {
        private readonly IgetAllNotesRL _igetAllNotesRL;
        public GetAllNotes(IgetAllNotesRL igetAllNotesRL) 
        {
             _igetAllNotesRL = igetAllNotesRL;
        }

       
        public NoteModel getAllNotesById(int id) 
        {
            var note  = _igetAllNotesRL.GetAllNotesById(id);
            return note;
        }
    }
}
