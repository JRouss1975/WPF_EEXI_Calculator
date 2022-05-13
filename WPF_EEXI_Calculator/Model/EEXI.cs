using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_EEXI_Calculator
{
    public class EEXI : Observable
    {

        public EEXI()
        {
            MainEngines.CollectionChanged += PowerSystem_CollectionChanged;
            AuxiliaryEngines.CollectionChanged += PowerSystem_CollectionChanged;
            ShaftMotors.CollectionChanged += PowerSystem_CollectionChanged;

        }

        private void PowerSystem_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            
        }

        /// <summary>
        /// Vessel Name
        /// </summary>
        public string VesselName
        {
            get { return this.Vessel.VesselName; }
            set
            {
                if (value != this.Vessel.VesselName)
                    this.Vessel.VesselName = value;
                NotifyChange("");
            }
        }


        /// <summary>
        /// Vessel
        /// </summary>
        private Vessel _vessel = new Vessel();
        public Vessel Vessel
        {
            get { return _vessel; }
            set
            {
                if (value != _vessel)
                    _vessel = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Main engines of vessel
        /// </summary>
        private ObservableCollection<MainEngine> _mainEngines = new ObservableCollection<MainEngine>();
        public ObservableCollection<MainEngine> MainEngines
        {
            get { return _mainEngines; }
            set
            {
                {
                    if (value != _mainEngines)
                        _mainEngines = value;
                    NotifyChange("");
                }
            }
        }

        /// <summary>
        /// Auxiliary Engines of vessel
        /// </summary>
        private ObservableCollection<AuxiliaryEngine> _auxiliaryEngines = new ObservableCollection<AuxiliaryEngine>();
        public ObservableCollection<AuxiliaryEngine> AuxiliaryEngines
        {
            get { return _auxiliaryEngines; }
            set
            {
                {
                    if (value != _auxiliaryEngines)
                        _auxiliaryEngines = value;
                    NotifyChange("");
                }
            }
        }


        /// <summary>
        /// Shaft Motors of vessel
        /// </summary>
        private ObservableCollection<ShaftMotor> _shaftMotors = new ObservableCollection<ShaftMotor>();
        public ObservableCollection<ShaftMotor> ShaftMotors
        {
            get { return _shaftMotors; }
            set
            {
                {
                    if (value != _shaftMotors)
                        _shaftMotors = value;
                    NotifyChange("");
                }
            }
        }


        public double SPME
        {
            get
            {
                switch (this.Vessel.VesselType)
                {
                    case VesselType.LNGSteamTurbine:
                        return MainEngines.Sum(e => 0.83 * e.MCRSteam);

                    case VesselType.LNGDieselElectric:
                        return MainEngines.Sum(e => 0.83 * (e.MPPMotor / e.η));

                    default:
                        {
                            double SMCRME = MainEngines.Sum(e => e.MCRME);


                            return MainEngines.Sum(e => 0.75 * (e.MCRME));
                        }

                }
            }

        }



        public double SPPTO
        {
            get
            {
                switch (Vessel.VesselType)
                {
                    case VesselType.LNGSteamTurbine:
                        return MainEngines.Sum(s => 0.83 * s.MCRPTO);
                    default:
                        return MainEngines.Sum(s => 0.75 * s.MCRPTO);
                }
            }
        }






        //public double PME
        //{
        //    get
        //    {
        //        switch (EngineType)
        //        {
        //            case EngineType.Diesel:
        //                if (MCRMELim > 0)
        //                    return Math.Min(0.75 * (MCRME - PPTO), 0.83 * (MCRMELim - PPTO));
        //                else if (MCRMELim == 0)
        //                    return 0.75 * (MCRME - PPTO);
        //                return -1;

        //            case EngineType.LNGSteamTurbine:
        //                if (IsShaftGenerator)
        //                    return 0.83 * (0.83 * MCRSteam - PPTO);
        //                return 0.83 * MCRSteam;

        //            case EngineType.LNGDieselElectric:
        //                return 0.83 * (MPPMotor / η);
        //        }
        //        return -1;
        //    }
        //}











        //public double SFOC
        //{
        //    get
        //    {
        //        double[] FitCurve;
        //        if (SFOCMECurveData != null)
        //        {
        //            if (SFOCMECurveData.Count > 0 && SFOCMECurveFitOrder < SFOCMECurveData.Count)
        //            {
        //                double[] xc = SFOCMECurveData.OrderBy(i => i.X).Select(i => i.X).ToArray();
        //                double[] yc = SFOCMECurveData.OrderBy(i => i.X).Select(i => i.Y).ToArray();
        //                FitCurve = Fit.Polynomial(xc, yc, SFOCMECurveFitOrder, MathNet.Numerics.LinearRegression.DirectRegressionMethod.QR);
        //                return MathNet.Numerics.Polynomial.Evaluate(this.PME, FitCurve);
        //            }
        //        }
        //        return -1;
        //    }
        //}







    }
}
