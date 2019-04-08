using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Dnc.WPF
{
    /// <summary>
    /// Attached property abstract constraint.
    /// </summary>
    public class AbstractAttachedProperty<TParent, TProperty>
        where TParent : AbstractAttachedProperty<TParent, TProperty>, new()
    {
        #region Public events.
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };
        #endregion

        #region Public props.
        public static TParent Instance = new TParent();
        #endregion

        #region Attached property definitions.
        public static DependencyProperty ValueProperty
          = DependencyProperty.RegisterAttached("Value",
              typeof(TProperty),
              typeof(AbstractAttachedProperty<TParent, TProperty>),
              new PropertyMetadata(new PropertyChangedCallback(OnPropertyChanged)));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Instance.OnValueChanged(d, e);

            Instance.ValueChanged(d, e);
        }


        public static void SetValue(DependencyObject d, object value) => d.SetValue(ValueProperty, value);

        public static TProperty GetValue(DependencyObject d) => (TProperty)d.GetValue(ValueProperty);
        #endregion

        #region Event methods.
        public virtual void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        { } 
        #endregion
    }
}
