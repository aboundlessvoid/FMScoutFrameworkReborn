using System;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Entities.InGame.Interfaces;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Staff : Person, IStaff
    {
		private readonly StaffOffsets StaffOffsets;
		public Staff (Int64 memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{	
			this.StaffOffsets = new StaffOffsets (version);
		}
		public Staff (Int64 memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{	
			this.StaffOffsets = new StaffOffsets (version);
		}

		protected override Int64 PersonAddress {
			get {
				return MemoryAddress;
			}
		}

		private Int64 StaffAddress {
			get {
				return MemoryAddress + Version.PersonOffsets.Staff;
			}
		}

        public short CurrentReputation
		{
			get {
				return PropertyInvoker.Get<short>(StaffOffsets.CurrentReputation, OriginalBytes, StaffAddress, DatabaseMode);
			}
		}

        public short HomeReputation
        {
			get {
				return PropertyInvoker.Get<short>(StaffOffsets.HomeReputation, OriginalBytes, StaffAddress, DatabaseMode);
			}
		}

        public short WorldReputation
        {
			get {
				return PropertyInvoker.Get<short>(StaffOffsets.WorldReputation, OriginalBytes, StaffAddress, DatabaseMode);
			}
		}

        public ushort CA
        {
            get
            {
                return PropertyInvoker.Get<ushort>(StaffOffsets.CA, OriginalBytes, StaffAddress, DatabaseMode);
            }
            set
            {
                PropertyInvoker.Set<ushort>(StaffOffsets.CA, OriginalBytes, StaffAddress, DatabaseMode, value);
            }
        }

        public ushort PA
        {
            get
            {
                return PropertyInvoker.Get<ushort>(StaffOffsets.PA, OriginalBytes, StaffAddress, DatabaseMode);
            }
            set
            {
                PropertyInvoker.Set<ushort>(StaffOffsets.PA, OriginalBytes, StaffAddress, DatabaseMode, value);
            }
        }

        public JobAttributes JobAttributes
        {
            get
            {
                long startAddress = StaffAddress + StaffOffsets.JobAttributes;
                return new JobAttributes(startAddress, Version);
            }
        }

    }
}

