using Microsoft.Extensions.Configuration;
using ModelLayer.Model;
using RepositoryLayer.FundooDbContext;
using RepositoryLayer.Interfaces.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services.Notes
{
    public class DeleteNoteRL : IdeleteNoteRL
    {
        private readonly FundooNotesDBContext _fundooNotesDBContext;
        private readonly IConfiguration _configuration;

        public DeleteNoteRL(FundooNotesDBContext fundooNotesDBContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _fundooNotesDBContext = fundooNotesDBContext;
        }
        public  NoteModel deleteSelectedNote(int id, bool isArchive)
        {
            var note = _fundooNotesDBContext.Notes.FirstOrDefault(x=>x.NoteId == id );

            if ( note == null )
            {
                return null;
            }
            else
            {
                _fundooNotesDBContext.Remove(note);
                var NoteModel = new NoteModel();
                NoteModel.NoteId = note.NoteId;
                NoteModel.Title = note.Title;
                NoteModel.Content = note.Content;
                NoteModel.CreatedDate = note.CreatedDate;
                NoteModel.ModifiedDate = note.ModifiedDate;
                NoteModel.IsArchived = note.IsArchived;
                NoteModel.IsPinned = note.IsPinned;
                NoteModel.IsTrash = note.IsTrash;
                _fundooNotesDBContext.SaveChanges();
                return NoteModel;
            }
        }
    }
}
