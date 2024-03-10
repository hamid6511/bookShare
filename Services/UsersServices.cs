using bookShare.Database;
using bookShare.Database.Data;
using bookShare.Database.DTO;
using Microsoft.AspNetCore.Mvc;

namespace bookShare.Services
{
    public class UsersServices
    {
        private AppDbContext _context;

        public UsersServices(AppDbContext context)
        {
            _context = context; 
        }

        public Users UpdateUserById(Guid userId, [FromBody]UserDto user)
        {
           var userNew = _context.users.FirstOrDefault(x => x.UserId == userId);
            if (user is not null) 
            { 
                userNew.Name = user.Name;
                userNew.Email = user.Email;
                userNew.Password = user.Password;
                _context.SaveChanges();
            }
            return userNew;
        }
        public List<UserDto> GetAllUsers() 
        {
            var users = new List<UserDto>();
            return users;
        }
        public Users GetUserById(Guid userId)
        {
            var user = _context.users.FirstOrDefault(x => x.UserId == userId);
            return user;
        }

        public void AddUser([FromBody]UserDto user)
        {
           var UserDto = new Users() 
           {
             Email = user.Email,
             Name = user.Name,
             Password = user.Password,
           };
            _context.users.Add(UserDto);
            _context.SaveChanges();
        }


        public void DeleteUserById(Guid id)
        {
            var user = _context.users.FirstOrDefault(c => c.UserId == id);
            if (user is not null)
            {
                _context.users.Remove(user);
                _context.SaveChanges();
            }
            
        }


    }
}
