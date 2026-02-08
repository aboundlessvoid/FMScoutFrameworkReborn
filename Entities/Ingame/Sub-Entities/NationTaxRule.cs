using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Entities.InGame.Interfaces;

namespace FMScoutFramework.Core.Entities.InGame
{
    public class NationTaxRule : BaseObject, INationTaxRule
    {
        public NationTaxRule (Int64 memoryAddress, IVersion version)
            : base(memoryAddress, version)
        { }
        public NationTaxRule (Int64 memoryAddress, ArraySegment<byte> originalBytes, IVersion version)
            : base(memoryAddress, originalBytes, version)
        { }
    }
}

