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

		public const short RowID				= 0x4;
		public const short ID					= 0x8;
		public const short Club					= 0x10;
		public const short PreviousReputation	= 0x1A;
		public const short TeamType 			= 0x1C;
		public const short Manager				= 0x4C;

        public short Players
        {
            get
            {
                return 0x0; // TODO
            }
        }

        public short Stadium
        {
            get
            {
                return 0x0; // TODO
            }
        }

        public short Reputation
        {
            get
            {
                return 0x0; // TODO
            }
        }
	}
}

