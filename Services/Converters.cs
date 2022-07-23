using System.Globalization;

namespace ORCA.Services;

public class OpacityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null || !(value is bool))
            return 1.0d;
        if ((bool)value == false)
            return 0.5d;
        return 1.0d;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
public class BoolToGreenConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null || !(value is bool))
            return Colors.Gray;
        if ((bool)value == true)
            return Colors.Green;
        return Colors.Gray;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
public class BoolToRedConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null || !(value is bool))
            return Colors.Gray;
        if ((bool)value == false)
            return Colors.Red;
        return Colors.Gray;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
public class BoolToTextColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null || !(value is bool))
            return Colors.White;
        if ((bool)value == true)
            return Colors.Black;
        return Colors.White;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
public class CompetencyNameToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null || !(value is string))
            return Colors.Gray;
        var q = (string)value;
        if (!CompetencyColors.ColorLookup.TryGetValue(q, out var c))
            return Colors.Gray;
        else return c;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
