using BuisnessLayer.Interfaces.Notes;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces.Notes;
using RepositoryLayer.Services.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Services.Notes
{
    public  class NotesServicesBL : InoteServicesBL
    {
        private readonly INoteServicesRL _inoteServicesRL;

        public NotesServicesBL(INoteServicesRL inoteServicesRL)
        {
           _inoteServicesRL = inoteServicesRL;
        }

        public async Task<Note> createNotes(int Userid, CreateNote createNote)
        {
            var note = await _inoteServicesRL.createNotes(Userid, createNote);
            return note;
        }

        public async Task<NoteModel> archvieveSelectedNote(int id, bool isArchive)
        {
            var noteModel = await _inoteServicesRL.archvieveSelectedNote(id, isArchive);
            return noteModel;
        }

        public async Task<NoteModel> deleteSelectedNote(int id, bool isArchive)
        {
            var noteModel =await  _inoteServicesRL.deleteSelectedNote(id, isArchive);
            return noteModel;
        }

        public async Task<Note> GetAllNotesById(int id)
        {
            var note = await _inoteServicesRL.GetAllNotesById(id);
            return note;
        }

        public async  Task<NoteModel> PinnedSelectedNote(int id, bool isPinned)
        {
            var note =await  _inoteServicesRL.PinnedSelectedNote(id, isPinned);
            return note;
        }

        public async Task<Note> updateNote(int id, CreateNote note)
        {
            var updatedNote = await _inoteServicesRL.updateNote(id, note);
            return updatedNote;
        }
    }
}
