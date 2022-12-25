using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Demo.Model
{
    public class NumberService
    {
       public static number nmbr;

        public NumberService() { nmbr = new number(); }

        public void add()
        {
            int a = Convert.ToInt16(nmbr.NumberA);
            int b = Convert.ToInt16(nmbr.NumberB);
            int result=a+ b;
            nmbr.Result=result;
        }

        public string Get_Result()
        {
            return nmbr.Result.ToString();
        }

    }
}
