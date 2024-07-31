using ModelLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces.Notes
{
    public  interface IdeleteNoteRL
    {
        NoteModel deleteSelectedNote(int id, bool isArchive);
    }
}
