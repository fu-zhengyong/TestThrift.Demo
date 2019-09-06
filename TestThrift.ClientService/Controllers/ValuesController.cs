using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestThrift.Contracts.Test;
using Thrift.Protocol;
using Thrift.Transport;

namespace TestThrift.ClientService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            // RPC - use Thrift
            using (TTransport transport = new TSocket("192.168.0.92", 8885))
            {
                using (TProtocol protocol = new TBinaryProtocol(transport))
                {
                    using (var serviceClient = new TestService.Client(protocol))
                    {
                        transport.Open();
                        TrxnRecord record = new TrxnRecord
                        {
                            TrxnId = 10000001,
                            TrxnName = "fxy",
                            TrxnAmount = 12,
                            TrxnType = "MM",
                            Remark = "test rpc thrift"
                        };
                        var result = serviceClient.Save(record);

                        return Convert.ToInt32(result) == 0 ? "Trxn Success" : "Trxn Failed";
                    }
                }
            }

        }

       
    }
}
