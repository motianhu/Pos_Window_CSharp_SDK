using System;
using PaymentSDK.config;
using PaymentSDk.http;
using PaymentSDK.bean;
using PaymentSDK.util;

namespace PaymentSDK
{
    public class Payment : IPayment
    {
        public String mchId;
        public String mchKey;

        /**
         * 调试配置
         * */
        public void setDebug(int env)
        {
            throw new NotImplementedException();
        }

        /**
         * 初始化接口
         * */
        public void init(String mchId, String mchKey)
        {
            this.mchId=mchId;
            this.mchKey=mchKey;
        }

        /**
         * B扫C接口
         * */
        public void prePayment(String qrCode,
                        String mchName,
                        String formatNumber,
                        String formatName, 
                        String storeNumber, 
                        String storeName,
                        String sourceCode, 
                        String subject,
                        String goodsDetail, 
                        String orderId,
                        Decimal totalAmount,
                        Decimal amount,
                        Decimal discountAmount,
                        String desc, String notifyUrl,
                        PayCallback payCallback)
        {
            checkBaseInfo();
            if (payCallback == null)
            {
                throw new Exception("缺少回调");
            }
            if(String.IsNullOrEmpty(qrCode))
            {
                payCallback.onFailed("-2", "qrCode不能为空");
                return;
            }
            if (String.IsNullOrEmpty(formatNumber))
            {
                payCallback.onFailed("-2", "formatNumber不能为空");
                return;
            }
            if (String.IsNullOrEmpty(storeNumber))
            {
                payCallback.onFailed("-2", "storeNumber不能为空");
                return;
            }
            if (String.IsNullOrEmpty(sourceCode))
            {
                payCallback.onFailed("-2", "sourceCode不能为空");
                return;
            }
            if (String.IsNullOrEmpty(subject))
            {
                payCallback.onFailed("-2", "subject不能为空");
                return;
            }
            if (String.IsNullOrEmpty(orderId))
            {
                payCallback.onFailed("-2", "orderId不能为空");
                return;
            }
            if (totalAmount < amount)
            {
                payCallback.onFailed("-2", "总金额不能小于支付金额");
                return;
            }
            if (totalAmount < (amount + discountAmount))
            {
                payCallback.onFailed("-2", "总金额不能小于支付金额+折扣金额");
                return;
            }
            ReqPaymentBean reqPaymentBean=new ReqPaymentBean();
            reqPaymentBean.appId="100007";
            reqPaymentBean.qrCode=qrCode;
            reqPaymentBean.mchId=mchId;
            reqPaymentBean.mchName=mchName;
            reqPaymentBean.formatNumber=formatNumber;
            reqPaymentBean.formatName=formatName;
            reqPaymentBean.storeNumber=storeNumber;
            reqPaymentBean.storeName=storeName;
            reqPaymentBean.sourceCode=sourceCode;
            reqPaymentBean.subject=subject;
            reqPaymentBean.goodsDetail=goodsDetail;
            reqPaymentBean.outTradeNo=orderId;
            reqPaymentBean.totalAmount = totalAmount;
            reqPaymentBean.amount = amount;
            reqPaymentBean.discountAmount = discountAmount;
            reqPaymentBean.paymentScene=1;
            reqPaymentBean.desc=desc;
            reqPaymentBean.payType="H02";
            reqPaymentBean.currency="CNY";
            reqPaymentBean.timeExpire=null;
            reqPaymentBean.timestamp = CommonUtil.GetTimeStamp();
            reqPaymentBean.notifyUrl=notifyUrl;
            reqPaymentBean.generateSign(mchKey);

            HttpClient client=new HttpClient();
            String url = Config.HOST + Config.B_2_C_PREPAY;
            String jsonBody = JsonUtil.SerializeObject(reqPaymentBean);
            BaseResponse<PayResultBean> response= client.PostDataHttp<BaseResponse<PayResultBean>>(mchId, url, null,null, jsonBody);
            if(response == null)
            {
                payCallback.onFailed("-1", "Result is null!");
            }
            else if("000000".Equals(response.Code))
            {
                //支付结束：可能成功可能失败，看交易状态状态
                if(CommonUtil.isFinishTrade(response.Data.TradeState)) {
                    payCallback.onSuccess(response.Data);
                } else
                {
                    String prepayId = response.Data.PrepayId;
                    //开始轮询
                    payCallback.onPrepayId(prepayId);
                    queryPayResult(true, prepayId, payCallback);
                }
            }
            else 
            {
                payCallback.onFailed(response.Code, response.Message);
            }
        }

        /**
         * C扫B。下支付单，下完之后，需要业态调用查询接口去查询
         * */
        public void prePayment(String mchName,
                               String formatNumber,
                               String formatName,
                               String storeNumber,
                               String storeName,
                               String sourceCode,
                               String subject,
                               String goodsDetail,
                               String orderId,
                               Decimal totalAmount,
                               Decimal amount,
                               Decimal discountAmount,
                               String desc,
                               String notifyUrl,
                               PayCallback payCallback)
        {
            checkBaseInfo();
            if (payCallback == null)
            {
                throw new Exception("缺少回调");
            }
            if (String.IsNullOrEmpty(formatNumber))
            {
                payCallback.onFailed("-2", "formatNumber不能为空");
                return;
            }
            if (String.IsNullOrEmpty(storeNumber))
            {
                payCallback.onFailed("-2", "storeNumber不能为空");
                return;
            }
            if (String.IsNullOrEmpty(sourceCode))
            {
                payCallback.onFailed("-2", "sourceCode不能为空");
                return;
            }
            if (String.IsNullOrEmpty(subject))
            {
                payCallback.onFailed("-2", "subject不能为空");
                return;
            }
            if (String.IsNullOrEmpty(orderId))
            {
                payCallback.onFailed("-2", "orderId不能为空");
                return;
            }
            if (totalAmount < amount)
            {
                payCallback.onFailed("-2", "总金额不能小于支付金额");
                return;
            }
            if (totalAmount < (amount + discountAmount))
            {
                payCallback.onFailed("-2", "总金额不能小于支付金额+折扣金额");
                return;
            }
            ReqPaymentBean reqPaymentBean = new ReqPaymentBean();
            reqPaymentBean.appId = "100007";
            reqPaymentBean.mchId = mchId;
            reqPaymentBean.mchName = mchName;
            reqPaymentBean.formatNumber = formatNumber;
            reqPaymentBean.formatName = formatName;
            reqPaymentBean.storeNumber = storeNumber;
            reqPaymentBean.storeName = storeName;
            reqPaymentBean.sourceCode = sourceCode;
            reqPaymentBean.subject = subject;
            reqPaymentBean.goodsDetail = goodsDetail;
            reqPaymentBean.outTradeNo = orderId;
            reqPaymentBean.totalAmount = totalAmount;
            reqPaymentBean.amount = amount;
            reqPaymentBean.discountAmount = discountAmount;
            reqPaymentBean.paymentScene = 1;
            reqPaymentBean.desc = desc;
            reqPaymentBean.payType = "H02";
            reqPaymentBean.currency = "CNY";
            reqPaymentBean.timeExpire = null;
            reqPaymentBean.timestamp = CommonUtil.GetTimeStamp();
            reqPaymentBean.notifyUrl = notifyUrl;
            reqPaymentBean.generateSign(mchKey);

            HttpClient client = new HttpClient();
            String url = Config.HOST + Config.C_2_B_PREPAY;
            String jsonBody = JsonUtil.SerializeObject(reqPaymentBean);
            BaseResponse<PayResultBean> response = client.PostDataHttp<BaseResponse<PayResultBean>>(mchId, url, null, null, jsonBody);
            if (response == null)
            {
                payCallback.onFailed("-1", "Result is null!");
            }
            else if ("000000".Equals(response.Code))
            {
                payCallback.onPrepayId(response.Data.PrepayId);
                payCallback.onSuccess(response.Data);
            }
            else
            {
                payCallback.onFailed(response.Code, response.Message);
            }
        }

        /**
         * 查询支付结果 
         **/
        public void queryPayResult(String prepayId, PayCallback payCallback)
        {
            checkBaseInfo();
            if (payCallback == null)
            {
                throw new Exception("缺少回调");
            }
            if (String.IsNullOrEmpty(prepayId))
            {
                payCallback.onFailed("-2", "prepayId不能为空");
                return;
            }
            queryPayResult(false, prepayId, payCallback);
        }
               

        /**
         * 退单接口
         * */
        public void cancelPayment(string prepayId, CancelCallback payCallback)
        {
            checkBaseInfo();
            if (payCallback == null)
            {
                throw new Exception("缺少回调");
            }
            if (String.IsNullOrEmpty(prepayId))
            {
                payCallback.onFailed("-2", "prepayId不能为空");
                return;
            }
            
            ReqCancelBean reqCancelBean = new ReqCancelBean();
            reqCancelBean.prepayId = prepayId;
            reqCancelBean.timestamp = CommonUtil.GetTimeStamp();
            reqCancelBean.generateSign(mchKey);

            HttpClient client = new HttpClient();
            String url = Config.HOST +Config.REVODE_ORDER;
            String jsonBody = JsonUtil.SerializeObject(reqCancelBean);
            BaseResponse<PayResultBean> response = client.PostDataHttp<BaseResponse<PayResultBean>>(mchId, url, null, null, jsonBody);
            if (response == null)
            {
                payCallback.onFailed("-1", "Result is null!");
            }
            else if ("000000".Equals(response.Code))
            {
                payCallback.onSuccess(response.data);
            }
            else
            {
                payCallback.onFailed(response.Code, response.Message);
            }
        }

        /**
         * 退款接口
         * */
        public void refund(Decimal amount, String notifyUrl,String outTradeNo, String paySerialId, RefundCallback payCallback)
        {
            checkBaseInfo();
            if (payCallback == null)
            {
                throw new Exception("缺少回调");
            }
            if (String.IsNullOrEmpty(outTradeNo))
            {
                payCallback.onFailed("-2", "outTradeNo不能为空");
                return;
            }
            if (String.IsNullOrEmpty(paySerialId))
            {
                payCallback.onFailed("-2", "paySerialId不能为空");
                return;
            }
            ReqRefundBean reqRefundBean = new ReqRefundBean();
            reqRefundBean.amount = amount;
            reqRefundBean.notifyUrl = notifyUrl;
            reqRefundBean.outTradeNo = outTradeNo;
            reqRefundBean.timestamp = CommonUtil.GetTimeStamp();
            reqRefundBean.paySerialId = paySerialId;
            reqRefundBean.payType = "H02";
            reqRefundBean.generateSign(mchKey);

            HttpClient client = new HttpClient();
            String url = Config.HOST +Config.REFUND_ORDER;
            String jsonBody = JsonUtil.SerializeObject(reqRefundBean);
            BaseResponse<RefundResultBean> response = client.PostDataHttp<BaseResponse<RefundResultBean>>(mchId, url, null, null, jsonBody);
            if (response == null)
            {
                payCallback.onFailed("-1", "Result is null!");
            }
            else if ("000000".Equals(response.Code))
            {
                payCallback.onSuccess(response.data);
            }
            else
            {
                payCallback.onFailed(response.Code, response.Message);
            }
            
        }

        private void queryPayResult(bool needPoll, String prepayId, PayCallback payCallback)
        {
            String url = Config.HOST + Config.QUERY_PREPAY + prepayId;
            HttpClient client = new HttpClient();
            BaseResponse<QueryPrepayResult> response = client.GetDataHttp<BaseResponse<QueryPrepayResult>>(mchId, url);
            if (response == null)
            {
                payCallback.onFailed("-1", "Result is null!");
            }
            else if ("000000".Equals(response.Code))
            {

                if (needPoll)
                {
                    //支付结束：可能成功可能失败，看交易状态状态
                    if (CommonUtil.isFinishTrade(response.Data.TradeState))
                    {
                        payCallback.onSuccess(response.Data.toPayResult());
                    }
                    else
                    {
                        //开始轮询
                        queryPayResult(true, prepayId, payCallback);
                    }
                }
                else
                {
                    payCallback.onPrepayId(response.Data.PrepayId);
                    payCallback.onSuccess(response.Data.toPayResult());
                }
            }
            else
            {
                payCallback.onFailed(response.Code, response.Message);
            }
        }

        private void checkBaseInfo()
        {
            if(String.IsNullOrEmpty(mchId))
            {
                throw new Exception("商户id不能为空");
            }
            if (String.IsNullOrEmpty(mchKey))
            {
                throw new Exception("商户秘钥不能为空");
            }
        }
    }
}
