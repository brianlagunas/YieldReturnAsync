using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace YieldReturnAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ReadFile_Click(object sender, RoutedEventArgs e)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "file.txt");

            var lines = GetLines(path);
            await foreach (var line in lines)
            {
                _listBox.Items.Add(line);
            }
        }

        async IAsyncEnumerable<string> GetLines(string filePath)
        {
            string line;
            StreamReader file = new System.IO.StreamReader(filePath);
            while ((line = await file.ReadLineAsync()) != null)
            {
                await Task.Delay(300);
                yield return line;
            }
        }
    }
}
