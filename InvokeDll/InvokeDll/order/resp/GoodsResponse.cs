using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvokeDll.order.resp
{
    public class GoodsResponse
    {

            public String code;
            public String message;
            public OrderNo data;

            public string Code { get => code; set => code = value; }
            public string Message { get => message; set => message = value; }
            public OrderNo Data { get => data; set => data = value; }
      
      
    }
}
