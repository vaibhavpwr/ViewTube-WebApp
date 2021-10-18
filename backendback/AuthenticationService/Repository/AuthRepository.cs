using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.Models;
namespace AuthenticationService.Repository
{
    //Inherit the respective interface and implement the methods in 
    // this class i.e AuthRepository by inheriting IAuthRepository class 
    //which is used to implement all methods in the classs.
    public class AuthRepository : IAuthRepository
    {
        //Define a private variable to represent AuthDbContext
        AuthDbContext _dbContext;
        public AuthRepository(AuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /* Implement all the methods of respective interface asynchronously*/

        //Implement the method  'CreateUser' which is used to create a new user.
        public bool CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            var added =_dbContext.SaveChanges();
            return added > 0;
        }
        //Implement the method  'IsUserExists' which is used to check userId exist or not.
        public bool IsUserExists(string userId)
        {
            return _dbContext.Users.Any(u => u.UserId == userId);
        }
        //Implement the method 'LoginUser' which is used to login for the existing user.
        public bool LoginUser(User user)
        {
            return _dbContext.Users.Any(u => (u.UserId == user.UserId) && (u.Password == user.Password));
        }
    }
}
