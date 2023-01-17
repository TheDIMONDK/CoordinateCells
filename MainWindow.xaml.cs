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

namespace Cells
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<List<int>> data;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            data = new List<List<int>>();
        }

        private void CellButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (sender as Button);

            button.Background = Brushes.LightGreen;

            foreach (UIElement button_ in Gridd.Children)
            {
                if ((button_ is Button) && button == (button_ as Button))
                {
                    int rowIndex = System.Windows.Controls.Grid.GetRow(button_);
                    int columnIndex = System.Windows.Controls.Grid.GetColumn(button_);

                    List<int> list = new List<int>();
                    list.Add(columnIndex);
                    list.Add(rowIndex);

                    data.Add(list);
                }
            }

            tb.Text = "(X, Y)\n\n";

            foreach (List<int> coord in data)
            {
                tb.Text += $"{coord[0]-1}, {Math.Abs(coord[1] - Gridd.ColumnDefinitions.Count + 2)}" + Environment.NewLine;
            }
        }
    }
}
