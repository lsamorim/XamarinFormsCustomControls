using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFCustomControls.CustomControls;
using XFCustomControls.iOS.CustomRenderers;

[assembly: ExportRenderer(typeof(RoundedLabel), typeof(RoundedLabelRenderer))]
namespace XFCustomControls.iOS.CustomRenderers
{
    public class RoundedLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var _xfViewReference = (RoundedLabel)Element;
                Paint(_xfViewReference);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            // re-paint if these properties change at runtime
            if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName ||
                e.PropertyName == RoundedLabel.CurvedBackgroundColorProperty.PropertyName ||
                e.PropertyName == RoundedLabel.CurvedBorderColorProperty.PropertyName ||
                e.PropertyName == RoundedLabel.CurvedBorderWidthProperty.PropertyName ||
                e.PropertyName == RoundedLabel.CurvedCornerRadiusProperty.PropertyName)
            {
                if (Element != null)
                {
                    var _xfViewReference = (RoundedLabel)Element;
                    Paint(_xfViewReference);
                }
            }
        }

        private void Paint(RoundedLabel view)
        {
            if (view == null)
                return;

            this.Layer.BackgroundColor = view.CurvedBackgroundColor.ToCGColor();
            this.Layer.BorderColor = view.CurvedBorderColor.ToCGColor();
            this.Layer.BorderWidth = (float)view.CurvedBorderWidth;
            this.Layer.CornerRadius = (float)view.CurvedCornerRadius/2f;
        }
    }
}