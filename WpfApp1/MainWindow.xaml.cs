using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        string[] medewerkersArray;
        string[] employeeNumbers;
        decimal[] salaries;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            updateBtn.IsEnabled = false;
            salarisTxtBox.IsEnabled = false;

            medewerkersArray = new string[] { "Kristof", "Sander", "Koen" };
            employeeNumbers = new string[] { "M01", "M02", "M03" };
            salaries = new decimal[] { 0m, 0m, 0m };


            Output();

      
           
        }
        private void resultListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (resultListbox.SelectedIndex != -1)
            {
                updateBtn.IsEnabled = true;
                salarisTxtBox.IsEnabled = true;
            }
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            bool validInput = decimal.TryParse(salarisTxtBox.Text, out decimal newSalary);
            
          

            if (validInput)
            {

                
                salaries[resultListbox.SelectedIndex] = newSalary;

                resultListbox.Items.Clear();
                Output();
               
            }
            else
            {
                errorLabel.Content = "Kan tekst niet omzetten naar salaris!";
            }





        }
        private void Output()
        {
           
           

            for (int i = 0; i < medewerkersArray.Length; i++)
            {
                ListBoxItem item = new ListBoxItem();

                item.Content = $"{employeeNumbers[i]} - {medewerkersArray[i]} - € {salaries[i]}";

                resultListbox.Items.Add(item);
            }

        }

    }
}
