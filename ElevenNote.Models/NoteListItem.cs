﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class NoteListItem
    {
        [Key]
        public int CategoryID { get; set; }
        [MinLength(2, ErrorMessage = "Please enter at east 2 characters. ")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field. ")]
        public string CategoryName { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public int NoteId { get; set; }
        public string Title { get; set; }
    }
}
