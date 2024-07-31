using ModelLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces.Notes
{
     public  interface IupdateNoteRL
    {
        Note updateNote (int id , CreateNote note);    
    }
}
