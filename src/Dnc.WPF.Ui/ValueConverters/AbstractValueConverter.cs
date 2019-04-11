using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Markup;

namespace DDnc.WPF.Ui
{
    /// <summary>
    /// Value converter base.
    /// </summary>
    public abstract class AbstractValueConverter<T>
        : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Public methods.
        public T Instance = null;
        #endregion

        #region Provide value converter instance methods.
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Instance ?? (Instance = new T());
        } 
        #endregion

        #region Convert methods.
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture); 
        #endregion
    }
}
