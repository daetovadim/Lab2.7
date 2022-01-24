using Microsoft.Win32;
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

//Доработать проект текстового редактора из задания 5, заменив все обработчики событий нажатия пунктов меню командами.

namespace Lab2._7
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
        private void fontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (richTB != null)
                richTB.FontFamily = new FontFamily(fontName);
        }

        private void fontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double fontSize = Convert.ToDouble(((sender as ComboBox).SelectedItem as TextBlock).Text);
            if (richTB != null)
                richTB.FontSize = fontSize;
        }

        //Старые обработчики событий для кнопок форматирования текста
        //private void bold_Click(object sender, RoutedEventArgs e)
        //{
        //    bool bold = (sender as Button).IsPressed;
        //    if (textBox != null)
        //    {
        //        if (bold)
        //        {
        //            textBox.FontWeight = textBox.FontWeight != FontWeights.Bold
        //                ? FontWeights.Bold
        //                : FontWeights.Normal;
        //        }
        //    }
        //}

        //private void italic_Click(object sender, RoutedEventArgs e)
        //{
        //    bool italic = (sender as Button).IsPressed;
        //    if (textBox != null)
        //    {
        //        if (italic)
        //        {
        //            textBox.FontStyle = textBox.FontStyle != FontStyles.Italic
        //                ? FontStyles.Italic
        //                : FontStyles.Normal;
        //        }
        //    }
        //}

        //private void underline_Click(object sender, RoutedEventArgs e)
        //{
        //    bool underline = (sender as Button).IsPressed;
        //    if (textBox != null)
        //    {
        //        if (underline)
        //        {
        //            if (textBox.TextDecorations != TextDecorations.Underline)
        //            {
        //                textBox.TextDecorations = TextDecorations.Underline;
        //            }
        //            else
        //            {
        //                textBox.TextDecorations = null;
        //            }
        //        }
        //    }
        //}

        private void fontColor_Checked(object sender, RoutedEventArgs e)
        {
            richTB.Foreground = blackColor.IsChecked.Value ? Brushes.Black : Brushes.Red;
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                TextRange range = new TextRange(richTB.Document.ContentStart, richTB.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Rtf);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
                TextRange range = new TextRange(richTB.Document.ContentStart, richTB.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }
        }

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}
