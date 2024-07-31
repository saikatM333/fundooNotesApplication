using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Interfaces.Notes
{
    public interface IupdateNotesBL
    {
        Note updateNote(int id, CreateNote note);
    }
}
