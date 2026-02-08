using FMScoutFramework.Core.Entities.GameVersions;
using System;

namespace FMScoutFramework.Core.Offsets
{
	public sealed class ContractOffsets
	{
        public IVersion Version;

        public ContractOffsets(IVersion Version)
        {
            this.Version = Version;
        }

        public const short Person = 0x8;
		public const short Club = 0x10; // also at 0x18?!
		public const short JobType = 0x26;
		public const short Wage = 0x20;
		public const short DateStarted = 0x44;
		public const short DateExpires = 0x48;
		public const short DateSigned = 0x4C;
		public const short PlayingTime = 0x54;
		public const short PreviousPlayingTime = 0x55;
		public const short FuturePlayingTime = 0xB8;
		public const short FuturePlayingTimeYear = 0xBC;
		public const short TransferStatusFlags = 0x57;
        //public const short Clauses = 0x3C; // TODO: at 0x68?
		//public const short Bonuses = 0x48; // TODO: also at 0x68?
		public const short ContractType = 0xC3;
		public const short SquadNumber = 0x5D;
		public const short PreferredSquadNumber = 0x48;
		public const short LoyaltyBonus = 0xA8;
		public const short AgentFees = 0xAC;
		public const short PlayingTimeHappiness = 0x5C;
		public const short Happiness = 0x5A;
		// 0x68
		// 0x130
	}
}

