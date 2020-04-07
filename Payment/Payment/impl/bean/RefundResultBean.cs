using System;

namespace PaymentSDK
{
    public class RefundResultBean
    {
        private Double amount;
        private String mchId;
        private String mchName;
        private String outTradeNo;
        private String paySerialId;
        private String tradeDate;
        private int tradeState;
        private String walletId;

        public double Amount { get => amount; set => amount = value; }
        public int TradeState { get => tradeState; set => tradeState = value; }
        public string PaySerialId { get => paySerialId; set => paySerialId = value; }
        public string TradeDate { get => tradeDate; set => tradeDate = value; }
        public string MchName { get => mchName; set => mchName = value; }
        public string OutTradeNo { get => outTradeNo; set => outTradeNo = value; }
        public string MchId { get => mchId; set => mchId = value; }
        public string WalletId { get => walletId; set => walletId = value; }
    }
}
