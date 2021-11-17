﻿using System;
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

namespace WPF_Calculator
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   /// 
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
         InitializeComponent();
         Stored(false);
         Result(false);
         tbInput.Focus();
      }
      //long rec1 = 0;
      char operation;

      //for numbers button
      private void btnum1_Click(object sender, RoutedEventArgs e)
      {
         tbInput.Text = tbInput.Text + "1";
      }

      private void btnum2_Click(object sender, RoutedEventArgs e)
      {
         tbInput.Text = tbInput.Text + "2";
      }

      private void btnum3_Click(object sender, RoutedEventArgs e)
      {
         tbInput.Text = tbInput.Text + "3";
      }

      private void btnum4_Click(object sender, RoutedEventArgs e)
      {
         tbInput.Text = tbInput.Text + "4";
      }


      private void btnum5_Click(object sender, RoutedEventArgs e)
      {
         tbInput.Text = tbInput.Text + "5";
      }

      private void btnum6_Click(object sender, RoutedEventArgs e)
      {
         tbInput.Text = tbInput.Text + "6";
      }

      private void btnum7_Click(object sender, RoutedEventArgs e)
      {
         tbInput.Text = tbInput.Text + "7";
      }

      private void btnum8_Click(object sender, RoutedEventArgs e)
      {
         tbInput.Text = tbInput.Text + "8";
      }

      private void btnum9_Click(object sender, RoutedEventArgs e)
      {
         tbInput.Text = tbInput.Text + "9";
      }

      private void btClear_Click(object sender, RoutedEventArgs e)
      {
         tbInput.Text = string.Empty;
      }

      private void btMinus_Click(object sender, RoutedEventArgs e)
      {
         Stored(true);
         if (tbStored.Text != string.Empty)
         {
            tbStored.Text = tbStored.Text;
         }
         else
         {
            tbStored.Text = tbInput.Text;
            tbInput.Text = string.Empty;
            operation = '-';
         }
      }

      private void tbAdd_Click(object sender, RoutedEventArgs e)
      {
         Stored(true);
         tbStored.Text = tbInput.Text;
         tbInput.Text = string.Empty;
         operation = '+';

      }

      private void btMultiply_Click(object sender, RoutedEventArgs e)
      {
         Stored(true);
         if (tbStored.Text != string.Empty)
         {
            tbStored.Text = tbStored.Text;
         }
         else
         {
            tbStored.Text = tbInput.Text;
            tbInput.Text = string.Empty;
            operation = '*';
         }
      }

      private void btDivide_Click(object sender, RoutedEventArgs e)
      {
         Stored(true);
         if (tbStored.Text != string.Empty)
         {
            tbStored.Text = tbStored.Text;
         }
         else
         {
            tbStored.Text = tbInput.Text;
            tbInput.Text = string.Empty;
            operation = '/';
         }
      }
      public void Stored(bool action)
      {
         if (!action)
         {
            tbClear.Visibility = Visibility.Hidden;
            tbStored.Visibility = Visibility.Hidden;
            lbStored.Visibility = Visibility.Hidden;
         }
         else
         {
            tbClear.Visibility = Visibility.Visible;
            tbStored.Visibility = Visibility.Visible;
            lbStored.Visibility = Visibility.Visible;
         }
      }

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

      private void btBack1_Click(object sender, RoutedEventArgs e)
      {
         //var text = int.Parse(tbStored.Text);
         //tbStored.Text = text.Remove(text.Length - 1);

         tbInput.Text = tbInput.Text.Substring(0, tbInput.Text.Length - 1);
      }

      private void btEnter_Click(object sender, RoutedEventArgs e)
      {
         switch (operation)
         {
            case '+':
               Result(true);
               lbResult.Content = int.Parse(tbStored.Text) + int.Parse(tbInput.Text);
               break;
            case '-':
               Result(true);
               lbResult.Content = int.Parse(tbStored.Text) - int.Parse(tbInput.Text);
               break;
            case '*':
               Result(true);
               lbResult.Content = int.Parse(tbStored.Text) * int.Parse(tbInput.Text);
               break;
            case '/':
               Result(true);
               lbResult.Content = int.Parse(tbStored.Text) / int.Parse(tbInput.Text);
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
            case Key.Back:
               tbInput.Text = tbInput.Text.Substring(0, tbInput.Text.Length - 1);
               break;
            case Key.Delete:
               tbInput.Text = string.Empty;
               break;
            //case Key.Enter:
            //   //make if statement that if there is something in stored and there is sign at the 
            //   //beginning then do the operation on the beginning
            //   Stored(true);
            //   tbStored.Text = tbInput.Text;
            //   tbInput.Text = string.Empty;
            //   break;

            case Key.Left:
               break;
            case Key.Up:
               break;
            case Key.Right:
               break;
            case Key.Down:
               break;
            case Key.Decimal:
               tbInput.Text = tbInput.Text + ".";
               break;
            case Key.Divide:
               operation = '/';
               break;
            default:
               break;
         }
      }


   }
}