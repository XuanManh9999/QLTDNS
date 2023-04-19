using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TuyenDungVaUngTuyen
    {
        public string GetParametersAsString(params object[] parameters)
        {
            var sb = new StringBuilder();
            sb.Append("Parameters: ");
            for (int i = 0; i < parameters.Length; i++)
            {
                sb.Append(parameters[i].ToString());
                if (i < parameters.Length - 1)
                {
                    sb.Append(", ");
                }
            }
            return sb.ToString();
        }
    }
}
