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
using BL;
using BE;

namespace PLWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		IBL bl;
		public Window1() { bl = FactoryBL.getBL(); }

		int a;

		public MainWindow()
		{
			InitializeComponent();

			
			
		}

		private void choiceBoxUC_Loaded(object sender, RoutedEventArgs e)
		{

		}
	}
}
