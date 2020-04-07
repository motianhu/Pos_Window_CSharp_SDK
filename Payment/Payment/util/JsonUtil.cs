using Newtonsoft.Json;
using System;

namespace PaymentSDK
{
    class JsonUtil
    {
        public static String SerializeObject(Object value)
        {
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.Converters.Add(new DecimalJson());
            return JsonConvert.SerializeObject(value, null, jss);
        }
    }

    class DecimalJson: JsonConverter {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type t = value.GetType();
           if (t == decArrayType)
                dumpNumArray<decimal>(writer, (decimal)value);
            else
                throw new NotImplementedException();
        }

        private void dumpNumArray<T>(JsonWriter writer, T n)
        {
            var s = n.ToString();
            if (s.EndsWith(".0"))
                writer.WriteRawValue(s.Substring(0, s.Length - 2));
            else if (s.Contains("."))
                writer.WriteRawValue(s.TrimEnd('0').TrimEnd('.'));
            else
                writer.WriteRawValue(s);
        }
        
        private Type decArrayType = typeof(decimal);

        public override bool CanConvert(Type objectType)
        {
            return objectType == decArrayType;
        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
