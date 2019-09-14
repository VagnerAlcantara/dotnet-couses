using SpaUserControl.Domain.Contracts.Repositories;
using System;
using SpaUserControl.Domain.Models;
using SpaUserControl.Common.Validation;
using SpaUserControl.Common.Resources;

namespace SpaUserControl.Business.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repositoty;

        public UserService(IUserRepository repository)
        {
            _repositoty = repository;
        }
        public User Authenticate(string email, string password)
        {
            var user = _repositoty.Get(email);

            if (user.Password != PasswordAssertionConcern.Encrypt(password))
                throw new Exception(Errors.InvalidCredentials);

            return user;
        }

        public void ChangeInformation(string email, string name)
        {
            var user = _repositoty.Get(email);

            user.ChangeName(name);
            user.Validate();

            _repositoty.Update(user);
        }

        public void ChangePassword(string email, string password, string newPassword, string confirmNewPassword)
        {
            var user = Authenticate(email, password);

            user.SetPassword(password, confirmNewPassword);
            user.Validate();

            _repositoty.Update(user);
        }

        public User GetByEmail(string email)
        {
            var user = _repositoty.Get(email);

            if (user == null)
                throw new Exception(Errors.UserNotFound);

            return user;
        }

        public void Register(string name, string email, string password, string confirmPassword)
        {
            var hasUser = _repositoty.Get(email);

            if (hasUser != null)
                throw new Exception(Errors.DuplicateEmail);

            var user = new User(name, email);
            user.SetPassword(password, confirmPassword);
            user.Validate();

            _repositoty.Create(user);
        }

        public string ResetPassword(string email)
        {
            var user = _repositoty.Get(email);

            string password = user.ResetPassword();
            user.Validate();
            _repositoty.Update(user);

            return password;
        }

        public void Dispose()
        {
            _repositoty.Dispose();
        }
    }
}
