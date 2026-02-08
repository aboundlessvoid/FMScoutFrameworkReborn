using FMScoutFramework.Core.Entities.GameVersions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FMScoutFramework.Defines.Offsets
{
    public sealed class CityOffsets
    {
        public IVersion Version;

        public CityOffsets(IVersion version)
        {
            this.Version = version;
        }

        public const short RowID = 0x8;
        public const short ID = 0xC;
        public const short RandomID = 0x10;
        public const short Nation = 0x20;
        public const short Name = 0x18;
        public const short Attraction = 0x54;
        public const short Latitude = 0x48;
        public const short Longitude = 0x4C;
        public const short Altitude = 0x50;
        public const short Inhabitants = 0x52;
        public const short Weather = 0x28;
        public const short LocalRegion = 0x38;
    }
}