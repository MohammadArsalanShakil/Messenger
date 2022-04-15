using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;

namespace Messenger
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, object> _widgets = new Dictionary<string, object>();

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        public void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            _widgets.Add("textBox_Key", this.FindControl<TextBox>("textBox_Key"));
            _widgets.Add("textBox_forEncrypt", this.FindControl<TextBox>("textBox_forEncrypt"));
            _widgets.Add("textBox_forDecrypt", this.FindControl<TextBox>("textBox_forDecrypt"));
            _widgets.Add("textBlock_Hash", this.FindControl<TextBlock>("textBlock_Hash"));

            _widgets.Add("radioBtn_algo_MD5", this.FindControl<RadioButton>("radioBtn_algo_MD5"));
            _widgets.Add("radioBtn_algo_SHA1", this.FindControl<RadioButton>("radioBtn_algo_SHA1"));
            _widgets.Add("radioBtn_algo_SHA256", this.FindControl<RadioButton>("radioBtn_algo_SHA256"));
            _widgets.Add("radioBtn_algo_SHA384", this.FindControl<RadioButton>("radioBtn_algo_SHA384"));
            _widgets.Add("radioBtn_algo_SHA512", this.FindControl<RadioButton>("radioBtn_algo_SHA512"));

            ((RadioButton)_widgets["radioBtn_algo_MD5"]).IsChecked = true;
        }

        private async void Button_OnClick(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "Btn_Encrypt":
                    if (((TextBox)_widgets["textBox_forEncrypt"]).Text == string.Empty)
                    {
                        
                    }
                    else if (((TextBox)_widgets["textBox_Key"]).Text == string.Empty)
                    {

                    }
                    else
                    {
                        
                    }
                    break;
                case "Btn_Hash":
                    if (((TextBox)_widgets["textBox_forEncrypt"]).Text == string.Empty)
                    {

                    }
                    else
                    {
                        if (((RadioButton)_widgets["radioBtn_algo_MD5"]).IsChecked == true)
                        {

                        }
                        else if (((RadioButton)_widgets["radioBtn_algo_SHA1"]).IsChecked == true)
                        {

                        }
                        else if (((RadioButton)_widgets["radioBtn_algo_SHA256"]).IsChecked == true)
                        {

                        }
                        else if (((RadioButton)_widgets["radioBtn_algo_SHA384"]).IsChecked == true)
                        {

                        }
                        else if (((RadioButton)_widgets["radioBtn_algo_SHA512"]).IsChecked == true)
                        {

                        }
                    }
                    break;
                case "Btn_Decrypt":
                    if (((TextBox)_widgets["textBox_forDecrypt"]).Text == string.Empty)
                    {

                    }
                    else if (((TextBox)_widgets["textBox_Key"]).Text == string.Empty)
                    {

                    }
                    else
                    {

                    }
                    break;
                case "Btn_copyHash":
                    if (((TextBlock)_widgets["textBlock_Hash"]).Text == string.Empty)
                    {

                    }
                    else
                    {
                        
                    }
                    break;
                default:
                    break;

            }
        }
    }
}
