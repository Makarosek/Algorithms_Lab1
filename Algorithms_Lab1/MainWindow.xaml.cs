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

            int[][] inputData = Generator.GeneranteNumbers(1000);
            
            long[] times1 = analyzer.GetTimes(inputData, firstAlg);
            long[] times2 = analyzer.GetTimes(inputData, summ);
            long[] times3 = analyzer.GetTimes(inputData, mult);
            long[] times4 = analyzer.GetTimes(inputData, bubbleSort);



            ListBox0.ItemsSource = inputData[0];    // просто вывод входных данных
            ListBox1.ItemsSource = inputData[1];
            ListBox2.ItemsSource = inputData[2];
            ListBox3.ItemsSource = inputData[3];
            ListBox4.ItemsSource = inputData[4];
            Times1.ItemsSource = times1;            //вывод времени работы в мс (в нижних колонках)
            Times2.ItemsSource = times2;
            Times3.ItemsSource = times3;
            Times4.ItemsSource = times4;

        }
    }
}