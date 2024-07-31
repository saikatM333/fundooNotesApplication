using BuisnessLayer.Interfaces.LabelAction;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces.LabelAction;
using RepositoryLayer.Services.LabelAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Services.LabelAction
{
    public  class LabelServicesBL : ILabelBL
    {
        private readonly Ilabel _labelServicesRL;

        public LabelServicesBL(Ilabel labelServicesRL)
        {
            _labelServicesRL = labelServicesRL;
        }

        public async Task<IEnumerable<Label>> GetLabelsAsync(int userId)
        {
            var  labels = await _labelServicesRL.GetLabelsAsync(userId);
            return labels;
        }
        public async Task<IEnumerable<Note>> GetNoteByLabelIdAsync(int labelId, int userId)
        {
            var  notes = await  _labelServicesRL.GetNoteByLabelIdAsync(labelId, userId);
            return notes;
        }
        public async Task<Label> AddLabelAsync(int userId, string name)
        {
           var label = await _labelServicesRL.AddLabelAsync(userId, name);
            return label;

        }
        public async Task<Label> UpdateLabelAsync(string name)
        {
            
            var label = await _labelServicesRL.UpdateLabelAsync(name);
            return label;
        }
        public async Task<Label> DeleteLabelAsync(int labelId)
        {
            Label label = await _labelServicesRL.DeleteLabelAsync(labelId);
            return label;

            
        }
    }
}
