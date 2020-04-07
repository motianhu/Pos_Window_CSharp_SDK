using System;

namespace PaymentSDK
{
    public enum CodeEnum
    {
        ORDER_STATE_PAYCANCEL = 1022, //取消支付
        ORDER_STATE_NOTPAY = 1, //订单未支付
        ORDER_STATE_SCANING = 2,//订单已扫码
        ORDER_STATE_USERPAYING = 3, //订单支付中
        ORDER_STATE_SUCCESS = 4, //订单支付成功
        ORDER_STATE_PAYERROR = 5, //订单支付错误
        ORDER_STATE_REVOKEING = 6, //订单撤销中
        ORDER_STATE_REVOKED = 7,//订单已撤销
        ORDER_STATE_REVOKERROR = 8,//订单撤销错误
        ORDER_STATE_REFUNDING = 9, //订单退款中
        ORDER_STATE_REFUND = 10, //订单已退款
        ORDER_STATE_REFUNDERROR = 11, //订单退款错误
        ORDER_STATE_CLOSED = 12,//订单已关闭
        ORDER_STATE_REFUNDALL = 13, //订单全额退款
        ORDER_STATE_REFUNDEX = 14, // 订单退款异常
        ORDER_STATE_G60009 = 60009 //订单已关闭
    }
}
