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
    public  class DeleteNoteBL : IdeleteNoteBL
    {
        private readonly IdeleteNoteRL _ideleteNoteRL;
        public DeleteNoteBL(IdeleteNoteRL ideleteNoteRL) {
            _ideleteNoteRL = ideleteNoteRL;
        }
        public NoteModel deleteSelectedNote(int id, bool isArchive) { 
            var noteModel = _ideleteNoteRL.deleteSelectedNote(id, isArchive);
            return noteModel;
        }
    }
}
