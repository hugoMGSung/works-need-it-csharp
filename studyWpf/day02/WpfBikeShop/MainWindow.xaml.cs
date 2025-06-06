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

namespace WpfBikeShop
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitClass();
        }

        private void InitClass()
        {
            Human driver = new Human
            {
                FirstName = "Nick",
                HasDrivingLicense = true
            };

            Car car = new Car();
            car.Speed = 100;
            car.Color = Colors.Tomato;
            car.Driver = driver;
        }
    }
}
