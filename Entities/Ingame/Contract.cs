using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Entities.InGame.Interfaces;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Contract : BaseObject, IContract
    {
        public ContractOffsets ContractOffsets;
		public Contract (Int64 memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{
            ContractOffsets = new ContractOffsets(version);
        }
		public Contract (Int64 memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{
            ContractOffsets = new ContractOffsets(version);
        }

		//public Team Team {
		//	get {
		//		return PropertyInvoker.GetPointer<Team> (ContractOffsets.Team, OriginalBytes, MemoryAddress, DatabaseMode, Version);
		//	}
		//}

		public JobType JobType {
			get {
				return (JobType)(PropertyInvoker.Get<byte>(ContractOffsets.JobType, OriginalBytes, MemoryAddress, DatabaseMode));
			}
		}

		public Int32 Wage {
			get {
				return PropertyInvoker.Get<Int32> (ContractOffsets.Wage, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public DateTime DateStarted {
			get {
				return PropertyInvoker.Get<DateTime> (ContractOffsets.DateStarted, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public DateTime DateExpires {
			get {
				return PropertyInvoker.Get<DateTime> (ContractOffsets.DateExpires, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public SquadStatus PlayingTime
        {
			get {
				return (SquadStatus)(PropertyInvoker.Get<sbyte> (ContractOffsets.PlayingTime, OriginalBytes, MemoryAddress, DatabaseMode));
			}
		}

		public SquadStatus PreviousPlayingTime
        {
			get {
				return (SquadStatus)(PropertyInvoker.Get<sbyte> (ContractOffsets.PreviousPlayingTime, OriginalBytes, MemoryAddress, DatabaseMode));
			}
		}

		public SquadStatus FuturePlayingTime
        {
			get {
				return (SquadStatus)(PropertyInvoker.Get<sbyte> (ContractOffsets.FuturePlayingTime, OriginalBytes, MemoryAddress, DatabaseMode));
			}
		}

		public short FuturePlayingTimeYear
        {
			get {
				return (PropertyInvoker.Get<Int16> (ContractOffsets.FuturePlayingTimeYear, OriginalBytes, MemoryAddress, DatabaseMode));
			}
		}

		public byte TransferStatus {
			get {
				return (PropertyInvoker.Get<byte> (ContractOffsets.TransferStatusFlags, OriginalBytes, MemoryAddress, DatabaseMode));
			}
		}

		public sbyte SquadNumber {
			get {
				return PropertyInvoker.Get<sbyte>(ContractOffsets.SquadNumber, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public sbyte PreferredSquadNumber
        {
			get {
				return PropertyInvoker.Get<sbyte>(ContractOffsets.PreferredSquadNumber, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public bool IsTransferListed
		{
			get {
				byte transferListed = 0b_10000000;
				return (this.TransferStatus & transferListed) != 0;
			}
		}

		public bool IsListedByRequest
        {
			get {
				byte listedByRequest = 0b_00010000;
				return (this.TransferStatus & listedByRequest) != 0;
			}
		}

		public bool IsNotForSale
        {
			get {
				byte notForSale = 0b_00001000;
				return (this.TransferStatus & notForSale) != 0;
			}
		}

		public bool IsSetForRelease
        {
			get {
				byte setForRelease = 0b_00000100;
				return (this.TransferStatus & setForRelease) != 0;
			}
		}

		public bool IsLoanListed
        {
			get {
				byte loanListed = 0b_01000000;
				return (this.TransferStatus & loanListed) != 0;
			}
		}

		public bool IsUnavailableForLoan
        {
			get {
				byte unavailableForLoan = 0b_00000010;
				return (this.TransferStatus & unavailableForLoan) != 0;
			}
		}

		//public ContractClause[] ContractClauses {
		//	get {
		//		long numberOfClauses = ProcessManager.ReadArrayLength (MemoryAddress + ContractOffsets.Clauses, ContractClausesOffsets.ClauseLength);
		//		ContractClause[] result = new ContractClause[numberOfClauses];
		//		for (int i = 0; i < numberOfClauses; i++) {
  //                  Int64 clauseAddress = PropertyInvoker.Get<Int64> (ContractOffsets.Clauses, OriginalBytes, MemoryAddress, DatabaseMode);
		//			result [i] = new ContractClause ((clauseAddress + (i * ContractClausesOffsets.ClauseLength)), Version);
		//		}

		//		return result;
		//	}
		//}

		//public ContractBonus[] ContractBonuses {
		//	get {
		//		long numberOfBonuses = ProcessManager.ReadArrayLength (MemoryAddress + ContractOffsets.Bonuses, ContractBonusOffsets.BonusLength);
		//		ContractBonus[] result = new ContractBonus[numberOfBonuses];
		//		for (int i = 0; i < numberOfBonuses; i++) {
  //                  Int64 bonusAddress = PropertyInvoker.Get<Int64> (ContractOffsets.Bonuses, OriginalBytes, MemoryAddress, DatabaseMode);
		//			result [i] = new ContractBonus ((bonusAddress + (i * ContractBonusOffsets.BonusLength)), Version);
		//		}

		//		return result;
		//	}
		//}

		public ContractType ContractType {
			get {
				return (ContractType)(PropertyInvoker.Get<sbyte> (ContractOffsets.ContractType, OriginalBytes, MemoryAddress, DatabaseMode));
			}
		}

		public sbyte PlayingTimeHappiness
		{
			get
			{
                return (PropertyInvoker.Get<sbyte>(ContractOffsets.PlayingTimeHappiness, OriginalBytes, MemoryAddress, DatabaseMode));
            }
        }

		public sbyte Happiness
		{
			get
			{
                return (PropertyInvoker.Get<sbyte>(ContractOffsets.Happiness, OriginalBytes, MemoryAddress, DatabaseMode));
            }
        }

		public int LoyaltyBonus
        {
			get
			{
                return (PropertyInvoker.Get<Int32>(ContractOffsets.LoyaltyBonus, OriginalBytes, MemoryAddress, DatabaseMode));
            }
        }

		public int AgentFees
        {
			get
			{
                return (PropertyInvoker.Get<Int32>(ContractOffsets.AgentFees, OriginalBytes, MemoryAddress, DatabaseMode));
            }
        }

		public DateTime DateSigned
        {
			get
			{
                return (PropertyInvoker.Get<DateTime>(ContractOffsets.DateSigned, OriginalBytes, MemoryAddress, DatabaseMode));
            }
        }
	}

	public enum JobType {
		Free = 0,
		Player = 1,
		Coach = 2,
		PlayerCoach = 3,
		Chairman = 4,
		Director = 6,
		ManagingDirector = 8,
		DirectorOfFootball = 10,
		Physio = 12,
		Scout = 14,
		Manager = 16,
		PlayerManager = 17,
		AssistantManager = 20,
		PlayerAssistantManager = 21,
		MediaPundit = 22,
		GeneralManager = 24,
		FitnessCoach = 26,
		PlayerFitnessCoach = 27,
		GoalkeeperCoach = 34,
		PlayerGoalkeeperCoach = 35,
		ChiefDataAnalyst = 36,
		ChiefDoctor = 38,
		HeadOfSportsScience = 40,
		DataAnalyst = 42,
		ChiefScout = 44,
		PlayerChiefScout = 45,
		Doctor = 46,
		SportsScientist = 48,
		PlayerYouthTeamCoach = 49,
		HeadOfPhysio = 50,
		U19Manager = 52,
		FirstTeamCoach = 54,
		HeadOfYouthDevelopment = 64,
        PlayerHeadOfYouthDevelopment = 65,
		Owner = 66,
		President = 70,
		LoanManager = 86,
        TechnicalDirector = 88,
		CaretakerManager = 144
	}

	public enum SquadStatus {
		Invalid = -1,
		NotSet = 0,
		StarPlayer = 1,
		ImportantPlayer = 2,
		RegularStarter = 3,
		SquadPlayer = 4,
		ImpactSub = 5,
		SquadPlayer2 = 6, // huh?
		FringerPlayer = 7,
		EmergencyBackup = 9,
		BreakthroughProspect = 10,
		FutureProspect = 11,
		HotProspect = 12,
		Youngster = 13,
		BTeamRegular = 14,
		FirstChoiceGoalkeeper = 15,
		CupGoalkeeper = 16,
		DemesticCupGoalkeeper = 17,
		ContinentalCupGoalkeeper = 18,
		CupGoalkeeper2 = 19,
		BackupGoalkeeper = 20,
		EmergencyBackupGoalkeeper = 21,
		SurplusToRequirements = 22
	}

	public enum ContractType {
		PartTime = 0,
		FullTime = 1,
		Amateur = 2,
		Youth = 3,
		NonContract = 4,
		FutureProfessional = 5,
		GenerationAdidasUSA = 7,
		SeniorMinimumSalaryUSA = 8,
		ReserveUSA = 9,
		DesignatedPlayerUSA = 11,
		DesignatedPlayer = 13,
		GuestPlayerAus = 16,
		MatureAgeRookiePlayerAus = 18,
		Invalid = -1
	}
}

