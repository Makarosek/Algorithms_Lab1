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

namespace Algorithms_Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            int[] inputData1 = Generator.GeneranteNumbers(5);
            int[] inputData2 = Generator.GeneranteNumbers(5);
            int[] inputData3 = Generator.GeneranteNumbers(5);
            int[] inputData4 = Generator.GeneranteNumbers(5);
            int[] inputData5 = Generator.GeneranteNumbers(5);

            ListBox.ItemsSource = inputData1;
        }
    }
}