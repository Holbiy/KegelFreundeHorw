using KegelFreundeHorw.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KegelFreundeHorw.Models.VieModel
{
    public class GalleryViewModel
    {
        public Photography photoGraphy { get; set; }
        public List<Photography> photoGraphyList { get; set; }
    }
}
