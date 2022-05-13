using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace WPF_EEXI_Calculator
{
    [Serializable]
    public class Vessel : Observable
    {

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Vessel()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Vessel Name
        /// </summary>
        private string _vesselName;
        public string VesselName
        {
            get { return _vesselName; }
            set
            {
                if (value != _vesselName)
                    _vesselName = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Ship Owner
        /// </summary>
        private string _shipOwner;
        public string ShipOwner
        {
            get { return _shipOwner; }
            set
            {
                if (value != _shipOwner)
                    _shipOwner = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Ship Builder
        /// </summary>
        private string _shipBuilder;
        public string ShipBuilder
        {
            get { return _shipBuilder; }
            set
            {
                if (value != _shipBuilder)
                    _shipBuilder = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Hull Number
        /// </summary>
        private string _hullNo;
        public string HullNo
        {
            get { return _hullNo; }
            set
            {
                if (value != _hullNo)
                    _hullNo = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// IMO Number
        /// </summary>
        private int _iMO;
        public int IMO
        {
            get { return _iMO; }
            set
            {
                if (value != _iMO)
                    _iMO = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Year of Built
        /// </summary>
        private int _yearOfBuilt;
        public int YearOfBuilt
        {
            get { return _yearOfBuilt; }
            set
            {
                if (value != _yearOfBuilt)
                    _yearOfBuilt = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Vessel Type
        /// </summary>
        private VesselType _vesselType;
        public VesselType VesselType
        {
            get { return _vesselType; }
            set
            {
                if (value != _vesselType)
                    _vesselType = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Length over All
        /// </summary>
        private double _lOA;
        public double LOA
        {
            get { return _lOA; }
            set
            {
                if (value != _lOA)
                    _lOA = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Length between Perpendiculars
        /// </summary>
        private double _lBP;
        public double LBP
        {
            get { return _lBP; }
            set
            {
                if (value != _lBP)
                    _lBP = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Breadth
        /// </summary>
        private double _b;
        public double B
        {
            get { return _b; }
            set
            {
                if (value != _b)
                    _b = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Depth
        /// </summary>
        private double _d;
        public double D
        {
            get { return _d; }
            set
            {
                if (value != _d)
                    _d = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Summer Draught
        /// </summary>
        private double _ds;
        public double Ds
        {
            get { return _ds; }
            set
            {
                if (value != _ds)
                    _ds = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// DeadWeight, Difference between Displacement and Lightweight at density 1.025, MEPC 73/19 - 2.2.4
        /// </summary>
        public double DWT
        {
            get
            {
                return Displacement - Lightweight;
            }
        }

        /// <summary>
        /// Gross Tonnage
        /// </summary>
        private double _grossTonnage;
        public double GrossTonnage
        {
            get
            {
                return _grossTonnage;
            }
            set
            {
                if (value != _grossTonnage)
                    _grossTonnage = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Lightweight
        /// </summary>
        private double _lightweight;
        public double Lightweight
        {
            get { return _lightweight; }
            set
            {
                if (value != _lightweight)
                    _lightweight = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Displacement
        /// </summary>
        private double _displacement;
        public double Displacement
        {
            get { return _displacement; }
            set
            {
                if (value != _displacement)
                    _displacement = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Block Coefficient
        /// </summary>
        public double CB
        {
            get
            {
                return Displacement / (LBP * B * Ds * 1.025);
            }
        }

        /// <summary>
        /// Capacity MEPC 73/19 Paragraph:2.2.3.1 to 2.2.3.3 
        /// </summary>
        public double Capacity
        {
            get
            {
                if (this.VesselType == VesselType.RoRoPassenger || this.VesselType == VesselType.CruisePassenger) return GrossTonnage;
                if (this.VesselType == VesselType.Containership) return 0.7 * DWT;
                return DWT;
            }
        }
     
        /// <summary>
        /// Speed vs Power Curve fit order
        /// </summary>
        private int _speedPowerCurveFitOrder = 2;
        public int SpeedPowerCurveFitOrder
        {
            get { return _speedPowerCurveFitOrder; }
            set
            {
                if (value != _speedPowerCurveFitOrder)
                    _speedPowerCurveFitOrder = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Speed vs Power Curve data
        /// </summary>
        private ObservableCollection<DataPoint> _speedPowerCurveData = new ObservableCollection<DataPoint>();
        public ObservableCollection<DataPoint> SpeedPowerCurveData
        {
            get { return _speedPowerCurveData; }
            set
            {
                if (value != _speedPowerCurveData)
                    _speedPowerCurveData = value;
                NotifyChange("");
            }
        }

        #endregion
    }
}