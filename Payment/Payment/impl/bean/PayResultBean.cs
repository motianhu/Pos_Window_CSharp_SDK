using System;

namespace PaymentSDK
{
    public class PayResultBean
    {
        private String prepayId;
        private Double amount;
        private Double totalAmount;
        private int tradeState;
        private String paySerialId;
        private String tradeDate;
        private String mchName;
        private String outTradeNo;
        private String sign;
        private String mchId;
        private String walletId;
        private Double discountAmount;  //折扣金额
        private String payInfo;

        public string PrepayId { get => prepayId; set => prepayId = value; }
        public double Amount { get => amount; set => amount = value; }
        public double TotalAmount { get => totalAmount; set => totalAmount = value; }
        public int TradeState { get => tradeState; set => tradeState = value; }
        public string PaySerialId { get => paySerialId; set => paySerialId = value; }
        public string TradeDate { get => tradeDate; set => tradeDate = value; }
        public string MchName { get => mchName; set => mchName = value; }
        public string OutTradeNo { get => outTradeNo; set => outTradeNo = value; }
        public string Sign { get => sign; set => sign = value; }
        public string MchId { get => mchId; set => mchId = value; }
        public string WalletId { get => walletId; set => walletId = value; }
        public double DiscountAmount { get => discountAmount; set => discountAmount = value; }
        public String PayInfo { get => payInfo; set => payInfo = value; }
    }
}
