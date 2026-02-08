using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Offsets
{
	public sealed class NationOffsets
	{
        public IVersion Version;

        public NationOffsets(IVersion version)
        {
            this.Version = version;
        }

		public const short RowID = 0x8;
		public const short ID = 0xC;
        public const short RandomID = 0x10;
        //public const short Teams        = 0x10; // TODO:
        //public const short RivalNations = 0x28; // TODO:
        public const short Name = 0x18;
        public const short ShortName = 0x20;
        public const short ThreeLetterName = 0x28;
        public const short Nationality = 0x30;
        //public const short SpokenLanguages = 0x6C; // TODO:
        //public const short TaxRules = 0x78; // TODO:
        //public const short NationTransferPreferences = 0x90; // TODO:
        //public const short ContinentTransferPreferences = 0x9C; // TODO:
        //public const short RegionTransferPreferences = 0xA8; // TODO:
        public const short Capital = 0xE8;
        public const short Continent = 0xF0;
        //public const short Region = 0xE0; // TODO:
        //public const short Currency = 0xE4; // TODO:
        //public const short FIFAPosition = 0x15C; // TODO:
        //public const short FIFARankingPoints = 0x15E; // TODO:
        //public const short EUROCoefficients = 0x1BC; // TODO:
	}
}

