using FMScoutFramework.Core.Entities.GameVersions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMScoutFramework.Defines.Offsets
{
    internal class ContinentOffsets
    {
        public IVersion Version;

        public ContinentOffsets(IVersion version)
        {
            this.Version = version;
        }

        public const short RowID = 0x8;
        public const short ID = 0xC;
        public const short RandomID = 0x10;
        public const short Name = 0x18;
        public const short ThreeLetterName = 0x20;
        public const short ContinentalityName = 0x28;
        public const short FederationName = 0x30;
        public const short ShortFederationName = 0x40;
        //public const short RegionalStrength = 0x0; TODO: ?
        public const short ForegroundColor = 0x48;
        public const short BackgroundColor = 0x4C;
        public const short TrimColor = 0x50;
    }
}
