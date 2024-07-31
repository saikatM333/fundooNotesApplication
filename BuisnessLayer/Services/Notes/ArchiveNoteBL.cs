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
    public  class ArchiveNoteBL : IarchieveNoteBL
    {
        private readonly IarchieveNoteRL _iarchieveNoteRL;
        public ArchiveNoteBL(IarchieveNoteRL iarchieveNoteRL) 
        {
            _iarchieveNoteRL = iarchieveNoteRL;
        }

        public NoteModel archvieveSelectedNote(int id, bool isArchive)
        {
            var noteModel = _iarchieveNoteRL.archvieveSelectedNote(id, isArchive);
            return noteModel;
        }
    }
}
