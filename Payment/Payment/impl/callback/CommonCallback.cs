using System;

namespace PaymentSDK
{
    /**
     * 支付、撤单回调及对应的Bean
     * */
    public interface CommonCallback
    {
        /**
         * 接口调用失败。code为错误码，errMsg为错误信息
         * */
        void onFailed(String code, String errMsg);
    }
}
