using AgroTemp.Mobile.Models;
using System.Globalization;

namespace AgroTemp.Mobile.Converters;

public class TemperatureValueToColorMultiValueConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values[0] is double sensorValue && values[1] is ExtremeValues extremeValues)
        {
            if (sensorValue < extremeValues.MinTemperature)
            {
                return Colors.Blue;
            }
            else if (sensorValue > extremeValues.MaxTemperature)
            {
                return Colors.Red;
            }
            else
            {
                return Colors.Green;
            }
        }

        return Colors.Black;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
