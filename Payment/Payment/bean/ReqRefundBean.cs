using System;

namespace PaymentSDK.bean
{
    class ReqRefundBean:ReqSignBean
    {
        public Decimal amount;
        public String notifyUrl;
        public String outTradeNo;
        public String paySerialId;
        public String payType;
        public long timestamp;
    }
}
