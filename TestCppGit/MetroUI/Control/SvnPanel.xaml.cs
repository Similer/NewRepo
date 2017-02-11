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

namespace MetroUI
{
    /// <summary>
    /// Interaction logic for SvnPanel.xaml
    /// </summary>
    public partial class SvnPanel : UserControl
    {
        public SvnPanel(string path)
        {
            InitializeComponent();

            svnLable.Content = path;
        }

        private void Lable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();

            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                (sender as Label).Content = dialog.SelectedPath;
            }
        }

    }
}