using Common.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contract.Messaging
{
    public class AddOrganizationReq : Req
    {
        public long UserId { get; set; }
        public string OrganizationName { get; set; }
    }
}
