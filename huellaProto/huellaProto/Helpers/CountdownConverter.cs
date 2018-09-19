

namespace huellaProto.Helpers
{
    using System;
    using Xamarin.Forms;

    public class CountdownConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var timespan = TimeSpan.FromSeconds((double)value);

            if (timespan.TotalSeconds < 1.0)
            {
                return "-- : --";
            }
            //            else if (timespan.TotalSeconds < 3600)
            //            {
            //                return string.Format("{0:D2} : {1:D2}",
            //                    timespan.Minutes, timespan.Seconds);
            //            }
            else if (timespan.TotalSeconds > 3600 * 24)
            {
                return "24 : 00 : 00";
            }

            return string.Format("{0:D2} : {1:D2} : {2:D2}",
                timespan.Hours, timespan.Minutes, timespan.Seconds);
        }

        public object Convert1(object value)
        {
            var timespan = TimeSpan.FromSeconds((double)value);

            if (timespan.TotalSeconds < 1.0)
            {
                return "-- : --";
            }
            //            else if (timespan.TotalSeconds < 3600)
            //            {
            //                return string.Format("{0:D2} : {1:D2}",
            //                    timespan.Minutes, timespan.Seconds);
            //            }
            else if (timespan.TotalSeconds > 3600 * 24)
            {
                return "24 : 00 : 00";
            }

            return string.Format("{0:D2} : {1:D2} : {2:D2}",
                timespan.Hours, timespan.Minutes, timespan.Seconds);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

