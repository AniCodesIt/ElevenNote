using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoriesService
    {
        //Add Categories to a note
        private readonly Guid _userId;
        public CategoriesService(Guid userId)
        {
            _userId = userId;
        }
        public bool AddCategoriesToNote(NoteCategoriesCreate model)
        {
            var entity =
                new NoteCategories()
                {
                    NoteID = model.NoteID,
                    CategoryID = model.CategoryID,                   
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.NoteCategories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CategoriesListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Categories                      
                        .Select(
                            e =>
                                new CategoriesListItem
                                {
                                    CategoryID = e.CategoryID,
                                    CategoryName = e.CategoryName,
                                                                 }
                        );

                return query.ToArray();
            }

        }
        //Delete categories from a note

        public bool DeleteCategoriesFromNote(NoteCategoriesEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .NoteCategories
                        .Single(e => e.NoteID == model.NoteID && e.CategoryID == model.CategoryID);

                ctx.NoteCategories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }

        }
    }
}