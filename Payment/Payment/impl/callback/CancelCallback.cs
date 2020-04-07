using System;

namespace PaymentSDK
{
    public interface CancelCallback : CommonCallback
    {
        /**
         * 撤销成功
         * */
        void onSuccess(PayResultBean payResultBean);
    }
}
