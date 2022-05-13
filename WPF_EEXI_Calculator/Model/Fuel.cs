using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_EEXI_Calculator
{

    /// <summary>
    /// MEPC 73/19 Annex 5 - Paragraph:2.2.1
    /// </summary>
    public class Fuel : Observable
    {
        #region Constructors
        public Fuel()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Type of Fuel
        /// </summary>
        private FuelType _type;
        public FuelType Type
        {
            get { return _type; }
            set
            {
                if (value != _type)
                    _type = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Refernce Standard
        /// </summary>
        public string Reference
        {
            get
            {
                switch (this.Type)
                {
                    case FuelType.Diesel:
                        return "ISO 8217 Grades DXM through DMB";
                    case FuelType.LFO:
                        return "ISO 8217 Grades RMA through RMD";
                    case FuelType.HFO:
                        return "ISO 8217 Grades RME through RMK";
                    case FuelType.LPG_Propane:
                        return "Propane";
                    case FuelType.LPG_Butane:
                        return "Butane";
                    case FuelType.LNG:
                        return "LNG";
                    case FuelType.Methanol:
                        return "Methanol";
                    case FuelType.Ethanol:
                        return "Ethanol";
                    default:
                        return "N/A";
                }
            }
        }

        /// <summary>
        /// Lower Calorific Value (kJ/kg)
        /// </summary>
        public int LCV
        {
            get
            {
                switch (this.Type)
                {
                    case FuelType.Diesel:
                        return 42700;
                    case FuelType.LFO:
                        return 41200;
                    case FuelType.HFO:
                        return 40200;
                    case FuelType.LPG_Propane:
                        return 46300;
                    case FuelType.LPG_Butane:
                        return 45700;
                    case FuelType.LNG:
                        return 48000;
                    case FuelType.Methanol:
                        return 19900;
                    case FuelType.Ethanol:
                        return 26800;
                    default:
                        return 0;
                }
            }
        }

        /// <summary>
        /// Carbon content
        /// </summary>
        public double CarbonContent
        {
            get
            {
                switch (this.Type)
                {
                    case FuelType.Diesel:
                        return 0.8744;
                    case FuelType.LFO:
                        return 0.8594;
                    case FuelType.HFO:
                        return 0.8493;
                    case FuelType.LPG_Propane:
                        return 0.8182;
                    case FuelType.LPG_Butane:
                        return 0.8264;
                    case FuelType.LNG:
                        return 0.75;
                    case FuelType.Methanol:
                        return 0.375;
                    case FuelType.Ethanol:
                        return 0.5217;
                    default:
                        return 0.0;
                }
            }
        }

        /// <summary>
        /// Conversion Factor between fuel consumption and CO2 emission CF (t-CO2/t-Fuel)
        /// </summary>
        public double CF
        {
            get
            {
                switch (this.Type)
                {
                    case FuelType.Diesel:
                        return 3.206;
                    case FuelType.LFO:
                        return 3.151;
                    case FuelType.HFO:
                        return 3.114;
                    case FuelType.LPG_Propane:
                        return 3.000;
                    case FuelType.LPG_Butane:
                        return 3.030;
                    case FuelType.LNG:
                        return 2.750;
                    case FuelType.Methanol:
                        return 1.375;
                    case FuelType.Ethanol:
                        return 1.913;
                    default:
                        return 0.0;
                }
            }
        }

        #endregion
    }
}
