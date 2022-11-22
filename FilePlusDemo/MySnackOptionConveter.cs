using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FilePlusDemo
{
    public class MySnackOptionConveter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string checkvalue = value.ToString();
            string targetvalue = parameter.ToString();//我們設定給conveterParameter的字串
            //變數value的字串 若與radiobox項目ConverterParameter字串相同,則設定為true
            bool r = checkvalue.Equals(targetvalue, StringComparison.InvariantCultureIgnoreCase);
            return r;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //0: Linear robot
            //1: dex robot
            //value 是目前 radiobutton 的 true/false
            //在這裡把 parameter 傳回 View-Model
            if (value == null || parameter == null)
            {
                return null;
            }
            bool usevalue = (bool)value;

            //usevalue: true代表某radiobutton按下
            //parameter: 代表哪個radiobutton按下 
            if (usevalue)
            {
                return parameter.ToString();
            }

            return null;
        }
    }
}
