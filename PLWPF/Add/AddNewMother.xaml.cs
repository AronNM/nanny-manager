﻿using BL;
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
using System.Windows.Shapes;

namespace PLWPF.Add
{
	/// <summary>
	/// Interaction logic for AddNewMother.xaml
	/// </summary>
	public partial class AddNewMother : Window
	{
        IBL bl;
        public AddNewMother()
		{
            bl = factoryBL.get_bl();
            InitializeComponent();

		}
	}
}
