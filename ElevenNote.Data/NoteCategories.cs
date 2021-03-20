using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class NoteCategories
    {
        [ForeignKey(nameof(Note))]
        public int NoteID;
        [ForeignKey(nameof(Categories))]
        public int CategoryID;
    }
}
