using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.FundooDbContext;
using RepositoryLayer.Interfaces.LabelAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace RepositoryLayer.Services.LabelAction
{
    public  class LabelServicesRL: Ilabel
    {   private readonly FundooNotesDBContext _dbContext;
        private readonly IConfiguration _configuration;

        public LabelServicesRL(FundooNotesDBContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public async Task<IEnumerable<Label>> GetLabelsAsync(int userId)
        {
            IEnumerable<Label> labels =  _dbContext.Labels.Where(x => x.UserId == userId);
            return labels;
        }
        public async Task<IEnumerable<Note>> GetNoteByLabelIdAsync(int labelId , int userId  )
        {
             IEnumerable<Note> notes  = _dbContext.Notes
                            .Where(n => n.UserId == userId && n.Labels.Any(l => l.LabelId == labelId))
                            .ToList();
            return notes;
        }
        public async  Task<Label> AddLabelAsync(int userId , string name )
        {
             Label label = new Label();
             label.UserId = userId;
             label.Name = name;
             
             _dbContext.Labels.Add(label);
             _dbContext.SaveChangesAsync();
             return label;

        }
        public async  Task<Label> UpdateLabelAsync(string name )
        {
            Label label = _dbContext.Labels.FirstOrDefault(x => x.Name == name);
            label.Name = name;
            _dbContext.Entry(label).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return label;
        }
        public async Task<Label> DeleteLabelAsync(int labelId)
        {
            Label label = _dbContext.Labels.FirstOrDefault(x => x.LabelId == labelId);

            if (label != null)
            {
                return null;
            }
            else
            {
                _dbContext.Remove(label);
                _dbContext.SaveChangesAsync();
                return label;

            }
        }
    }
}
