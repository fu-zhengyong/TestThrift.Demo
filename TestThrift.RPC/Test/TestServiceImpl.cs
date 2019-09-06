using System;
using System.Collections.Generic;
using System.Text;
using TestThrift.Contracts.Test;

namespace TestThrift.RPC.Test
{
    public class TestServiceImpl:TestService.Iface
    {
        public TrxnResult Save(TrxnRecord trxn)
        {
            Console.WriteLine("Log : TrxnName:{0}, TrxnAmount:{1}, Remark:{2}", trxn.TrxnName, trxn.TrxnAmount, trxn.Remark);
            return TrxnResult.SUCCESS;
        }
    }
}
