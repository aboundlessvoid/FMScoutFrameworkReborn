using System;
using System.Collections.Generic;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Entities.InGame.Interfaces;
using FMScoutFramework.Core.Utilities;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class ClubFinances : BaseObject, IClubFinances
    {
        public ClubFinancesOffsets ClubFinancesOffsets;
		public ClubFinances (Int64 memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{
            this.ClubFinancesOffsets = new ClubFinancesOffsets(version);
        }
		public ClubFinances (Int64 memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{
            this.ClubFinancesOffsets = new ClubFinancesOffsets(version);
        }

		public int Balance {
			get {
                return 0;
			}
            set
            {
            }
		}

		public int RemainingBudget {
			get {
				return PropertyInvoker.Get<Int32> (ClubFinancesOffsets.RemainingBudget, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<Int32>(ClubFinancesOffsets.RemainingBudget, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public int SeasonTransferFunds {
			get {
				return PropertyInvoker.Get<Int32> (ClubFinancesOffsets.SeasonTransferFunds, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<Int32>(ClubFinancesOffsets.SeasonTransferFunds, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public int TransferIncomePercentage {
			get {
				return PropertyInvoker.Get<Int32> (ClubFinancesOffsets.TransferIncomePercentage, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<Int32>(ClubFinancesOffsets.TransferIncomePercentage, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public int YouthGrantIncome {
			get {
				return PropertyInvoker.Get<Int32> (ClubFinancesOffsets.YouthGrantIncome, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<Int32>(ClubFinancesOffsets.YouthGrantIncome, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public int WeeklyWageBudget {
			get {
				return PropertyInvoker.Get<Int32> (ClubFinancesOffsets.WeeklyWageBudget, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<Int32>(ClubFinancesOffsets.WeeklyWageBudget, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

        public int HighestWage
        {
            get
            {
                return PropertyInvoker.Get<Int32>(ClubFinancesOffsets.HighestWage, OriginalBytes, MemoryAddress, DatabaseMode);
            }
            set
            {
                PropertyInvoker.Set<Int32>(ClubFinancesOffsets.HighestWage, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

        public int HighestWagePaid {
			get {
				return PropertyInvoker.Get<Int32> (ClubFinancesOffsets.HighestWagePaid, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<Int32>(ClubFinancesOffsets.HighestWagePaid, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public Int64 LatestSeasonTicketsAddress {
			get {
				return PropertyInvoker.Get<Int64> (ClubFinancesOffsets.LatestSeasonTicketSales, OriginalBytes, MemoryAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<Int64>(ClubFinancesOffsets.LatestSeasonTicketSales, OriginalBytes, MemoryAddress, DatabaseMode, value);
            }
        }

		public int LastestSeasonTickets {
			get {
				return PropertyInvoker.Get<Int32> (0x0, OriginalBytes, this.LatestSeasonTicketsAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<Int32>(0x0, OriginalBytes, this.LatestSeasonTicketsAddress, DatabaseMode, value);
            }
        }
	}
}