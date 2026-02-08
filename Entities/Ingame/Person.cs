using System;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Entities.InGame.Interfaces;
using FMScoutFramework.Core.Utilities;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Person : BaseObject, IPerson
    {
		public PersonOffsets PersonOffsets;
		public Person (Int64 memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{
			this.PersonOffsets = new PersonOffsets(version);
		}
		public Person (Int64 memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{
			this.PersonOffsets = new PersonOffsets(version);
		}

		protected virtual Int64 PersonAddress {
			get {
				return (MemoryAddress + Version.PersonOffsets.Person);
			}
		}

		public DateTime DateOfBirth {
			get {
				return PropertyInvoker.Get<DateTime>(PersonOffsets.DateOfBirth, OriginalBytes, PersonAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<DateTime>(PersonOffsets.DateOfBirth, OriginalBytes, PersonAddress, DatabaseMode, value);
            }
		}

		public int Age {
			get {
				DateTime now = DateTime.Today; //  TODO: should be in relation to game date, not real life date
				int age = now.Year - DateOfBirth.Year;
				if (DateOfBirth > now.AddYears (-age))
					age--;
				return age;
			}
		}

		public string Fullname {
			get {
				return PropertyInvoker.GetString(PersonOffsets.Fullname, -1, OriginalBytes, PersonAddress, DatabaseMode);
			}
		}

		public string Nickname {
			get {
				return PropertyInvoker.GetString(PersonOffsets.Nickname, Version.MemoryAddresses.StringOffset, OriginalBytes, PersonAddress, DatabaseMode);
			}
		}

		public string Firstname {
			get {
				return PropertyInvoker.GetString(PersonOffsets.Firstname, Version.MemoryAddresses.StringOffset, OriginalBytes, PersonAddress, DatabaseMode);
			}
		}

		public string Lastname {
			get {
				return PropertyInvoker.GetString(PersonOffsets.Lastname, Version.MemoryAddresses.StringOffset, OriginalBytes, PersonAddress, DatabaseMode);
			}
		}

		public Nation Nationality
		{
			get
			{
				return PropertyInvoker.GetPointer<Nation>(PersonOffsets.Nationality, OriginalBytes, PersonAddress, DatabaseMode, Version);
			}
		}

		public PersonAttributes Attributes {
			get {
                Int64 AttributesAddress = PersonAddress + PersonOffsets.Attributes;
				return new PersonAttributes (AttributesAddress, Version);
			}
		}

		public Contract Contract
		{
			get
			{
				return PropertyInvoker.GetPointer<Contract>(PersonOffsets.Contract, OriginalBytes, PersonAddress, DatabaseMode, Version);
			}
		}

		//public Club Club {
		//	get {
		//		return PropertyInvoker.GetPointer<Club> (PersonOffsets.Club, OriginalBytes, PersonAddress, DatabaseMode, Version);
		//	}
		//}
		public int RowID
        {
            get
            {
                return PropertyInvoker.Get<Int32>(PersonOffsets.RowID, OriginalBytes, PersonAddress, DatabaseMode);
            }
        }

        public int ID
        {
            get
            {
                return PropertyInvoker.Get<Int32>(PersonOffsets.ID, OriginalBytes, PersonAddress, DatabaseMode);
            }
        }

        public byte InternationalApps
        {
            get
            {
                return PropertyInvoker.Get<byte>(PersonOffsets.InternationalApps, OriginalBytes, PersonAddress, DatabaseMode);
            }
        }

        public byte U21InternationalApps
        {
            get
            {
                return PropertyInvoker.Get<byte>(PersonOffsets.U21InternationalApps, OriginalBytes, PersonAddress, DatabaseMode);
            }
        }

        public byte InternationalGoals
        {
            get
            {
                return PropertyInvoker.Get<byte>(PersonOffsets.InternationalGoals, OriginalBytes, PersonAddress, DatabaseMode);
            }
        }

        public byte U21InternationalGoals
        {
            get
            {
                return PropertyInvoker.Get<byte>(PersonOffsets.U21InternationalGoals, OriginalBytes, PersonAddress, DatabaseMode);
            }
        }
    }
}