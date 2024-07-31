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
    public  class GetAllNotesRL : IgetAllNotesRL
    { private readonly FundooNotesDBContext _dbContext;
        private readonly IConfiguration _configuration;
        public GetAllNotesRL(FundooNotesDBContext fundooNotesDBContext , IConfiguration configuration) 
        
        {
            _dbContext = fundooNotesDBContext;
            _configuration = configuration;
        }

        public NoteModel GetAllNotesById(int id)
        {   
            var result  = _dbContext.Notes.FirstOrDefault(x=>x.UserId == id);
           
            var note = new NoteModel();
            note.Title = result.Title;
            note.Content = result.Content;
            note.CreatedDate = result.CreatedDate;
            note.ModifiedDate = result.ModifiedDate;
            return note;
        }
    }
}
