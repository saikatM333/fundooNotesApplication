using BuisnessLayer.Interfaces.Notes;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Services.Notes
{
    public  class UpdateNotesBL: IupdateNotesBL
    {
        private readonly IupdateNoteRL _iupdateNote;
        public UpdateNotesBL(IupdateNoteRL iupdateNote) 
        {
            _iupdateNote = iupdateNote;

        }
       public  Note updateNote(int id, CreateNote note)
        {
            var updatedNote = _iupdateNote.updateNote(id, note);
            return updatedNote;
        }
    }
}
