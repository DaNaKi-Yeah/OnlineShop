using System.Text.Json;

namespace OnlineShop.API.Responses
{
    public class Response<TValue> : BaseResponse
    {
        public Response(TValue value, int statusCode, string message, bool isSuccess) : base(statusCode, message, isSuccess)
        {
            Value = value;
        }

        public TValue Value { get; set; }
    }
}
