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

namespace RepositoryLayer.Services.Notes
{
    public  class PinnedNoteRL : IpinnedNoteRL
    {
        private readonly FundooNotesDBContext _fundooNotesDBContext;
        private readonly IConfiguration _configuration;

        public PinnedNoteRL(FundooNotesDBContext fundooNotesDBContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _fundooNotesDBContext = fundooNotesDBContext;
        }
        public  NoteModel PinnedSelectedNote(int id, bool isPinned)
        {
            var note = _fundooNotesDBContext.Notes.FirstOrDefault(x=>x.NoteId == id);
            if (note == null)
            {
                return null;
            }
            note.IsPinned = isPinned;
            _fundooNotesDBContext.Entry(note).State = EntityState.Modified;
            _fundooNotesDBContext.SaveChanges();
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
}
