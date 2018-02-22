using System;
using Xamarin.Forms;

namespace XFCustomControls.CustomControls
{
    public class CurvedCornersClickableLabel : ClickableLabel
    {
        /// <summary>
        /// Background Color (Property)
        /// </summary>
        public Color CurvedBackgroundColor
        {
            get { return (Color)GetValue(CurvedBackgroundColorProperty); }
            set { SetValue(CurvedBackgroundColorProperty, value); }
        }
        /// <summary>
        /// Backgroud Color (Bindable Property)
        /// </summary>
        public static readonly BindableProperty CurvedBackgroundColorProperty =
                               BindableProperty.Create(nameof(CurvedBackgroundColor),
                                                        typeof(Color),
                                                        typeof(CurvedCornersClickableLabel),
                                                        Color.Default);

        /// <summary>
        /// Border Color (Property)
        /// </summary>
        public Color CurvedBorderColor
        {
            get { return (Color)GetValue(CurvedBorderColorProperty); }
            set { SetValue(CurvedBorderColorProperty, value); }
        }
        /// <summary>
        /// Border Color (Bindable Property)
        /// </summary>
        public static readonly BindableProperty CurvedBorderColorProperty =
                               BindableProperty.Create(nameof(CurvedBorderColor),
                                                        typeof(Color),
                                                        typeof(CurvedCornersClickableLabel),
                                                        Color.Black);

        /// <summary>
        /// Border Width (Property)
        /// </summary>
        public double CurvedBorderWidth
        {
            get { return (double)GetValue(CurvedBorderWidthProperty); }
            set { SetValue(CurvedBorderWidthProperty, value); }
        }
        /// <summary>
        /// Border Width (Bindable Property)
        /// </summary>
        public static readonly BindableProperty CurvedBorderWidthProperty =
                               BindableProperty.Create(nameof(CurvedBorderWidth),
                                                        typeof(double),
                                                        typeof(CurvedCornersClickableLabel),
                                                        1.0);

        /// <summary>
        /// Corner Radius (Bindable Property)
        /// </summary>
        public double CurvedCornerRadius
        {
            get { return (double)GetValue(CurvedCornerRadiusProperty); }
            set { SetValue(CurvedCornerRadiusProperty, value); }
        }
        /// <summary>
        /// Corner Radius (Property)
        /// </summary>
        public static readonly BindableProperty CurvedCornerRadiusProperty =
          BindableProperty.Create(nameof(CurvedCornerRadius),
                                typeof(double),
                                typeof(CurvedCornersClickableLabel),
                                -1.0);

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (CurvedCornerRadius == -1.0)
                CurvedCornerRadius = Math.Min(width, height);
        }
    }
}
