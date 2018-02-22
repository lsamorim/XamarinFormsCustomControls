using System.Windows.Input;
using Xamarin.Forms;

namespace XFCustomControls.CustomControls
{
    public class ClickableLabel : Label
    {
        public static readonly BindableProperty CommandProperty =
                               BindableProperty.Create(nameof(Command), typeof(ICommand),
                                                       typeof(ClickableLabel), null);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }


        public static readonly BindableProperty CommandParameterProperty =
                               BindableProperty.Create(nameof(CommandParameter), typeof(object),
                                                       typeof(ClickableLabel), null);
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public ClickableLabel()
        {
            HorizontalTextAlignment = VerticalTextAlignment = TextAlignment.Center;

            GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = OnClickCommand
            });
        }

        private ICommand OnClickCommand
        {
            get
            {
                return new Command(async () =>
                {
                    //this.AnchorX = 0.48;
                    //this.AnchorY = 0.48;
                    //await this.ScaleTo(0.95, 50, Easing.Linear);
                    //await Task.Delay(100);
                    //await this.ScaleTo(1, 50, Easing.Linear);
                    if (Command != null)
                    {
                        Command.Execute(CommandParameter);
                    }
                });
            }
        }
    }
}
