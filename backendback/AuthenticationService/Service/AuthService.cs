using AuthenticationService.Exceptions;
using AuthenticationService.Models;
using AuthenticationService.Repository;
using System;

namespace AuthenticationService.Service
{
    //Inherit the respective interface and implement the methods in 
    // this class i.e AuthService by inheriting IAuthService class 
    //which is used to implement all methods in the classs.
    public class AuthService : IAuthService
    {
        //define a private variable to represent repository

        //Use constructor Injection to inject all required dependencies.
        IAuthRepository authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }
        //Implement the method 'LoginUser' which is used to login existing user and also handle the Custom Exception 
        public bool LoginUser(User user)
        {
            if(authRepository.LoginUser(user))
            {
                return true;
            }
            else
            {
                throw new UnauthorizedAccessException("Invalid user id or password");
            }
        }


        /* Implement all the methods of respective interface asynchronously*/

        //Implement the method  'RegisterUser' which is used to register a new user and 
        // handle the Custom Exception for UserAlreadyExistsException
        public bool RegisterUser(User user)
        {
            var currentUser = authRepository.IsUserExists(user.UserId);
            if(!currentUser)
            {
                return authRepository.CreateUser(user);
            }
            else
            {
                throw new UserAlreadyExistsException($"This userId {user.UserId} already in use");
            }
        }

        

    }
}
