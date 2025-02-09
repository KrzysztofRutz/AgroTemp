using AgroTemp.Mobile.Models;
using System.Globalization;

namespace AgroTemp.Mobile.Converters;

public class DeltaValueToColorMultiValueConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values[0] is double sensorValue && values[1] is ExtremeValues extremeValues)
        {
            if (sensorValue < extremeValues.MaxDeltaTemperature)
            {
                return Colors.Orange;
            }
            else
            {
                return Colors.Green;
            }
        }

        return Colors.Gray;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
