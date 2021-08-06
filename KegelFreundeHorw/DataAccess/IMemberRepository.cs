using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KegelFreundeHorw.Models.Domain;

namespace KegelFreundeHorw.DataAccess
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAllMembers();

        Member GetMemberById(int id);

        void DeleteMember(int id);

        void AddMember(Member photo);

        void UpdateMember(Member photo);

    }
}
