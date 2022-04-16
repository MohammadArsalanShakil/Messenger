using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using Messenger.Utils;

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
                    if (((TextBox)_widgets["textBox_forEncrypt"]).Text != null)
                    {
                        if (((TextBox)_widgets["textBox_Key"]).Text != null)
                            ((TextBox)_widgets["textBox_forDecrypt"]).Text = CryptoUtil.Encrypt(((TextBox)_widgets["textBox_forEncrypt"]).Text);
                        else
                            await MessageBox.Show(this, Messages.keyEncryptErrorMessage, Messages.encryptionErrorTitle, MessageBox.MessageBoxButtons.Ok);
                    }
                    else
                    {
                        await MessageBox.Show(this, Messages.keyEncryptErrorMessage, Messages.encryptionErrorTitle, MessageBox.MessageBoxButtons.Ok);
                    }
                    break;
                case "Btn_Hash":
                    if (((TextBox)_widgets["textBox_forEncrypt"]).Text != null)
                    {
                        if (((RadioButton)_widgets["radioBtn_algo_MD5"]).IsChecked == true)
                            ((TextBlock)_widgets["textBlock_Hash"]).Text = CryptoUtil.GetHashFromString(((TextBox)_widgets["textBox_forEncrypt"]).Text, Algorithm.MD5);
                        else if (((RadioButton)_widgets["radioBtn_algo_SHA1"]).IsChecked == true)
                            ((TextBlock)_widgets["textBlock_Hash"]).Text = CryptoUtil.GetHashFromString(((TextBox)_widgets["textBox_forEncrypt"]).Text, Algorithm.SHA1);
                        else if (((RadioButton)_widgets["radioBtn_algo_SHA256"]).IsChecked == true)
                            ((TextBlock)_widgets["textBlock_Hash"]).Text = CryptoUtil.GetHashFromString(((TextBox)_widgets["textBox_forEncrypt"]).Text, Algorithm.SHA256);
                        else if (((RadioButton)_widgets["radioBtn_algo_SHA384"]).IsChecked == true)
                            ((TextBlock)_widgets["textBlock_Hash"]).Text = CryptoUtil.GetHashFromString(((TextBox)_widgets["textBox_forEncrypt"]).Text, Algorithm.SHA384);
                        else if (((RadioButton)_widgets["radioBtn_algo_SHA512"]).IsChecked == true)
                            ((TextBlock)_widgets["textBlock_Hash"]).Text = CryptoUtil.GetHashFromString(((TextBox)_widgets["textBox_forEncrypt"]).Text, Algorithm.SHA512);
                    }
                    else
                    {
                        await MessageBox.Show(this, Messages.hashingErrorMessage, Messages.hashingErrorTitle, MessageBox.MessageBoxButtons.Ok);
                    }
                    break;
                case "Btn_Decrypt":
                    if (((TextBox)_widgets["textBox_forDecrypt"]).Text != null)
                    {
                        if (((TextBox)_widgets["textBox_Key"]).Text != null)
                            ((TextBox)_widgets["textBox_forEncrypt"]).Text = CryptoUtil.Decrypt(((TextBox)_widgets["textBox_forDecrypt"]).Text);
                        else
                            await MessageBox.Show(this, Messages.keyDecryptErrorMessage, Messages.decryptionErrorTitle, MessageBox.MessageBoxButtons.Ok);
                    }
                    else
                    {
                        await MessageBox.Show(this, Messages.decryptionErrorMessage, Messages.decryptionErrorTitle, MessageBox.MessageBoxButtons.Ok);
                    }
                    break;
                case "Btn_copyHash":
                    if (((TextBlock)_widgets["textBlock_Hash"]).Text != null)
                        await Application.Current.Clipboard.SetTextAsync(((TextBlock)_widgets["textBlock_Hash"]).Text);
                    else
                        await MessageBox.Show(this, Messages.hashCopyErrorMessage, Messages.hashCopyErrorTitle, MessageBox.MessageBoxButtons.Ok);
                    break;
                case "Btn_clearEncrypt":
                    ((TextBox)_widgets["textBox_forEncrypt"]).Text = null;
                    break;
                case "Btn_clearDecrypt":
                    ((TextBox)_widgets["textBox_forDecrypt"]).Text = null;
                    break;
                default:
                    break;

            }
        }
    }
}
