using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces.Notes
{
    public  interface INoteServicesRL
    {
        Task<Note> createNotes(int Userid, CreateNote note);
        Task<NoteModel> archvieveSelectedNote(int id, bool isArchive);
        Task<NoteModel> deleteSelectedNote(int id, bool isArchive);
        Task<Note> GetAllNotesById(int id);
        Task<NoteModel> PinnedSelectedNote(int id, bool isPinned);
        Task<Note> updateNote(int id, CreateNote note);
    }
}
