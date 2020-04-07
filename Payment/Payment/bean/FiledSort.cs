using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSDK.bean
{
    class FiledSort : IComparer
    {
        public int Compare(object x, object y)
        {

            FieldInfo p1=x as FieldInfo;
            FieldInfo p2=y as FieldInfo;
            if (p1 == null || p2 == null)
            {
                 throw new ArgumentException("FieldInfo");
            }
            return string.CompareOrdinal(p1.Name, p2.Name);
          
        }
    }
}
