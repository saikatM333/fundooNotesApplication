using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
    public  class AddNotesRL : IaddNotesRL
    { private readonly FundooNotesDBContext _dbContext;
        private readonly IConfiguration _configuration;
        public AddNotesRL(FundooNotesDBContext fundooNotesDBContext , IConfiguration configuration) 
        {
            _configuration = configuration;
            _dbContext = fundooNotesDBContext;
        }

        public CreateNote createNotes(int Userid , CreateNote note)

        {
            var userNote = new Note();
            userNote.UserId = Userid;
            userNote.Content = note.Content;
            userNote.Title = note.Title;
            userNote.CreatedDate = DateTime.Now;
            userNote.ModifiedDate = null;


            var user = _dbContext.Notes.Add(userNote);
            _dbContext.SaveChanges();
            return note;
        }

    }
}
