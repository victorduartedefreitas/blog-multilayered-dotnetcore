using Blog.Business.Exceptions;
using Blog.Business.Model;
using Blog.Business.Services;
using Blog.Data.Model;
using Blog.Data.Repository;
using System;

namespace Blog.Business.Components.Services
{
    public class UserService : IUserService
    {
        #region Locals

        private IUserRepository _userRepository;

        #endregion

        #region Constructors

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region IUserService Implementations

        public OperationResult CreateNewUser(User user)
        {
            if (user == null)
                throw new UserException(UserExceptionType.NullObject);
            else if (string.IsNullOrWhiteSpace(user.Name))
                throw new UserException(UserExceptionType.NullName);
            else if (string.IsNullOrWhiteSpace(user.UserName))
                throw new UserException(UserExceptionType.NullUserName);
            else if (string.IsNullOrWhiteSpace(user.Email))
                throw new UserException(UserExceptionType.NullEmail);

            try
            {
                var result = _userRepository.Save(user);
                return new OperationResult(result, string.Empty);
            }
            catch (Exception ex)
            {
                throw new UserException(UserExceptionType.DefaultException, ex);
            }
        }

        public OperationResult DeleteUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new UserException(UserExceptionType.NullEmail);

            try
            {
                var user = _userRepository.GetUser(email);
                if (user == null)
                    return new OperationResult(false, "Não foi possível encontrar um usuário com este email.");

                var result = _userRepository.Delete(user.UserId);
                return new OperationResult(result, string.Empty);
            }
            catch (Exception ex)
            {
                throw new UserException(UserExceptionType.DefaultException, ex);
            }
        }

        public OperationResult DeleteUserByUserId(int userId)
        {
            if (userId <= 0)
                throw new UserException(UserExceptionType.NullUserId);

            try
            {
                var result = _userRepository.Delete(userId);
                return new OperationResult(result, string.Empty);
            }
            catch (Exception ex)
            {
                throw new UserException(UserExceptionType.DefaultException, ex);
            }
        }

        public UserOperationResult GetUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new UserException(UserExceptionType.NullEmail);

            try
            {
                var user = _userRepository.GetUser(email);
                if (user == null)
                    return new UserOperationResult(false, "Não foi possível encontrar um usuário com este email", null);

                return new UserOperationResult(true, string.Empty, user);
            }
            catch (Exception ex)
            {
                throw new UserException(UserExceptionType.DefaultException, ex);
            }
        }

        public UserOperationResult GetUserByUserId(int userId)
        {
            if (userId <= 0)
                throw new UserException(UserExceptionType.NullUserId);

            try
            {
                var user = _userRepository.GetUser(userId);
                if (user == null)
                    return new UserOperationResult(false, "Não foi possível encontrar um usuário com este userId", null);

                return new UserOperationResult(true, string.Empty, user);
            }
            catch (Exception ex)
            {
                throw new UserException(UserExceptionType.DefaultException, ex);
            }
        }

        public OperationResult UpdateUser(User user)
        {
            if (user == null)
                throw new UserException(UserExceptionType.NullObject);
            else if (string.IsNullOrWhiteSpace(user.Name))
                throw new UserException(UserExceptionType.NullName);
            else if (string.IsNullOrWhiteSpace(user.UserName))
                throw new UserException(UserExceptionType.NullUserName);
            else if (string.IsNullOrWhiteSpace(user.Email))
                throw new UserException(UserExceptionType.NullEmail);

            try
            {
                var result = _userRepository.Save(user);
                return new OperationResult(result, string.Empty);
            }
            catch (Exception ex)
            {
                throw new UserException(UserExceptionType.DefaultException, ex);
            }
        }

        #endregion
    }
}
