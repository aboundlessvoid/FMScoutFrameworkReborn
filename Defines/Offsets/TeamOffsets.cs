using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Offsets
{
	public sealed class TeamOffsets
	{
        public IVersion Version;

        public TeamOffsets(IVersion version)
        {
            this.Version = version;
        }

		public const short RowID = 0x8;
		public const short ID = 0xC;
		public const short RandomID = 0x10;
		public const short Club	= 0x30;
		//public const short PreviousReputation = 0x0;
		public const short TeamType = 0x28;
		//public const short Manager = 0x0;
        public const short Players = 0x38;
        //public const short Stadium = 0x0;
        public const short Reputation = 0xA8;
    }
}

