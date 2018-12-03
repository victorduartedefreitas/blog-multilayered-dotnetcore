using System;

namespace Blog.Business.Exceptions
{
    public class PostException : BusinessException
    {
        public PostException(PostExceptionType exceptionType)
            : this(exceptionType, null)
        {
        }

        public PostException(PostExceptionType exceptionType, Exception baseException)
            : base(exceptionType, baseException)
        {
        }
    }

    public class PostExceptionType : BusinessExceptionType
    {
        public static PostExceptionType DefaultException
            = new PostExceptionType("001.000", "Verifique a propriedade 'BaseException' para maiores detalhes.");

        public static PostExceptionType NullObject
            = new PostExceptionType("001.001", "Objeto 'post' não pode ser nulo.");

        public static PostExceptionType NullUserId
            = new PostExceptionType("001.002", "UserId não pode ser nulo.");

        public static PostExceptionType NullTitle
            = new PostExceptionType("001.003", "Título do post não pode ser nulo.");

        public static PostExceptionType NullBody
            = new PostExceptionType("001.004", "Corpo do post não pode ser nulo.");

        public static PostExceptionType NullPostId
            = new PostExceptionType("001.005", "PostId não pode ser nulo.");

        public static PostExceptionType NullPage
            = new PostExceptionType("001.006", "Número da página deve ser informado.");

        public PostExceptionType(string exceptionCode, string defaultMessage)
            : base(exceptionCode, defaultMessage)
        {
        }
    }
}
