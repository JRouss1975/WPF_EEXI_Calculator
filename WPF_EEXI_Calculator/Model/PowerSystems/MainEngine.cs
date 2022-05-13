using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;

namespace WPF_EEXI_Calculator
{
    [Serializable]
    public class MainEngine : PowerSystem
    {

        #region Constructors
        public MainEngine()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Maximum continuous rating MCRME
        /// </summary>
        private double _mCRME;
        public double MCRME
        {
            get { return _mCRME; }
            set
            {
                if (value != _mCRME)
                    _mCRME = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Maximum continuous rating with the Engine Power Limitation (EPL) installed MCRMELim
        /// </summary>
        private double _mCRMELim;
        public double MCRMELim
        {
            get { return _mCRMELim; }
            set
            {
                if (value != _mCRMELim)
                    _mCRMELim = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// MPPMotor rated outpout of motor, MEPC 73/19 - 2.2.5.1
        /// </summary>
        private double _mPPMotor;
        public double MPPMotor
        {
            get { return _mPPMotor; }
            set
            {
                if (value != _mPPMotor)
                    _mPPMotor = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// MCR Steam turbine, MEPC 73/19 - 2.2.5.1
        /// </summary>
        private double _mCRSteam;
        public double MCRSteam
        {
            get { return _mCRSteam; }
            set
            {
                if (value != _mCRSteam)
                    _mCRSteam = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Maximum Rated Electrical Output Power
        /// </summary>
        private double _mCRPTO;
        public double MCRPTO
        {
            get { return _mCRPTO; }
            set
            {
                if (value != _mCRPTO)
                    _mCRPTO = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// electrical efficiency, MEPC 73/19 - 2.2.5.1
        /// </summary>
        private double _η = 0.913;
        public double η
        {
            get { return _η; }
            set
            {
                if (value != _η && value > 0 && value <= 1)
                    _η = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Main Enginge SCOF Curve fit order
        /// </summary>
        private int _sFOCMECurveFitOrder = 2;
        public int SFOCMECurveFitOrder
        {
            get { return _sFOCMECurveFitOrder; }
            set
            {
                if (value != _sFOCMECurveFitOrder)
                    _sFOCMECurveFitOrder = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Main Engine SFOC Curve data
        /// </summary>
        private ObservableCollection<DataPoint> _sFOCMECurveData = new ObservableCollection<DataPoint>();
        public ObservableCollection<DataPoint> SFOCMECurveData
        {
            get { return _sFOCMECurveData; }
            set
            {
                if (value != _sFOCMECurveData)
                    _sFOCMECurveData = value;
                NotifyChange("");
            }
        }


        #endregion

    }
}
