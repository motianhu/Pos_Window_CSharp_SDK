using System;

namespace PaymentSDK.bean
{
    class BaseResponse<T>
    {
        public String code;
        public String message;
        public T data;

        public string Code { get => code; set => code=value; }
        public string Message { get => message; set => message=value; }
        public T Data { get => data; set => data=value; }
    }
}
