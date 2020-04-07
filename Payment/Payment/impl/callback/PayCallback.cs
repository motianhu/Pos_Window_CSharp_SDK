using System;

namespace PaymentSDK
{
    public interface PayCallback : CommonCallback
    {
        /**
         * 交易结束。可能成功，可能取消订单，可能其他原因导致交易结束
         * */
        void onSuccess(PayResultBean payResultBean);
        /**
         * 获取到预支付单号(调用方需在撤单时使用此单号)
         * */
        void onPrepayId(String prepayId);
    }
}
