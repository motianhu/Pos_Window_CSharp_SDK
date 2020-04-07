using System;

namespace PaymentSDK
{
    interface IPayment
    {

        /**
         * 环境切换.默认生产环境,环境值
         */
        void setDebug(int env);

        /**
         * 支付初始化，必须在所有接口之前
         * */
        void init(String mchId,  //商户ID.必填
                  String mchKey  //商户秘钥.必填
            );

        /*==========================================B扫C===================================================================*/
        /**
         * B扫C
         * 功能描述：商家持扫码枪扫客户的二维码。响应关注tradeState和prepayId字段
         * */
        void prePayment(String qrCode,           //用户出示的二维码信息，必填
                        String mchName,          //商户名称，可选
                        String formatNumber,     //业态id，必填
                        String formatName,       //业态名称，可选
                        String storeNumber,      //店铺号，必填
                        String storeName,        //店铺名称，可选
                        String sourceCode,       //来源系统，必填
                        String subject,          //商品标题，必填
                        String goodsDetail,      //商品明细，可选
                        String orderId,          //销售订单号，必填
                        Decimal totalAmount,     //总金额 ，必填
                        Decimal amount,          //金额 ，必填
                        Decimal discountAmount,  //打折金额 ，必填
                        String desc,             //订单描述，可选
                        String notifyUrl,        //订单回调URL，可选
                        PayCallback payCallback  ///支付结果回调，必填
            );

        /*==========================================C扫B===================================================================*/
        /**
         * 获取预支付信息
         * 功能描述：客户扫商家的二维码。响应关注payInfo和prepayId字段
         * */
        void prePayment(String mchName,          //商户名称，可选
                        String formatNumber,     //业态id，必填
                        String formatName,       //业态名称，可选
                        String storeNumber,      //店铺号，必填
                        String storeName,        //店铺名称，可选
                        String sourceCode,       //来源系统，必填
                        String subject,          //商品标题，必填
                        String goodsDetail,      //商品明细，可选
                        String orderId,          //销售订单号，必填
                        Decimal totalAmount,     //总金额 ，必填
                        Decimal amount,          //金额 ，必填
                        Decimal discountAmount,  //打折金额 ，必填
                        String desc,             //订单描述，可选
                        String notifyUrl,        //订单回调URL，可选
                        PayCallback payCallback  ///支付结果回调，必填
            );

        /**
         * 查询支付结果
         * 功能描述：prePayment接口拿到prepayId字段，即可查询。响应关注tradeState字段
         * */
        void queryPayResult(String prepayId,      //预支付，必填
                            PayCallback payCallback  //查询结果回调，必填
            );

        /*==========================================撤单与退款===================================================================*/
        /**
         * 撤单接口
         * 功能描述：商家下支付单后但用户不支付(只针对大额，小额prePayment接口直接扣款了，需要走退款接口)
         * */
        void cancelPayment(String prepayId,         //预支付，必填
                           CancelCallback payCallback  //取消结果回调，必填
            );

        /**
       * 退款接口
       * 功能描述：商家退款，退款金额不可大于B扫C接口中的amount字段值。outTradeNo和paySerialId均来自prePayment回调函数onSuccess，调用方需自行保存。
       * */
        void refund(Decimal amount, //退款金额，必填
                    String notifyUrl, //后台退款成功回调地址，选填
                    String outTradeNo, //交易号，必填
                    String paySerialId, //支付流水号，必填
                    RefundCallback payCallback ///退款结果回调，必填
            );
    }
}
