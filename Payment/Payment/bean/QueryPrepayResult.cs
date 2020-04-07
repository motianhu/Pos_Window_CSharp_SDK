using System;

namespace PaymentSDK.bean
{
    public class QueryPrepayResult
    {
        //预付订单id
        private String prepayId;
        private Double totalAmount;
        private int tradeState;
        private String errorMsg;
        private Double amount;

        private String paySerialId;
        private String tradeDate;

        private String mchName;
        private String outTradeNo;
        private Double discountAmount;  //折扣金额
        private String mchId;  //商户id
        private String walletId;//用户钱包id

        public string PrepayId { get => prepayId; set => prepayId = value; }
        public double TotalAmount { get => totalAmount; set => totalAmount = value; }
        public int TradeState { get => tradeState; set => tradeState = value; }
        public string ErrorMsg { get => errorMsg; set => errorMsg = value; }
        public double Amount { get => amount; set => amount = value; }
        public string PaySerialId { get => paySerialId; set => paySerialId = value; }
        public string TradeDate { get => tradeDate; set => tradeDate = value; }
        public string MchName { get => mchName; set => mchName = value; }
        public string OutTradeNo { get => outTradeNo; set => outTradeNo = value; }
        public double DiscountAmount { get => discountAmount; set => discountAmount = value; }
        public string MchId { get => mchId; set => mchId = value; }
        public string WalletId { get => walletId; set => walletId = value; }

        public PayResultBean toPayResult()
        {
            PayResultBean payResultBean = new PayResultBean();
            payResultBean.PrepayId = PrepayId;
            payResultBean.PaySerialId = PaySerialId;
            payResultBean.Amount = Amount;
            payResultBean.TotalAmount = TotalAmount;
            payResultBean.DiscountAmount = DiscountAmount;
            payResultBean.TradeState = TradeState;
            payResultBean.TradeDate = TradeDate;
            payResultBean.MchName = MchName;
            payResultBean.OutTradeNo = OutTradeNo;
            payResultBean.MchId = MchId;
            payResultBean.WalletId = WalletId;
            return payResultBean;
        }
    }
}
