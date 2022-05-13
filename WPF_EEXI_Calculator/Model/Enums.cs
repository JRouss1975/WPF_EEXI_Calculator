using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_EEXI_Calculator
{
    [Serializable]
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum VesselType
    {
        [Description("Bulk Carrier")]
        BulkCarrier,
        [Description("Gas Carrier")]
        GasCarrier,
        Tanker,
        Containership,
        [Description("General cargo ship")]
        GeneralCargo,
        [Description("Refrigerated cargo carrier")]
        RefrigeratedCargo,
        [Description("Combination carrier")]
        CombinationCarrier,
        [Description("LNG carrier")]
        LNGCarrier,
        [Description("LNG Steam Turbine")]
        LNGSteamTurbine,
        [Description("LNG Diesel Electric")]
        LNGDieselElectric,
        [Description("Ro-ro cargo ship [Vehicle carrier]")]
        RoRoVehicleCarrier,
        [Description("Ro-ro cargo ship")]
        RoRoCargoCarrier,
        [Description("Ro-ro passenger ship")]
        RoRoPassenger,
        [Description("Cruise passenger ship")]
        CruisePassenger
    }


    [Serializable]
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum FuelType
    {
        [Description("Diesel/Gas Oil")]
        Diesel,
        [Description("Light Fuel Oil (LFO)")]
        LFO,
        [Description("Heavy Fuel Oil (LFO)")]
        HFO,
        [Description("Liquefied Petroleum Gas (LPG) Propane")]
        LPG_Propane,
        [Description("Liquefied Petroleum Gas (LPG) Butane")]
        LPG_Butane,
        [Description("Liquefied Natural Gas (LNG)")]
        LNG,
        Methanol,
        Ethanol
    }

}
