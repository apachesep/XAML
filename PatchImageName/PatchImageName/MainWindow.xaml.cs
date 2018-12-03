using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PatchImageName
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            string[] pdfFiles = Directory.GetFiles(tbxPath.Text, "*.png", SearchOption.AllDirectories);
            foreach (var item in pdfFiles)
            {
                var filename = System.IO.Path.GetFileName(item);
                var path = System.IO.Path.GetDirectoryName(item);
                var newFilename = filename.Replace(" ", "").Replace("-", "");
                if(filename != newFilename)
                {
                    tbkOutput.Text += $"{filename} -> {newFilename} {Environment.NewLine}";
                    var newFullFilename = System.IO.Path.Combine(path, newFilename);
                    tbkOutput.Text += $"   {item} -> {newFullFilename} {Environment.NewLine}";

                    System.IO.File.Move(item, newFullFilename);
                }
            }
        }
    }
}
