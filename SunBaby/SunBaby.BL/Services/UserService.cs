using SunBaby.BL.Services.Abstract;
using SunBaby.DA.Models;
using SunBaby.DA.Repositories.Abstract;
using System;

namespace SunBaby.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser()
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Address = "TestAddress",
                Birthday = new DateTime(1994, 01, 05),
                FirstName = "TestName",
                LastName = "TestName2",
                Surname = "TestName3",
                PassportDate = new DateTime(2020, 05, 15),
                PassportNumber = "МС233333",
                Phone = "+375336360124",
                TelegramId = 111111111,
                FirstNameTelegram = "TGName1",
                LastNameTelegram = "TGName2",
                LoginTelegram = "TGName3"
            };

            _userRepository.CreateAsync(user);
        }
    }
}
