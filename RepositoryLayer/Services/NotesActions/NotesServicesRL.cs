using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.FundooDbContext;
using RepositoryLayer.Interfaces.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services.NotesActions
{
    public  class NotesServicesRL : INoteServicesRL
    {
        private readonly FundooNotesDBContext _dbContext;
        private readonly IConfiguration _configuration;
        public NotesServicesRL(FundooNotesDBContext fundooNotesDBContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _dbContext = fundooNotesDBContext;
        }

        public async Task<Note> createNotes(int Userid, CreateNote note)

        {
            var userNote = new Note();
            userNote.UserId = Userid;
            userNote.Content = note.Content;
            userNote.Title = note.Title;
            userNote.CreatedDate = DateTime.Now;
            userNote.ModifiedDate = null;


            var user = _dbContext.Notes.Add(userNote);
            _dbContext.SaveChanges();
            return userNote;
        }

        public async Task<NoteModel> archvieveSelectedNote(int id, bool isArchive)
        {
            var note = _dbContext.Notes.FirstOrDefault(x => x.NoteId == id);
            if (note == null)
            {
                return null;
            }
            else
            {
                note.IsArchived = isArchive;
                _dbContext.Entry(note).State = EntityState.Modified;
                _dbContext.SaveChanges();
                var NoteModel = new NoteModel();
                NoteModel.NoteId = note.NoteId;
                NoteModel.Title = note.Title;
                NoteModel.Content = note.Content;
                NoteModel.CreatedDate = note.CreatedDate;
                NoteModel.ModifiedDate = note.ModifiedDate;
                NoteModel.IsArchived = note.IsArchived;
                NoteModel.IsPinned = note.IsPinned;
                NoteModel.IsTrash = note.IsTrash;

                return NoteModel;
            }
        }

        public async Task<NoteModel> deleteSelectedNote(int id, bool isArchive)
        {
            var note = _dbContext.Notes.FirstOrDefault(x => x.NoteId == id);

            if (note == null)
            {
                return null;
            }
            else
            {
                _dbContext.Remove(note);
                var NoteModel = new NoteModel();
                NoteModel.NoteId = note.NoteId;
                NoteModel.Title = note.Title;
                NoteModel.Content = note.Content;
                NoteModel.CreatedDate = note.CreatedDate;
                NoteModel.ModifiedDate = note.ModifiedDate;
                NoteModel.IsArchived = note.IsArchived;
                NoteModel.IsPinned = note.IsPinned;
                NoteModel.IsTrash = note.IsTrash;
                _dbContext.SaveChanges();
                return NoteModel;
            }
        }

        public async Task<Note> GetAllNotesById(int id)
        {
            var result = _dbContext.Notes.FirstOrDefault(x => x.UserId == id);

            var note = new NoteModel();
            note.Title = result.Title;
            note.Content = result.Content;
            note.CreatedDate = result.CreatedDate;
            note.ModifiedDate = result.ModifiedDate;
            return result;
        }

        public async Task<NoteModel> PinnedSelectedNote(int id, bool isPinned)
        {
            var note = _dbContext.Notes.FirstOrDefault(x => x.NoteId == id);
            if (note == null)
            {
                return null;
            }
            note.IsPinned = isPinned;
            _dbContext.Entry(note).State = EntityState.Modified;
            _dbContext.SaveChanges();
            var NoteModel = new NoteModel();
            NoteModel.NoteId = note.NoteId;
            NoteModel.Title = note.Title;
            NoteModel.Content = note.Content;
            NoteModel.CreatedDate = note.CreatedDate;
            NoteModel.ModifiedDate = note.ModifiedDate;
            NoteModel.IsArchived = note.IsArchived;
            NoteModel.IsPinned = note.IsPinned;
            NoteModel.IsTrash = note.IsTrash;

            return NoteModel;
        }

        public async Task<Note> updateNote(int id, CreateNote note)
        {
            var notes = _dbContext.Notes.FirstOrDefault(x => x.NoteId == id);

            notes.Title = note.Title;
            notes.Content = note.Content;
            notes.ModifiedDate = DateTime.Now;
            _dbContext.Entry(notes).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return notes;

        }
    }
}
