using System;

namespace Blog.Business.Exceptions
{
    public class UserException : BusinessException
    {
        public static UserExceptionType DefaultException
            = new UserExceptionType("001.000", "Verifique a propriedade 'BaseException' para maiores detalhes.");

        public static UserExceptionType NullUserName
            = new UserExceptionType("001.001", "UserName não pode ser nulo.");

        public static UserExceptionType NullName
            = new UserExceptionType("001.002", "Nome não pode ser nulo.");

        public static UserExceptionType NullEmail
            = new UserExceptionType("001.003", "Email não pode ser nulo.");

        public static UserExceptionType NullUserId
            = new UserExceptionType("001.004", "UserId deve ser maior que 0.");

        public static UserExceptionType NullObject
            = new UserExceptionType("001.005", "Objeto 'user' não pode ser nulo.");

        public UserException(UserExceptionType exceptionType)
            : this(exceptionType, null)
        {
        }

        public UserException(UserExceptionType exceptionType, Exception baseException)
            : base(exceptionType, baseException)
        {
        }
    }

    public class UserExceptionType : BusinessExceptionType
    {
        public UserExceptionType(string exceptionCode, string defaultMessage)
            : base(exceptionCode, defaultMessage)
        {
        }
    }
}
