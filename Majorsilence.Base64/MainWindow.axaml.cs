using System;
using System.Text;
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
                try
                {
                    TextBoxToEncode.Text += System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(line)) +
                                            Environment.NewLine;
                }
                catch
                {
                    var convertedContents = new StringBuilder();
                    foreach (string word in line.Split(' '))
                    {
                        if (string.IsNullOrWhiteSpace(word))
                        {
                            convertedContents.Append(" ");
                            continue;
                        }
                        try
                        {
                            string converted = Encoding.UTF8.GetString(Convert.FromBase64String(word));
                            convertedContents.AppendLine(converted);
                        }
                        catch
                        {
                            convertedContents.Append(word);
                        }
                    }
                    
                    TextBoxToEncode.Text += convertedContents.ToString() + Environment.NewLine;
                }
            }
        }
    }
}