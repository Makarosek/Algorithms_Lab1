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
        public delegate int[] Alg(int[] arr);
        public MainWindow()
        {
            InitializeComponent();

            Algorithm algorithm = new Algorithm();
            Analyzer analyzer = new Analyzer();

            Alg firstAlg = algorithm.FirstAlg;
            Alg summ = algorithm.Summ;
            Alg mult = algorithm.Mult;
            Alg bubbleSort = algorithm.BubbleSort;

            int[][] inputData = Generator.GeneranteNumbers(30000);
            
            double times1 = analyzer.CalculateMedian(inputData, firstAlg);
            double times2 = analyzer.CalculateMedian(inputData, summ);
            double times3 = analyzer.CalculateMedian(inputData, mult);
            double times4 = analyzer.CalculateMedian(inputData, bubbleSort);

            List<double> times = new List<double>() { times1, times2, times3, times4};

            ListBox0.ItemsSource = inputData[0];    // просто вывод входных данных
            ListBox1.ItemsSource = inputData[1];
            ListBox2.ItemsSource = inputData[2];
            ListBox3.ItemsSource = inputData[3];
            ListBox4.ItemsSource = inputData[4];
            Times.ItemsSource = times;

        }
    }
}