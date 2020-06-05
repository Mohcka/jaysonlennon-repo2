using Microsoft.AspNetCore.Mvc;
using System;

namespace AptMgmtPortalAPI.DTO
{
    public class ErrorBuilder
    {
        private int _statusCode;
        private string _message;

        public ErrorBuilder Message(string message)
        {
            this._message = message;
            return this;
        }

        public ErrorBuilder Code(int statusCode)
        {
            this._statusCode = statusCode;
            return this;
        }

        public ObjectResult Build()
        {
            var error = new Error();
            error.Message = String.IsNullOrEmpty(this._message) ? "An error has occurred" : this._message;

            var result = new ObjectResult(error);
            result.StatusCode = this._statusCode >= 100 ? this._statusCode : 400;

            return result;
        }
    }

    public class Error
    {
        public string Message { get; set; }
    }
}