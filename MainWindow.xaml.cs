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
using System.Text.RegularExpressions;

namespace WPF_Calculator
{
   /*
    label for display the numbers and operations
    concatenate the numbers and operations
    buttons for numers from 0 to 9
    buttons for operations + - / * 
    button to clear
    button to clear last number
    */
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         startCondition();
      }
      char operation; // to store the operation so it can bu used in switch case 


      private void PreviewTextInput(object sender, TextCompositionEventArgs e)
      {
         Regex regex = new Regex("[^0-9]+");
         e.Handled = regex.IsMatch(e.Text);
      }
      private void btnum1_Click(object sender, RoutedEventArgs e)
      { addToInput(1); }

      private void btnum2_Click(object sender, RoutedEventArgs e)
      { addToInput(2); }

      private void btnum3_Click(object sender, RoutedEventArgs e)
      { addToInput(3); }

      private void btnum4_Click(object sender, RoutedEventArgs e)
      { addToInput(4); }


      private void btnum5_Click(object sender, RoutedEventArgs e)
      { addToInput(5); }

      private void btnum6_Click(object sender, RoutedEventArgs e)
      { addToInput(6); }

      private void btnum7_Click(object sender, RoutedEventArgs e)
      { addToInput(7); }

      private void btnum8_Click(object sender, RoutedEventArgs e)
      { addToInput(8); }

      private void btnum9_Click(object sender, RoutedEventArgs e)
      { addToInput(9); }

      private void btnum0_Click(object sender, RoutedEventArgs e)
      { addToInput(0); }

      public void startCondition()
      {
         InitializeComponent();
         Stored(false);
         Result(false);
         tbInput.Focus();
         btClear_Click(this, null);
         tbStored.IsReadOnly = true;
      }
      //for numbers button

      public void addToInput(int num)
      {
         tbInput.Text = tbInput.Text + num;
      }

      //show/hide the tbStored,lbStored and clear button
      public void Stored(bool action)
      {
         if (!action)
         {
            tbClear.Visibility = Visibility.Hidden;
            lbStorednum.Visibility = Visibility.Hidden;
            tbStored.Visibility = Visibility.Hidden;
         }
         else
         {
            tbClear.Visibility = Visibility.Visible;
            lbStorednum.Visibility = Visibility.Visible;
            tbStored.Visibility = Visibility.Visible;
         }
      }

      // show / hide lbresult, lbResultInfo and change the width of application
      public void Result(bool action)
      {
         if (!action)
         {
            lbResult.Visibility = Visibility.Hidden;
            lbResultInfo.Visibility = Visibility.Hidden;
            HomePage.Height = 370;
         }
         else
         {
            lbResult.Visibility = Visibility.Visible;
            lbResultInfo.Visibility = Visibility.Visible;
            HomePage.Height = 450;
         }
      }
      public void operationMaker(char operate)
      {
         Stored(true);
         if (tbStored.Text != tbInput.Text)
         {
            tbStored.Text = tbInput.Text;
            tbInput.Text = string.Empty;
            operation = operate;
            tbInput.Focus();
         }
         else if (tbStored.Text != string.Empty)
         {
            tbStored.Text = tbStored.Text;
         }
         //first if conditon so the user can change the operation which will change in the tbInput, if the user did input for wrong number and want to change it.
         // second one: this if condition is to make sure that the result won't be removed if the user clicked the same operation button again
         // for example: if the user clicked the minus button one time it will store the result in the tbStored, one more time it will rmeove it becasue it will store the zero value of the tbInput in the tbStored, this one is to check if there is something in tbStored, then keep it the same way
      }

      /* buttons operation*/
      private void btClear_Click(object sender, RoutedEventArgs e)
      {
         tbInput.Text = string.Empty;
      }
      private void btMinus_Click(object sender, RoutedEventArgs e)
      {
         operationMaker('-');
      }
      private void tbAdd_Click(object sender, RoutedEventArgs e)
      {
         operationMaker('+');
      }

      private void btMultiply_Click(object sender, RoutedEventArgs e)
      {
         operationMaker('*');
      }

      private void btDivide_Click(object sender, RoutedEventArgs e)
      {
         operationMaker('/');
      }

      private void btBack1_Click(object sender, RoutedEventArgs e)
      {
         //var text = int.Parse(tbStored.Text);
         //tbStored.Text = text.Remove(text.Length - 1);
         if (tbInput.Text.Length == 0)
         {
            MessageBox.Show("you have already deleted every number here", "Empty", MessageBoxButton.OK);
         }
         else
         {
            tbInput.Text = tbInput.Text.Substring(0, tbInput.Text.Length - 1);
         }

      }

      private void btEnter_Click(object sender, RoutedEventArgs e)
      {
         switch (operation)
         {
            case '+':
               Result(true);
               lbResult.Content = double.Parse(tbStored.Text) + double.Parse(tbInput.Text);
               break;
            case '-':
               Result(true);
               lbResult.Content = double.Parse(tbStored.Text) - double.Parse(tbInput.Text);
               break;
            case '*':
               Result(true);
               lbResult.Content = double.Parse(tbStored.Text) * double.Parse(tbInput.Text);
               break;
            case '/':
               Result(true);
               lbResult.Content = double.Parse(tbStored.Text) / double.Parse(tbInput.Text);
               break;
            default:
               break;
         }
      }

      private void tbClear_MouseDoubleClick(object sender, MouseButtonEventArgs e)
      {
         tbStored.Text = string.Empty;
      }

      private void tbInput_KeyDown(object sender, KeyEventArgs e)
      {
         switch (e.Key)
         {
            case Key.Escape:
               startCondition(); //reset the window as the beginning and make tbinput empty
               break;
            case Key.Back:
               tbInput.Text = tbInput.Text.Substring(0, tbInput.Text.Length - 1);
               break;
            case Key.Delete:
               tbInput.Text = string.Empty;
               break;
            case Key.Enter:
               btEnter_Click(this, null);
               break;

            case Key.OemPlus:
               tbAdd_Click(this, null);
               break;
            case Key.OemMinus:
               btMinus_Click(this, null);
               break;
            case Key.Divide:
               btDivide_Click(this, null);
               break;
            case Key.Multiply:
               btMultiply_Click(this, null);
               break;
            default:
               break;
         }
      }
   }
}
