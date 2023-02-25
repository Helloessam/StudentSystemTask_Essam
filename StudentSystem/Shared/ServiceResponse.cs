using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Shared
{
    //Generic or general form class of type T aka Type Parameter 
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }=true;
        public string Message { get; set; } = string.Empty;
    }
}
