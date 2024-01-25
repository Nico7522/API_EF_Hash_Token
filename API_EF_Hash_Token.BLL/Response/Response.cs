using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_EF_Hash_Token.BLL.Response
{
    public class Response<T>
    {
        public string Message { get; init; }
        public T? record { get; init; }


        public Response(string message)
        {
            this.Message = message;
        }
        public Response(T? record, string message)
            : this(message)
        {
            this.record = record;
        }

     

        public static Response<T> IsSuccess<T>(T? record, string message = "")
        {
          
            return new Response<T>(record, message);
        }

        public static Response<T> IsFailed(string message)
        {
            return new Response<T>(message);
        }

    }
}
