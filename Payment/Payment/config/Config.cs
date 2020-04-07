using System;

namespace PaymentSDK.config
{
    class Config
    {

        /*
         *
         */
        public static String HOST = "https://wallet-sit.evergrande.cn:8088";
        public static String B_2_C_PREPAY = "/hpay-walletpay/walletSdk/offLinePayOrder";
        public static String C_2_B_PREPAY = "/hpay-walletpay/walletSdk/prePaymentOrder";

        public static String QUERY_PREPAY = "/hpay-walletpay/walletSdkQuery/cashierQueryOrder?prepayId=";
        public static String REVODE_ORDER = "/hpay-walletpay/walletSdk/revokeOrder";
        public static String REFUND_ORDER = "/hpay-walletpay/walletSdk/refundOrder";
    }
}
