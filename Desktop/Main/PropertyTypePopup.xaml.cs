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
using System.ComponentModel;

namespace Main
{
    /// <summary>
    /// Interaction logic for PropertyTypePopup.xaml
    /// </summary>
    public partial class PropertyTypePopup : Window, INotifyPropertyChanged
    {
        private object _windowContent;
        public object WindowContent
        {
            get { return _windowContent; }
            set { _windowContent = value; Notify("WindowContent"); }
        }

        public PropertyTypePopup(Control popup)
        {
            DataContext = this;
            WindowContent = popup;
            InitializeComponent();

            placeholder.Children.Clear();
            placeholder.Children.Add(popup);
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify(string propname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
        }
        #endregion

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
