using ModelLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Interfaces.Notes
{
    public interface IpinnedNoteBL
    {
        NoteModel PinnedSelectedNote(int id, bool isPinned);
    }
}
