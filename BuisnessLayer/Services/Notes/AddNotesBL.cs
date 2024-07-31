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
    public  class AddNotesBL : IaddNoteBL
    {
        private readonly IaddNotesRL _iaddNotesRL;

        public AddNotesBL(IaddNotesRL iaddNotesRL)
        {
            _iaddNotesRL = iaddNotesRL;
        }

       public  CreateNote createNotes(int Userid, CreateNote createNote)
        {
            var note = _iaddNotesRL.createNotes(Userid, createNote);
            return note;
        }

    }
}
