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
    public class UpdateNotes : IupdateNoteRL
    { private readonly FundooNotesDBContext _dbContext;
        private readonly IConfiguration _configuration;

        public UpdateNotes(FundooNotesDBContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public  Note updateNote(int id , CreateNote note)
        {
            var notes = _dbContext.Notes.FirstOrDefault(x=>x.NoteId == id);
            
            notes.Title = note.Title;
            notes.Content = note.Content;
            notes.ModifiedDate = DateTime.Now;
            _dbContext.Entry(notes).State=EntityState.Modified;
            _dbContext.SaveChanges();
            return notes;

        }
    }
}
