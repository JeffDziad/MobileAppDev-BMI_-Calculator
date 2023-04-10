using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BMI__Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private double getMetricBMI(double centimeters, double kilograms)
        {
            double metersSqrd = Math.Pow(centimeters / 100, 2);
            return kilograms / metersSqrd;
        }

        private double getImperialBMI(double inches, double pounds)
        {
            double s1 = pounds / inches;
            double s2 = s1 / inches;
            double s3 = s2 * 703;
            return s3;
        }

        void Calculate_BMI(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Weight.Text) || string.IsNullOrEmpty(Height.Text))
            {
                CalculatedBMI.TextColor = Color.Red;
                CalculatedBMI.Text = "Please enter your weight and height!";
            } else
            {
                double weight = Double.Parse(Weight.Text);
                double height = Double.Parse(Height.Text);
                double bmi = 0;
                if (UseMetric.IsChecked)
                {
                    bmi = getMetricBMI(height, weight);
                }
                else bmi = getImperialBMI(height, weight);

                CalculatedBMI.TextColor = Color.Blue;
                CalculatedBMI.Text = $"Your BMI is {Math.Floor(bmi * 100) / 100}";
            }
            
        }

    }
}
