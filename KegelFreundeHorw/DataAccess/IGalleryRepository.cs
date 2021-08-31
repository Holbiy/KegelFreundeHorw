using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KegelFreundeHorw.Models.Domain;

namespace KegelFreundeHorw.DataAccess
{
    public interface IGalleryRepository
    {
        IEnumerable<PhotoGraphy> GetAllPhotographies();

        PhotoGraphy GetPhotographyById(int id);

        void DeletePhotography(int id);

        void AddPhotography(PhotoGraphy photo);

        void UpdatePhotography(PhotoGraphy photo);

    }
}
