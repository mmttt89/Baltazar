using System;
namespace Baltazar.Infra.Common.DTOs
{
    public class ErrorResponse : ApiResponse<object>
    {
        public ErrorResponse(string message, int statusCode = 400)
        {
            IsSuccess = false;
            Message = message;
            StatusCode = statusCode;
        }
    }
}

