using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.DP.AbstractFactory
{
    //BaseClass
    public interface IConsumerElectronic
    {
    }

    #region Product type 1

    //Product type #1
    public class KitchAppliances : IConsumerElectronic
    {

    }
    public class Refrigerator : KitchAppliances
    { }
    public class Microwave : KitchAppliances
    { }
    #endregion
    

    #region Product type 2
    //Product type #2
    public class MediaAppliances : IConsumerElectronic
    {

    }
    public class Televison : MediaAppliances
    { }
    public class MusicSystem : MediaAppliances
    { }
    #endregion


    public interface IConsumerElectronicFactory
    { 
        
    }
    public class KitchApplianceFactory:IConsumerElectronicFactory
    { 
        
    }
    public class MediaApplianceFactory : IConsumerElectronicFactory
    { }
}
