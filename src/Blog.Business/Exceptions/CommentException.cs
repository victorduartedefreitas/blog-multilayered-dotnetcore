using System;

namespace Blog.Business.Exceptions
{
    public class CommentException : BusinessException
    {
        public CommentException(CommentExceptionType exceptionType)
            : this(exceptionType, null)
        {
        }

        public CommentException(CommentExceptionType exceptionType, Exception baseException)
            : base(exceptionType, baseException)
        {
        }
    }

    public class CommentExceptionType : BusinessExceptionType
    {
        public static CommentExceptionType DefaultException
            = new CommentExceptionType("001.000", "Verifique a propriedade 'BaseException' para maiores detalhes.");

        public static CommentExceptionType NullObject
            = new CommentExceptionType("001.001", "Objeto 'comment' não pode ser nulo.");

        public static CommentExceptionType NullCommentId
            = new CommentExceptionType("001.002", "CommentId não pode ser nulo.");

        public static CommentExceptionType NullPostId
            = new CommentExceptionType("001.003", "PostId não pode ser nulo.");

        public static CommentExceptionType NullName
            = new CommentExceptionType("001.004", "Nome não pode ser nulo.");

        public static CommentExceptionType NullEmail
            = new CommentExceptionType("001.005", "Email não pode ser nulo.");

        public static CommentExceptionType NullBody
            = new CommentExceptionType("001.006", "Corpo do comentário não pode ser nulo.");

        public CommentExceptionType(string exceptionCode, string defaultMessage)
            : base(exceptionCode, defaultMessage)
        {
        }
    }
}
