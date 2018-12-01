using System;

namespace Blog.Business.Exceptions
{
    public class BusinessExceptionType
    {
        public BusinessExceptionType(string exceptionCode, string defaultMessage)
        {
            ExceptionCode = exceptionCode;
            DefaultMessage = defaultMessage;
        }

        public string ExceptionCode { get; set; }
        public string DefaultMessage { get; set; }
    }

    public class BusinessException : Exception
    {
        public BusinessException(BusinessExceptionType exceptionType, Exception baseException)
        {
            ExceptionType = exceptionType;
            BaseException = baseException;
        }

        public BusinessExceptionType ExceptionType { get; set; }
        public Exception BaseException { get; set; }
    }
}
