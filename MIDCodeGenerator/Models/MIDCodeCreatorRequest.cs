using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIDCodeGenerator.Models
{
    public class MIDCodeCreatorRequest
    {
        public Driver driver { get; set; }
        public Coupling1 coupling1 { get; set; }
        public Intermediate intermediate { get; set; }
        public Coupling2 coupling2 { get; set; }
        public Driven driven { get; set; }
    }

    public class Driver
    {
        public string componentType { get; set; }
        public int? locations { get; set; }
        public string driverType { get; set; }
        public int? cylinders { get; set; }
        public string motorDrive { get; set; }
        public bool? motorFan { get; set; }
        public bool? motorBallBearings { get; set; }
        public bool? drivenBallBearings { get; set; }
        public bool? drivenBalanceable { get; set; }
        public int? mortorPoles { get; set; }
        public bool? turbineReductionGear { get; set; }
        public bool? turbineRotorSupported { get; set; }
        public bool? turbineBallBearing { get; set; }
        public bool? turbineThrustBearing { get; set; }
        public bool? turbineThrustBearingIsBall { get; set; }
    }

    public class Coupling1
    {

        public string componentType { get; set; }
        public int? couplingPosition { get; set; }
        public string couplingType { get; set; }
        public int? locations { get; set; }
        public string coupledComponentType1 { get; set; }
        public string coupledComponentType2 { get; set; }

    }

    public class Intermediate
    {
        public string componentType { get; set; }
        public string immediateType { get; set; }
        public int? locations { get; set; }
        public string drivenBy { get; set; }
        public int? speedChangesMax { get; set; }
        public int? gearBoxLocations { get; set; }
        public string inputBearing { get; set; }
        public string intermediateBearing1st { get; set; }
        public string intermediateBearing2nd { get; set; }
        public string outputBearing { get; set; }
    }

    public class Coupling2
    {
        public string componentType { get; set; }
        public int? couplingPosition { get; set; }
        public string couplingType { get; set; }
        public int? locations { get; set; }
        public string coupledComponentType1 { get; set; }
        public string coupledComponentType2 { get; set; }
    }

    public class Driven
    {
        public string componentType { get; set; }
        public string drivenType { get; set; }
        public int? locations { get; set; }
        public string pumpType { get; set; }
        public string compressorType { get; set; }
        public string fan_or_blowerType { get; set; }
        public string purifierDrivenBy { get; set; }
        public string bearingType { get; set; }
        public string col_cType { get; set; }
        public bool? rotorOverhung { get; set; }
        public bool? attachedOilPump { get; set; }
        public bool? impellerOnMainShaft { get; set; }
        public bool? crankHasIntermediateBearing { get; set; }
        public bool? fanStages { get; set; }
        public bool? exciter { get; set; }
        public bool? centrifugalPumpHasBallBearings { get; set; }
        public bool? propellerpumpHasBallBearings { get; set; }
        public bool? rotaryThreadPumpHasBallBearings { get; set; }
        public bool? gearPumpHasBallBearings { get; set; }
        public bool? screwPumpHasBallBearings { get; set; }
        public bool? slidingVanePumpHasBallBearings { get; set; }
        public bool? axialRecipPumpHasBallBearings { get; set; }
        public bool? centrifugalCompressorHasBallBearings { get; set; }
        public bool? reciprocatingCompressorHasBallBearings { get; set; }
        public bool? screwCompressorHasBallBearings { get; set; }
        public bool? screwTwinCompressorHasBallBearingsOnHPSide { get; set; }
        public bool? lobedFanOrBlowerHasBallBearings { get; set; }
        public bool? overhungRotorFanOrBlowerHasBearings { get; set; }
        public bool? supportedRotorFanOrBlowerHasBearings { get; set; }
        public string exciterOverhungOrSupported { get; set; }
        public string bearingsType { get; set; }
        public string thrustBearing { get; set; }
        public string drivenBy { get; set; }
    }
}
