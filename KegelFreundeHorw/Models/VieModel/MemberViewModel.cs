using KegelFreundeHorw.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KegelFreundeHorw.Models.Domain;

namespace KegelFreundeHorw.Models.VieModel
{
    public class MemberViewModel
    {
        public Member Member { get; set; }
        public List<Member> MemberList { get; set; }
    }
}
