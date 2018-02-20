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

namespace GUI
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            GUI.EMPDEPTDataSet eMPDEPTDataSet = ((GUI.EMPDEPTDataSet)(this.FindResource("eMPDEPTDataSet")));
            // Load data into the table DEPT. You can modify this code as needed.
            GUI.EMPDEPTDataSetTableAdapters.DEPTTableAdapter eMPDEPTDataSetDEPTTableAdapter = new GUI.EMPDEPTDataSetTableAdapters.DEPTTableAdapter();
            eMPDEPTDataSetDEPTTableAdapter.Fill(eMPDEPTDataSet.DEPT);
            System.Windows.Data.CollectionViewSource dEPTViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("dEPTViewSource")));
            dEPTViewSource.View.MoveCurrentToFirst();
            // Load data into the table EMP. You can modify this code as needed.
            GUI.EMPDEPTDataSetTableAdapters.EMPTableAdapter eMPDEPTDataSetEMPTableAdapter = new GUI.EMPDEPTDataSetTableAdapters.EMPTableAdapter();
            eMPDEPTDataSetEMPTableAdapter.Fill(eMPDEPTDataSet.EMP);
            System.Windows.Data.CollectionViewSource eMPViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("eMPViewSource")));
            eMPViewSource.View.MoveCurrentToFirst();
        }
    }
}
