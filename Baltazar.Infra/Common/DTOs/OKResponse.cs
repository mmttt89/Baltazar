using System;
namespace Baltazar.Infra.Common.DTOs
{
	public class OkResponse<T> : ApiResponse<T>
	{
        public OkResponse(T data)
        {
            Data = data;
            IsSuccess = true;
            StatusCode = 200; // OK status code
        }
    }
}


