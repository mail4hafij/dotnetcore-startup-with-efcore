using Common.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contract.Messaging
{
    public class GetUserReq : Req
    {
        public string Email { get; set; }
    }
}
