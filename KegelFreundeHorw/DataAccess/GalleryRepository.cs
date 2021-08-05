using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KegelFreundeHorw.DataAccess
{
    public class GalleryRepository : IGalleryRepository
    {
        private readonly ApplicationDbContext _context;

        public GalleryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPhotography(Photography photography)
        {
            _context.Add(photography);
            _context.SaveChanges();
        }

        public void DeletePhotography(int id)
        {
            _context.Remove(GetPhotographyById(id));
            _context.SaveChanges();
        }

        public IEnumerable<Photography> GetAllPhotographies()
        {
            return _context.PhotoGraphys;
        }

        public Photography GetPhotographyById(int id)
        {
            var photography = _context.PhotoGraphys.Find(id);
            if (photography != null)
                return photography;
            throw new Exception("Ein Foto mit der Id " + id + " existiert nicht.");
        }

        public void UpdatePhotography(Photography newPhotography)
        {
            var oldPhotography = GetPhotographyById(newPhotography.Id);

            oldPhotography = newPhotography;
            _context.SaveChanges();
        }
    }
}
