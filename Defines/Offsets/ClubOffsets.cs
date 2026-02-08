using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Offsets
{
	public sealed class ClubOffsets
	{
        public IVersion Version;

        public ClubOffsets(IVersion version)
        {
            this.Version = version;
        }

        // Consts are the same for every version
		public const short RowID			= 0x4;
		public const short ID				= 0x8;
		public const short Teams 			= 0x10;
        public const short ClubDetailsOne   = 0x50;

        public short Fullname
        {
            get
            {
                return 0x0; // TODO
            }
        }

        public short Name
        {
            get
            {
                return 0x0; // TODO
            }
        }

        public short ShortName
        {
            get
            {
                return 0x0; // TODO
            }
        }

        public short Nation
        {
            get
            {
                return 0x0; // TODO
            }
        }

        public short BasedNation
        {
            get
            {
                return 0x0; // TODO
            }
        }

        public short City
        {
            get
            {
                return 0x0; // TODO
            }
        }

        public short ClubDetailsTwo
        {
            get
            {
                return 0x0; // TODO
            }
        }

        public short ClubSponshorshipDeals
        {
            get
            {
                return 0x0; // TODO
            }
        }

        public short ClubFinances
        {
            get
            {
                return 0x0; // TODO
            }
        }
	}
}
