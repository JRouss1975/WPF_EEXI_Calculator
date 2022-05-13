using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_EEXI_Calculator
{
    public class PowerSystem : Observable
    {
        #region Constructors
        public PowerSystem()
        {
        }
        #endregion

        #region Properties

        /// <summary>
        /// Engine Manufacturer
        /// </summary>
        private string _manufacturer;
        public string Manufacturer
        {
            get { return _manufacturer; }
            set
            {
                if (value != _manufacturer)
                    _manufacturer = value;
                NotifyChange("");
            }
        }

        /// <summary>
        /// Engine Type
        /// </summary>
        private string _type;
        public string Type
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
        /// Type of Fuel
        /// </summary>
        private Fuel _fuel = new Fuel();
        public Fuel Fuel
        {
            get { return _fuel; }
            set
            {
                if (value != _fuel)
                    _fuel = value;
                NotifyChange("");
            }
        }

        #endregion
    }
}
