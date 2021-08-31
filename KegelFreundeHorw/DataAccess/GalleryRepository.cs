using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KegelFreundeHorw.Models.Domain;

namespace KegelFreundeHorw.DataAccess
{
    public class GalleryRepository : IGalleryRepository
    {
        private readonly ApplicationDbContext _context;

        public GalleryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPhotography(PhotoGraphy photoGraphy)
        {
            _context.Add(photoGraphy);
            _context.SaveChanges();
        }

        public void DeletePhotography(int id)
        {
            _context.Remove(GetPhotographyById(id));
            _context.SaveChanges();
        }

        public IEnumerable<PhotoGraphy> GetAllPhotographies()
        {
            return _context.PhotoGraphys;
        }

        public PhotoGraphy GetPhotographyById(int id)
        {
            var photography = _context.PhotoGraphys.Find(id);
            if (photography != null)
                return photography;
            throw new Exception("Ein Foto mit der Id " + id + " existiert nicht.");
        }

        public void UpdatePhotography(PhotoGraphy newPhotoGraphy)
        {
            var oldPhotography = GetPhotographyById(newPhotoGraphy.Id);

            oldPhotography = newPhotoGraphy;
            _context.SaveChanges();
        }
    }
}
