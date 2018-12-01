﻿namespace Blog.Business.Model
{
    public class OperationResult
    {
        public OperationResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
