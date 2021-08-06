using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KegelFreundeHorw.Models.Domain;

namespace KegelFreundeHorw.DataAccess
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ApplicationDbContext _context;

        public MemberRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddMember(Member member)
        {
            _context.Add(member);
            _context.SaveChanges();
        }

        public void DeleteMember(int id)
        {
            _context.Remove(GetMemberById(id));
            _context.SaveChanges();
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _context.Members;
        }

        public Member GetMemberById(int id)
        {
            var member = _context.Members.Find(id);
            if (member != null)
                return member;
            throw new Exception("Ein Foto mit der Id " + id + " existiert nicht.");
        }

        public void UpdateMember(Member newMember)
        {
            var oldMember = GetMemberById(newMember.Id);

            oldMember = newMember;
            _context.SaveChanges();
        }
    }
}
