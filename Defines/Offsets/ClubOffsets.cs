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

		public const short RowID = 0x8;
		public const short ID = 0xC;
		public const short RandomID = 0x10;
		public const short Teams = 0x18;
        public const short FullName = 0xC0;
        public const short ShortName = 0xC8;
        public const short SixLetterName = 0x100;
        public const short Nation = 0xD8;
        public const short BasedNation = 0xE8;
        public const short ContinentalCupNation = 0xF0;
        public const short City = 0xF8;
        //public const short ClubSponsorshipDeals = 0x0;
        public const short ClubFinances = 0x150;
        // 0x30 is probably a list of second team and other affiliates where you can directly take control?
        // 0x48 other affiliates?
        // 0x60, 0x78, 0x90 other lists
    }
}
