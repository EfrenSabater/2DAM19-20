using System;
using System.Collections.Generic;
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

namespace UT2Actividad8
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NombreTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1 && (sender as TextBox).IsFocused)
            {
                if (pistaNombreTextBlock.IsVisible) pistaNombreTextBlock.Visibility = Visibility.Hidden;
                else pistaNombreTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void ApellidoTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1 && (sender as TextBox).IsFocused)
            {
                if (pistaApellidoTextBlock.IsVisible) pistaApellidoTextBlock.Visibility = Visibility.Hidden;
                else pistaApellidoTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void EdadTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2 && (sender as TextBox).IsFocused)
            {
                int parsedValue;
                if (!int.TryParse((sender as TextBox).Text, out parsedValue)) pistaEdadTextBlock.Visibility = Visibility.Visible;
                else pistaEdadTextBlock.Visibility = Visibility.Hidden;
            }
        }
    }
}
