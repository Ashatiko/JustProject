using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public T? Data { get; set; }

        public T AdditionalData { get; set; }
    }

    public interface IBaseResponse<T>
    {
        T Data { get;}
        T AdditionalData { get; }
    }
}
