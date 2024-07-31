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
    public  class PinnedNoteBL : IpinnedNoteBL
    {
        private readonly IpinnedNoteRL _ipinnedNoteRL;
        public PinnedNoteBL(IpinnedNoteRL ipinnedNoteRL) 
        {
            _ipinnedNoteRL = ipinnedNoteRL;
        }

        public NoteModel PinnedSelectedNote(int id, bool isPinned)
        {
            var note = _ipinnedNoteRL.PinnedSelectedNote(id, isPinned);
            return note;
        }
    }
}
