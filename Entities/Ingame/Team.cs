using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Entities.InGame.Interfaces;
using FMScoutFramework.Core.Utilities;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Team : BaseObject, ITeam
    {
        public TeamOffsets TeamOffsets;
		public Team (Int64 memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{
            this.TeamOffsets = new TeamOffsets(version);
        }
		public Team (Int64 memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{
            this.TeamOffsets = new TeamOffsets(version);
        }

		public int RowID {
			get {
				return PropertyInvoker.Get<Int32>(TeamOffsets.RowID, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public int ID {
			get {
				return PropertyInvoker.Get<Int32> (TeamOffsets.ID, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public int RandomID
        {
			get {
				return PropertyInvoker.Get<Int32> (TeamOffsets.RandomID, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public Club Club {
			get {
				return PropertyInvoker.GetPointer<Club> (TeamOffsets.Club, OriginalBytes, MemoryAddress, DatabaseMode, Version);
			}
		}

		public Player[] Players {
			get {
                long playerCount = ProcessManager.ReadArrayLength(MemoryAddress + TeamOffsets.Players);
                Player[] result = new Player[playerCount];

                for (int i = 0; i < playerCount; i++)
                {
                    Int64 playerAddress = PropertyInvoker.Get<Int64>(TeamOffsets.Players, OriginalBytes, MemoryAddress, DatabaseMode);
                    result[i] = PropertyInvoker.GetPointer<Player>(0x0, OriginalBytes, (playerAddress + (i * 8)), DatabaseMode, Version, -Version.PersonOffsets.Player);
                }

				return result;
			}
		}

		//private short PreviousReputation {
		//	get {
		//		return PropertyInvoker.Get<Int16> (TeamOffsets.PreviousReputation, OriginalBytes, MemoryAddress, DatabaseMode);
		//	}
		//}

		public TeamType TeamType {
			get {
				return (TeamType)PropertyInvoker.Get<byte>(TeamOffsets.TeamType, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public ushort Reputation {
			get
			{
                return PropertyInvoker.Get<UInt16>(TeamOffsets.Reputation, OriginalBytes, MemoryAddress, DatabaseMode);
            }
		}

		public override string ToString ()
		{
			if (this.Club.FullName != "-")
				return string.Format ("{0} ({1})", this.Club.FullName, this.TeamType.ToString());
			else 
				return "-";
		}
	}

	// TODO: check and update
	public enum TeamType {
		First 				= 0,
		Reserves 			= 1,
		A					= 2,
		B 					= 3,
		SuperdraftA			= 4,
		SuperdraftB			= 5,
		SuperdraftC			= 6,
		SuperdraftD			= 7,
		Waivers				= 8,
		U23 				= 9,
		U21 				= 10,
		U19 				= 11,
		U18 				= 12,
		C 					= 13,
		Amateur 			= 14,
		II 					= 15,
		Team2 				= 16,
		Team3 				= 17,
		U20 				= 18,
		YouthEvaluation 	= 22,
		DutchReserves 		= 30
	}
}