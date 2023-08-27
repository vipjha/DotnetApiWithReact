using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core
{
    public class AppExecption
    {
        public AppExecption(int statuCode, string message, string details = null)
        {
            StatuCode = statuCode;
            Message = message;
            Details = details;
        }

        public int StatuCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}
