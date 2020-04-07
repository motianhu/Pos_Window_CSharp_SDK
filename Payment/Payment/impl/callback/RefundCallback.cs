using System;

namespace PaymentSDK
{
    public interface RefundCallback : CommonCallback
    {
        /**
         * 退款成功
         * */
        void onSuccess(RefundResultBean payResultBean);
    }
}
