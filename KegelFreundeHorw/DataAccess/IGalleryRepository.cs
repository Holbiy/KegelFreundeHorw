using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KegelFreundeHorw.DataAccess
{
    public interface IGalleryRepository
    {
        IEnumerable<Photography> GetAllPhotographies();

        Photography GetPhotographyById(int id);

        void DeletePhotography(int id);

        void AddPhotography(Photography photo);

        void UpdatePhotography(Photography photo);

    }
}
