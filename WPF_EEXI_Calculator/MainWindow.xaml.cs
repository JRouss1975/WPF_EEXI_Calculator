using ScottPlot;
using ScottPlot.DataStructures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using MathNet.Numerics;

namespace WPF_EEXI_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        #region Constructors
        public MainWindow()
        {
            InitializeComponent();

            EEXI e = new EEXI();
            e.Vessel = new Vessel();
            e.Vessel.VesselName = "Test";
            e.Vessel.HullNo = "s1";

            e.MainEngines = new ObservableCollection<MainEngine>();
            MainEngine eng = new MainEngine();
            e.MainEngines.Add(eng);





            lstEEXICalculations.Add(e);
            //lstEEXICalculations.Add(new EEXI_Calculation() { Vessel = new Vessel { VesselName = "MARAN ODYSSEY", HullNo = "1163", VesselType = VesselType.BulkCarrier } });
            //lstEEXICalculations.Add(new EEXI_Calculation() { Vessel = new Vessel { VesselName = "MARAN PIONEER", HullNo = "1156", VesselType = VesselType.BulkCarrier } });
            dgvProjects.SelectedIndex = 0;
        }

        #endregion

        #region Properties
        public ObservableCollection<EEXI> lstEEXICalculations { get; set; } = new ObservableCollection<EEXI>();

        #endregion

        #region EventHandlers
        private void menuOpen_Click(object sender, RoutedEventArgs e)
        {
            lstEEXICalculations = FileOperation.OpenXMLObject<ObservableCollection<EEXI>>();
            dgvProjects.ItemsSource = lstEEXICalculations;
        }

        private void menuSave_Click(object sender, RoutedEventArgs e)
        {
            FileOperation.SaveObjectToXML<ObservableCollection<EEXI>>(lstEEXICalculations);
        }

        private void dgvProjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        #endregion

    }
}
