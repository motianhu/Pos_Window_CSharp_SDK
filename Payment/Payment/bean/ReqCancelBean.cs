using System;

namespace PaymentSDK.bean
{
    class ReqCancelBean : ReqSignBean
    {
        public String prepayId;
        public long timestamp;
    }
}
