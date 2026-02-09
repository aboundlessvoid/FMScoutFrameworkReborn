using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Offsets
{
	public sealed class StaffOffsets
	{

		public IVersion Version;

		public StaffOffsets(IVersion version) {
			this.Version = version;
		}

        public const short HomeReputation = 0xD4;
        public const short CurrentReputation = 0xD6;
        public const short WorldReputation = 0xD8;
        public const short CA = 0xDA;
        public const short PA = 0xDC;
        public const short JobAttributes = 0x10;
    }
}

