using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Offsets
{
	public sealed class ClubFinancesOffsets
	{
        public IVersion Version;

        public ClubFinancesOffsets(IVersion version)
        {
            this.Version = version;
        }

		public const short Balance = 0xC;
        public const short AverageTicketPrice = 0x10;
        public const short AverageSeasonTicketPrice = 0x14;
        public const short EmbargoStartDate = 0x24;
        public const short EmbargoEndDate = 0x28;
        public const short EmbargoAppealDate = 0x2C;
        public const short SugarDaddy = 0x31;
		public const short RemainingBudget = 0x3C;
		public const short SeasonTransferFunds = 0x40;
		public const short TransferIncomePercentage = 0x44;
		public const short YouthGrantIncome = 0x4C;
		public const short HighestWagePaid = 0x84;

        public short LatestSeasonTicketSales
        {
            get
            {
                return 0x0;
            }
        }

        public short WeeklyWageBudget
        {
            get
            {
                return 0x0; // TODO
            }
        }

        public short HighestWage
        {
            get
            {
                return 0x0; // TODO
            }
        }

        public short WeeklyWageBudgetUsed
        {
            get
            {
                return 0x0; // TODO
            }
        }

    }
}

