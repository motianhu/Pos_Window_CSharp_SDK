using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSDK
{
    class ReqPaymentBean : ReqSignBean
    {
        // @ApiModelProperty(value="appid")
        public String appId;
        // @NotEmpty
        //  @ApiModelProperty(value="商户id", required=true)
        public String mchId;
        // @ApiModelProperty(value="商户名称")
        public String mchName;
        //@NotEmpty
        // @ApiModelProperty(value="业态id")
        public String formatNumber;
        //  @ApiModelProperty(value="业态名称")
        public String formatName;
        // @ApiModelProperty(value="店铺号")
        public String storeNumber;
        //  @ApiModelProperty(value="店铺名称")
        public String storeName;
        //  @NotEmpty
        // @ApiModelProperty(value="来源系统")
        public String sourceCode;
        // @NotEmpty
        // @ApiModelProperty(value="商品标题", required=true)
        public String subject;
        // @ApiModelProperty(value="商品明细")
        public String goodsDetail;
        // @NotEmpty
        // @ApiModelProperty(value="外部订单号", required=true)
        public String outTradeNo;
        // @DecimalMinNotEmpty("0.01")
        // @ApiModelProperty(value="订单总金额", required=true)
        public decimal totalAmount;
        //  @DecimalMax("5000")
        //  @DecimalMinNotEmpty("0.01")
        //  @ApiModelProperty(value="订单金额", required=true)
        public decimal amount;
        //  @ApiModelProperty(value="订单折扣")
        public decimal discountAmount;
        //  @ApiModelProperty(value="支付场景", required=true, allowableValues="1,2")
        public int paymentScene;
        //  @ApiModelProperty(value="订单描述")
        public String desc;
        // @ApiModelProperty(value="支付类型", required=true, allowableValues="H02")
        public String payType;
        // @ApiModelProperty(value="货币类型：CNY", allowableValues="CNY")
        public String currency;
        //  @TimeVaild
        //  @ApiModelProperty(value="订单失效时间")
        public String timeExpire;
        //  @ApiModelProperty(value="当前时间戳", required=true)
        public long timestamp;
        // @ApiModelProperty(value="回调url")
        public String notifyUrl;

        public String qrCode;
    }
}
