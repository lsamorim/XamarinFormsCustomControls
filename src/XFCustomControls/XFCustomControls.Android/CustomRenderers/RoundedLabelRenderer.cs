using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFCustomControls.CustomControls;
using XFCustomControls.Droid.CustomRenderers;

[assembly: ExportRenderer(typeof(RoundedLabel), typeof(RoundedLabelRenderer))]
namespace XFCustomControls.Droid.CustomRenderers
{
    public class RoundedLabelRenderer : LabelRenderer
    {
        private GradientDrawable _gradientBackground;

        public RoundedLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var view = (RoundedLabel)Element;

            Paint(view);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName ||
                e.PropertyName == RoundedLabel.CurvedBackgroundColorProperty.PropertyName ||
                e.PropertyName == RoundedLabel.CurvedBorderColorProperty.PropertyName ||
                e.PropertyName == RoundedLabel.CurvedBorderWidthProperty.PropertyName ||
                e.PropertyName == RoundedLabel.CurvedCornerRadiusProperty.PropertyName)
            {
                var view = (RoundedLabel)Element;

                Paint(view);
            }
        }

        private void Paint(RoundedLabel view)
        {
            if (view == null)
                return;

            var curvedBackgroundColor = view.CurvedBackgroundColor.ToAndroid();
            var curvedBorderColor = view.CurvedBorderColor.ToAndroid();
            var curvedBorderWidth = (int)Math.Round(view.CurvedBorderWidth);

            // creating gradient drawable for the curved background
            _gradientBackground = new GradientDrawable();
            _gradientBackground.SetShape(ShapeType.Rectangle);
            _gradientBackground.SetColor(curvedBackgroundColor);

            // Thickness of the stroke line
            _gradientBackground.SetStroke(curvedBorderWidth, curvedBorderColor);

            //// Radius for the curves
            _gradientBackground.SetCornerRadius(
                DpToPixels(this.Context,
                Convert.ToSingle(view.CurvedCornerRadius)));

            // set the background of the label
            Control.SetBackground(_gradientBackground);
        }

        /// <summary>
        /// Device Independent Pixels to Actual Pixles conversion
        /// </summary>
        /// <param name="context"></param>
        /// <param name="valueInDp"></param>
        /// <returns></returns>
        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}