using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Majorsilence.Base64
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EncodeClick(object sender, RoutedEventArgs e)
        {
            TextBoxToDecode.Text = "";
            foreach (var line in TextBoxToEncode.Text.Split(Environment.NewLine))
            {
                TextBoxToDecode.Text += Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(line)) +
                                        Environment.NewLine;
            }
        }

        private void DecodeClick(object sender, RoutedEventArgs e)
        {
            TextBoxToEncode.Text= "";
            foreach (var line in TextBoxToDecode.Text.Split(Environment.NewLine))
            {
                TextBoxToEncode.Text += System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(line)) +
                                        Environment.NewLine;
            }
        }
    }
}