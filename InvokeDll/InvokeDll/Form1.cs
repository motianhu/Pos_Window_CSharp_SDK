using System;
using System.Management;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvokeDll.order;
using InvokeDll.order.resp;
using PaymentSDK;

namespace InvokeDll
{
    public partial class Form1 : Form
    {
        Payment pay = new Payment();
        static String curPrepayId;
        static PayResultBean lastPayResultInfo;

        static String logStr;

        public Form1()
        {
            InitializeComponent();
            pay.init("Y100", "ticketVTXwqOGwrYvq9PT1UjhhAm1ve4");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logStr += "点击了B扫C下单" + "\r\n";
            writeLog();
            prepayment(qrCodeTb.Text, new BScanCResult());
            writeLog();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            logStr +=  "点击了C扫B下单" + "\r\n";
            writeLog();
            prepayment(null, new CScanBResult());
            writeLog();
        }

        private void highPriceBt_Click(object sender, EventArgs e)
        {
            logStr += "点击了获取销售订单" + "\r\n";
            writeLog();
            macAddressLb.Text = GetNetworkAdpaterID();
            orderNoLb.Text = "";

            SaveOrder saveOrder = new SaveOrder();
            GoodsResponse goods = saveOrder.requestOrder();
            if ("00000".Equals(goods.code))
            {
                orderNoLb.Text = goods.Data.orderNo;
                logStr += goods.Data.orderNo + "\r\n";
            }
            else
            {
                logStr += "code: " + goods.code + "\nerrMsg: " + goods.message + "\r\n";
            }
            
            writeLog();
        }


        private async void button2_Click(object sender, EventArgs e)
        {
            logStr += "点击了查询接口：curPrepayId=" + curPrepayId + "\r\n";
            writeLog();
            await Task.Run(() =>
            {
                pay.queryPayResult(curPrepayId, new QueryPayResult());
            });
            writeLog();
        }

        private async void cancelPrepayBt_Click(object sender, EventArgs e)
        {
            logStr += "点击了撤单：curPrepayId：" + curPrepayId + "\r\n";
            writeLog();
            if (String.IsNullOrEmpty(curPrepayId))
            {
                return;
            }
            await Task.Run(() =>
            {
                pay.cancelPayment(curPrepayId, new CancelCall());
            });
            writeLog();
        }

        private async void refundBt_Click(object sender, EventArgs e)
        {
            logStr += "点击了退款：lastPayResultInfo：" + lastPayResultInfo + "\r\n";
            writeLog();
            if (lastPayResultInfo == null)
            {
                return;
            }
            await Task.Run(() =>
            {
                pay.refund(new Decimal(10.01), null, lastPayResultInfo.OutTradeNo, lastPayResultInfo.PaySerialId, new RefundCall());
            });
            writeLog();
        }

        private async void prepayment(String qrCode, PayCallback callback)
        {
            if (String.IsNullOrEmpty(qrCode))
            {
                pay.prePayment("海洋王国",
                  "LYY0060001",
                  "海洋乐园",
                  "100046",
                  "冰雪乐园门店",
                  "test",
                  "海洋世界票务两张",
                  "海洋世界购票两张",
                  orderNoLb.Text,
                  Convert.ToDecimal(orderPriceTb.Text),
                  Convert.ToDecimal(orderPriceTb.Text),
                  new decimal(0.00),
                  "test",
                  "test",
                  callback);
            }
            else
            {
                pay.prePayment(qrCode, "海洋王国",
                  "LYY0060001",
                  "海洋乐园",
                  "100046",
                  "冰雪乐园门店",
                  "test",
                  "海洋世界票务两张",
                  "海洋世界购票两张",
                  orderNoLb.Text,
                  Convert.ToDecimal(orderPriceTb.Text),
                  Convert.ToDecimal(orderPriceTb.Text),
                  new decimal(0.00),
                  "test",
                  "test",
                  callback);
            };

            writeLog();
        }

        class BScanCResult : PayCallback
        {
            public void onSuccess(PayResultBean payResultBean)
            {
                logStr += "BScanCResult onSuccess result: " + "\r\n";
                logStr += "BScanCResult: " + payResultBean.PrepayId +", tradeState: " + payResultBean.TradeState + "\r\n";
                logStr += "BScanCResult onSuccess end: " + "\r\n";
                if (payResultBean.TradeState == (int)CodeEnum.ORDER_STATE_SUCCESS)
                {
                    lastPayResultInfo = payResultBean;
                }
            }

            public void onFailed(String code, String errMsg)
            {
                logStr += "BScanCResult onFailed code: " + code + "; errMsg: " + errMsg + "\r\n";
            }

            public void onPrepayId(String prepayId)
            {
                logStr += " BScanCResult 支付单号：" + prepayId + "\r\n";
                curPrepayId = prepayId;
            }
        }

        
        class CancelCall : CancelCallback
        {
            public void onFailed(string code, string errMsg)
            {
                logStr +=  "CancelCall onFailed code: " + code + "; errMsg: " + errMsg + "\r\n";
            }

            public void onSuccess(PayResultBean payResultBean)
            {
                logStr += "CancelCall onSuccess CancelCall curPrepayId: " + curPrepayId + "\r\n";
                curPrepayId = null;
            }
        }

        class RefundCall : RefundCallback
        {
            public void onFailed(string code, string errMsg)
            {
                logStr += "RefundCall onFailed code: " + code + "; errMsg: " + errMsg + "\r\n";
            }

            public void onSuccess(RefundResultBean payResultBean)
            {
                logStr +="RefundCall onSuccess curPrepayId: " + curPrepayId + "\r\n";
                lastPayResultInfo = null;
            }
        }

        class CScanBResult : PayCallback
        {
            public void onSuccess(PayResultBean payResultBean)
            {
                logStr += "CScanBResult onSuccess result: " + "\r\n";
                logStr += "prepayId: " +payResultBean.PrepayId +"; payInfo:" + payResultBean.PayInfo + "\r\n";
                logStr += "用于生成扫码二维码的串: \r\n" +
                    "{ \"t\":1, \"p\":\"" + payResultBean.PayInfo + "\" }" 
                    +"\r\n";
                logStr += "CScanBResult onSuccess end" + "\r\n";
            }

            public void onFailed(String code, String errMsg)
            {
                logStr += "CScanBResult onFailed code: " + code + "; errMsg: " + errMsg + "\r\n";
            }

            public void onPrepayId(String prepayId)
            {
                logStr += "CScanBResult 支付单号：" + prepayId +"\r\n";
                curPrepayId = prepayId;
            }
        }

        class QueryPayResult : PayCallback
        {
            public void onSuccess(PayResultBean payResultBean)
            {
                logStr += "QueryPayResult onSuccess result: " + "\r\n";
                logStr += "prepayId: " + payResultBean.PrepayId + "; TradeState:" + payResultBean.TradeState + "\r\n";
                logStr += "QueryPayResult onSuccess end" + "\r\n";
                if (payResultBean.TradeState == (int)CodeEnum.ORDER_STATE_SUCCESS)
                {
                    lastPayResultInfo = payResultBean;
                }
            }

            public void onFailed(String code, String errMsg)
            {
                logStr += "QueryPayResult onFailed code: " + code + "; errMsg: " + errMsg + "\r\n";
            }

            public void onPrepayId(String prepayId)
            {
                logStr += "QueryPayResult 支付单号：" + prepayId + "\r\n";
                curPrepayId = prepayId;
            }
        }

        private void writeLog()
        {
            logLb.Text = logStr;
        }

        private static string GetMacAddress()
        {
            string physicalAddress = "";
            NetworkInterface[] nice = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adaper in nice)
            {
                if (adaper.Description == "en0")
                {
                    physicalAddress = adaper.GetPhysicalAddress().ToString();
                    break;
                }
                else
                {
                    physicalAddress = adaper.GetPhysicalAddress().ToString();
                    if (physicalAddress != "")
                    {
                        break;
                    };
                }
            }
            physicalAddress = System.Text.RegularExpressions.Regex.Replace(physicalAddress, @"(\w{2})", "$1-").Trim('-');
            return physicalAddress;
        }

        private static string GetNetworkAdpaterID()
        {
            try
            {
                string mac = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        mac = mo["MacAddress"].ToString();
                        break;
                    }
                moc = null;
                mc = null;
                return mac.Trim().Replace(':', '-');
            }
            catch (Exception e)
            {
                return GetMacAddress();
            }
        }
    }
}
