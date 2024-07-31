using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Interfaces.LabelAction
{
    public interface ILabelBL
    {
        Task<IEnumerable<Label>> GetLabelsAsync(int userId);
        Task<IEnumerable<Note>> GetNoteByLabelIdAsync(int labelId, int UserId);
        Task<Label> AddLabelAsync(int userId, string name);
        Task<Label> UpdateLabelAsync(string name);
        Task<Label> DeleteLabelAsync(int labelId);

    }
}
