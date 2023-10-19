using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        public delegate void Alg(int[] arr);

        public delegate void Pow(int n);

        private int[][] input;
        private int numberOfNumbers = 1;
        private Alg selectedAlg;
        private int step = 1;
    
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void PrintGraph_OnClick(object sender, RoutedEventArgs e)
        {
            int numbers;
            Int32.TryParse(NumbersOfElements.Text, out numbers);
            numberOfNumbers = numbers;
        
            input = Generator.GeneranteNumbers(numberOfNumbers);
            Result.Text = Analyzer.CalculateMedian(input, selectedAlg).ToString();
            double[] times = Analyzer.StepByStep(input, selectedAlg);
            AllTimes.ItemsSource = times;                   //записанное время для каждого шага
            
            Viewer.CreateWB(times, step);
            
        }

        private void First_OnClick(object sender, RoutedEventArgs e)
        {
            selectedAlg = Algorithm.FirstAlg;
        }

        private void Summ_OnClick_OnClick(object sender, RoutedEventArgs e)
        {
            selectedAlg = Algorithm.Summ;
        }

        private void Mult_OnClick(object sender, RoutedEventArgs e)
        {
            selectedAlg = Algorithm.Mult;
        }

        private void BubbleSort_OnClick(object sender, RoutedEventArgs e)
        {
            selectedAlg = Algorithm.BubbleSort;
        }

        private void Horner_OnClick(object sender, RoutedEventArgs e) //TODO Добавить алгоритм Горнера
        {
            selectedAlg = Algorithm.Horner;
        }

        private void Quick_OnClick(object sender, RoutedEventArgs e)
        {
            selectedAlg = Algorithm.QuickSort;
        }

        private void Tim_OnClick(object sender, RoutedEventArgs e)
        {
            selectedAlg = Algorithm.TimSort;
        }

        private void Gnome_OnClick(object sender, RoutedEventArgs e)
        {
            selectedAlg = Algorithm.GnomeSort;
        }

        private void Select_OnClick(object sender, RoutedEventArgs e)
        {
            selectedAlg = Algorithm.SelectSort;
        }

        private void Stooge_OnClick(object sender, RoutedEventArgs e)
        {
            selectedAlg = Algorithm.StoogeSort;
        }
    }
}