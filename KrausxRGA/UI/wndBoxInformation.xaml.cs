﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KrausRGA.Views;

namespace KrausRGA.UI
{
    /// <summary>
    /// Avi: 11 Oct 2013. KrausGra.
    /// Interaction logic for wndBoxInformation.xaml
    /// </summary>
    public partial class wndBoxInformation : Window
    {
        public wndBoxInformation()
        {
            InitializeComponent();

        }

        #region Events
        
        private void wndLogin_Loaded(object sender, RoutedEventArgs e)
        {
            //Hide Button Window and show Login Window
            hideButtons(System.Windows.Visibility.Hidden);
        }
        
        #endregion

        #region private Functions.

        /// <summary>
        /// set the visibilty property of Login textbox and Button controls border
        /// </summary>
        /// <param name="visibility">
        /// System.Windows.Visibility visibility enum Property
        ///passed Visibility work same for buttons but apposit for login box at the same time
        /// </param>
        private void hideButtons(System.Windows.Visibility visibility)
        {
            bdrButtons.Visibility = visibility;
            if (visibility.ToString() == System.Windows.Visibility.Hidden.ToString())
            {
                bdrLogin.Visibility = System.Windows.Visibility.Visible;
                txtLogin.Focus();
            }
            else
            {
                bdrLogin.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        #endregion

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            //If pressed key is Enter then Scan for UserName and  show  hide Buttons.
            if (e.Key == Key.Enter)
            {
                hideButtons(System.Windows.Visibility.Visible);
            }
        }

        private void btnBoxNumber_Click(object sender, RoutedEventArgs e)
        {
            bdrSrNumber.Visibility = System.Windows.Visibility.Hidden;
            bdrScan.Visibility = System.Windows.Visibility.Hidden;
            bdrScan.Visibility = System.Windows.Visibility.Visible;

            txtScan.Focus();
        }

        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                this.Dispatcher.Invoke(new Action(() =>
                    {
                        MainWindow main = new MainWindow();
                        main.Show();

                    }));
                this.Close();
            }
        }

        private void btnPONumber_Click(object sender, RoutedEventArgs e)
        {
            bdrScan.Visibility = System.Windows.Visibility.Hidden;
            bdrSrNumber.Visibility = System.Windows.Visibility.Hidden;
            bdrSrNumber.Visibility = System.Windows.Visibility.Visible;
            txtsrScan.Focus();
        }

        private void txtsrScan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                this.Dispatcher.Invoke(new Action(() =>
                {
                    wndSrNumberInfo main = new wndSrNumberInfo();
                    main.Show();

                }));
                this.Close();
            }
        }
    }

}