using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MathNet.Numerics;
using System.Runtime.CompilerServices;

namespace WPF_EEXI_Calculator
{
    /// <summary>
    /// Interaction logic for UCurve.xaml
    /// </summary>
    public partial class UCurve : UserControl
    {
        #region Constructors
        public UCurve()
        {
            InitializeComponent();

            DrawGraph(CurveData);
        }
        #endregion

        #region Dependency Properties  
        /// <summary>
        /// CurveData
        /// </summary>
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register("CurveData", typeof(ObservableCollection<DataPoint>), typeof(UCurve));
        public ObservableCollection<DataPoint> CurveData
        {
            get { return (ObservableCollection<DataPoint>)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        /// <summary>
        /// CurveData Fit order
        /// </summary>
        public static readonly DependencyProperty FitOrderProperty = DependencyProperty.Register("FitOrder", typeof(int), typeof(UCurve));
        public int FitOrder
        {
            get { return (int)GetValue(FitOrderProperty); }
            set { SetValue(FitOrderProperty, value); }
        }
        #endregion

        #region Properties
        private double[] FitCurve { get; set; }
        #endregion

        #region Event Handlers
        private void dgvData_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DrawGraph(CurveData);
        }

        private void cbOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DrawGraph(CurveData);
        }

        #endregion

        #region Methods
        public void DrawGraph(ObservableCollection<DataPoint> data)
        {
            plt.Plot.Clear();
  
            //Draw Curve
            if (data != null)
            {
                if (data.Count > 0)
                {
                    double[] xc = data.OrderBy(i => i.X).Select(i => i.X).ToArray();
                    double[] yc = data.OrderBy(i => i.X).Select(i => i.Y).ToArray();
                    plt.Plot.AddScatter(xc, yc);
                }

                //Draw FitCurve
                if (data.Count > 0 && FitOrder < data.Count)
                {
                    double[] xc = data.OrderBy(i => i.X).Select(i => i.X).ToArray();
                    double[] yc = data.OrderBy(i => i.X).Select(i => i.Y).ToArray();
                    FitCurve = Fit.Polynomial(xc, yc, FitOrder, MathNet.Numerics.LinearRegression.DirectRegressionMethod.QR);

                    List<double> xf = new List<double>();
                    List<double> yf = new List<double>();
                    for (double i = xc.Min(); i <= xc.Max(); i = i + ((xc.Max() - xc.Min()) / 100))
                    {
                        xf.Add(i);
                        yf.Add(MathNet.Numerics.Polynomial.Evaluate(i, FitCurve));
                    }
                    plt.Plot.AddScatter(xf.ToArray(), yf.ToArray());

                    //FitCurve Parameters
                    List<FitCurveData> fitCurveData = new List<FitCurveData>();
                    for (int i = 0; i < FitCurve.Length; i++)
                    {
                        fitCurveData.Add(new FitCurveData { ID = FitCurve.Length - i, Factor = FitCurve[i] });
                    }       
                    dgvReg.ItemsSource = fitCurveData;


                    //R and StdError
                    List<double> modeledValues = yc.ToList<double>();
                    List<double> observedValues = new List<double>();
                    foreach (var i in xc)
                        observedValues.Add(MathNet.Numerics.Polynomial.Evaluate(i, FitCurve));

                    tbR.Text = MathNet.Numerics.GoodnessOfFit.RSquared(modeledValues, observedValues).ToString("N5");
                    tbStdErr.Text = MathNet.Numerics.GoodnessOfFit.StandardError(modeledValues, observedValues, 1).ToString("N5");
                }
            }
        }

        #endregion
    }

   public class DataPoint : Observable
    {
        private double _X;
        public double X
        {
            get { return _X; }
            set
            {
                if (value != _X)
                {
                    _X = value;
                    NotifyChange("X");
                }
            }
        }

        private double _Y;
        public double Y
        {
            get { return _Y; }
            set
            {
                if (value != _Y)
                {
                    _Y = value;
                    NotifyChange("Y");
                }
            }
        }
    }


    internal class FitCurveData : Observable
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if (value != _ID)
                {
                    _ID = value;
                    NotifyChange("ID");
                }
            }
        }

        private double _Factor;
        public double Factor
        {
            get { return _Factor; }
            set
            {
                if (value != _Factor)
                {
                    _Factor = value;
                    NotifyChange("Factor");
                }
            }
        }
    }

}
