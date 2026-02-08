using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Entities.InGame.Interfaces;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Club : BaseObject, IClub
    {
        public ClubOffsets ClubOffsets;
		public Club (Int64 memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{
            this.ClubOffsets = new ClubOffsets(Version);
        }
		public Club (Int64 memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{
            this.ClubOffsets = new ClubOffsets(Version);
        }

		public Int32 RowID {
			get {
				return PropertyInvoker.Get<Int32> (ClubOffsets.RowID, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public Int32 ID { 
			get {
				return PropertyInvoker.Get<Int32> (ClubOffsets.ID, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public Int32 RandomID
        { 
			get {
				return PropertyInvoker.Get<Int32> (ClubOffsets.RandomID, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public Team[] Teams {
			get {
				long teamCount = ProcessManager.ReadArrayLength (MemoryAddress + ClubOffsets.Teams);
				Team[] result = new Team[teamCount];

				for(int i = 0; i < teamCount; i++) {
                    Int64 teamAddress = PropertyInvoker.Get<Int64> (ClubOffsets.Teams, OriginalBytes, MemoryAddress, DatabaseMode);
					result [i] = PropertyInvoker.GetPointer<Team> (0x0, OriginalBytes, (teamAddress + (i * 8)), DatabaseMode, Version);
				}

				return result;
			}
		}

		public string FullName { 
			get {
				return PropertyInvoker.GetString (ClubOffsets.FullName, -1, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public string ShortName {
			get {
				return PropertyInvoker.GetString (ClubOffsets.ShortName, -1, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public string SixLetterName
        {
			get {
				return PropertyInvoker.GetString (ClubOffsets.SixLetterName, 0, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public City City
        {
			get {
                return PropertyInvoker.GetPointer<City>(ClubOffsets.City, OriginalBytes, MemoryAddress, DatabaseMode, Version);
            }
        }

		public Nation Nation {
			get {
				return PropertyInvoker.GetPointer<Nation> (ClubOffsets.Nation, OriginalBytes, MemoryAddress, DatabaseMode, Version);
			}
		}

		public Nation BasedNation {
			get {
				return PropertyInvoker.GetPointer<Nation> (ClubOffsets.BasedNation, OriginalBytes, MemoryAddress, DatabaseMode, Version);
			}
		}

		//public int ClubFinancesAddress {
		//	get {
		//		return PropertyInvoker.Get<Int32> (ClubOffsets.ClubFinances, OriginalBytes, MemoryAddress, DatabaseMode);
		//	}
		//}

		//public ClubFinances ClubFinances {
		//	get {
		//		return PropertyInvoker.GetPointer<ClubFinances> (ClubOffsets.ClubFinances, OriginalBytes, MemoryAddress, DatabaseMode, Version);
		//	}
		//}

		public Nation ContinentalCupNation
		{
            get
            {
                return PropertyInvoker.GetPointer<Nation>(ClubOffsets.ContinentalCupNation, OriginalBytes, MemoryAddress, DatabaseMode, Version);
            }
        }

        public override string ToString ()
		{
			return FullName;
		}
	}
}

