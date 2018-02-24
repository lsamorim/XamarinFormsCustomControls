using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFCustomControls.CustomControls;
using XFCustomControls.iOS.CustomRenderers;

[assembly: ExportRenderer(typeof(RoundedButton), typeof(RoundedButtonRenderer))]
namespace XFCustomControls.iOS.CustomRenderers
{
    public class RoundedButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var button = (RoundedButton)e.NewElement;

                button.SizeChanged += (s, args) =>
                {
                    var radius = Math.Min(button.Width, button.Height) / 2.0;
                    button.BorderRadius = (int)(radius);
                    button.BorderWidth = 2;
                    button.BorderColor = Color.Black;
                };
            }
        }
    }
}