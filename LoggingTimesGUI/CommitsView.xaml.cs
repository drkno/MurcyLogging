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

namespace LoggingTimesGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CommitsWindow : Window
    {
        public CommitsWindow()
        {
            InitializeComponent();
            string[] args = {
                @"C:\Users\james\Documents\SENG302",
                "15ee733f7ae6a91483ceca94e397c316d56399a4", "55c0ec4977c2c243b610684397048563d52edbff"
            };
            ((CommitsViewModel)DataContext).SetUp(args);
        }

        private void MergeButton_Click(object sender, RoutedEventArgs e)
        {
            if (CommitsListBox.SelectedItems.Count < 2) return;
            for (int i = 1; i < CommitsListBox.SelectedItems.Count; i++)
            {
                ((CommitsViewModel)DataContext).Merge((LogMessage)CommitsListBox.SelectedItems[i], (LogMessage)CommitsListBox.SelectedItems[i - 1]);
            }
        }
    }
}
