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

namespace ICE3StarterCode
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

          private void btnConvert_Click(object sender, RoutedEventArgs e)
          {

               if ((rdoLinear.IsChecked == false && rdoDB.IsChecked == false) || String.IsNullOrEmpty(txtConvert.Text))

               {
                    MessageBox.Show("Missing data");

               }

               else {

                    if (rdoLinear.IsChecked == true)
                         LinearToDB();

                    else if (rdoDB.IsChecked == true)
                         DBToLinear();
               }

               
          }
          
          private void LinearToDB()
          {
               double textBoxNumber = double.Parse(txtConvert.Text);
               double answer = 10 * Math.Log10(textBoxNumber) ;
               txtConvertOutput.Text = answer.ToString("0.0000" + "dB");

          }//LinearToDB()

          private void DBToLinear()
          {
               double textBoxNumber = double.Parse(txtConvert.Text);
               double answer1 = textBoxNumber / 10;
               double answer2 = Math.Pow(10, answer1);
               txtConvertOutput.Text = answer2.ToString("0.0000");

          }//DBToLinear()

          private void btnComputeNoise_Click(object sender, RoutedEventArgs e)
          {
               double temperature = double.Parse(txtTemperature.Text);

               if (cboTemperatureUnit.Text == "Celsius") 
               { 
                    double ctokelvin = CTOK(temperature);
                    calcNoiseInDB(ctokelvin);
               }
                  
               else if (cboTemperatureUnit.Text == "Fahrenheit") 
               {
                    double ftokelvin = FTOK(temperature);
                    calcNoiseInDB(ftokelvin);
               }
                   
               else calcNoiseInDB(temperature);

          }//btnComputeNoise_Click()

          private double CTOK(double temp) 
          {
               double kelvin = temp + 273.15;
               return kelvin;

         }//CTOK()

          private double FTOK(double temp)
         {
               double kelvin2 = (temp - 32) * 5/9 + 273.75;
               return kelvin2;

          }//FTOK()
          private void calcNoiseInDB(double t)
          {
               double bandwidth = double.Parse(txtBandwidth.Text);
               double bandwidth2 = bandwidth * Math.Pow(10, 6);
               double noise = -228.6 + 10 * Math.Log10(t) + 10 * Math.Log10(bandwidth2);
               txtNoiseOutput.Text = noise.ToString("0.0000" + " dBW");

          }//calcNoiseInDB()
     }
}
