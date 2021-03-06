﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KrausRGA.Views
{
    public static class ExtensionParent
    {
        /// <summary>
        /// Avinash
        /// This is Extemtion method that gives the parent control as per request.
        ///This is the Recursive fuction call method.
        /// </summary>
        /// <typeparam name="T"> Generic value Parameter </typeparam>
        /// <param name="child">which controls parent we want to find</param>
        /// <returns> parent control object</returns>
        public static T FindParent<T>(this DependencyObject child) where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);

            if (parent is T)
                return parent as T;
            else
                return parent != null ? FindParent<T>(parent) : null;
        }

        /// <summary>
        /// Make Border as checked.
        /// </summary>
        /// <param name="Bdr">
        /// Border object.
        /// </param>
        public static void Inside(this Border Bdr)
        {
            Bdr.BorderThickness = new Thickness(2, 2, 4, 4);
            Bdr.Background = new SolidColorBrush(Color.FromArgb(100, 129, 129, 129));
        }

        /// <summary>
        /// Make Border as realesed from click.
        /// </summary>
        /// <param name="Bdr">
        /// Border Realesed.
        /// </param>
        public static void Outside(this Border Bdr)
        {
            Bdr.BorderThickness = new Thickness(1, 1, 1, 1);
            Bdr.Background = new SolidColorBrush(Color.FromArgb(100, 199, 199, 199));
        }


        /// <summary>
        /// Split string by # charator and convert it 
        /// into list of GUID.
        /// </summary>
        /// <param name="TextFromTextBox">
        /// # delimiter string of guids.
        /// </param>
        /// <returns>
        /// list of Guid.
        /// </returns>
        public static List<Guid> GetGuid(this String TextFromTextBox)
        {
            List<Guid> _lsReturn = new List<Guid>();
            try
            {
                String InString = TextFromTextBox;
                String[] SplitedString = InString.Split(new char[] { '#' });
                foreach (String sitem in SplitedString)
                {
                    Guid NGuid = new Guid();
                    Guid.TryParse(sitem, out NGuid);
                    if (NGuid != Guid.Empty)_lsReturn.Add(NGuid);
                }
            }
            catch (Exception)
            {}
            return _lsReturn;
        }
    }
}
