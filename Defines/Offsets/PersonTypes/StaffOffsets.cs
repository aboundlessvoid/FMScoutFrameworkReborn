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

        public short StaffAttributes
        {
            get
            {
                return 0x0;
            }
        }

        public short HomeReputation
        {
            get
            {
                return 0x0;
            }
        }

        public short CurrentReputation
        {
            get
            {
                return 0x0;
            }
        }

        public short WorldReputation
        {
            get
            {
                return 0x0;
            }
        }

        public short CurrentAbility
        {
            get
            {
                return 0x0;
            }
        }

        public short PotentialAbility
        {
            get
            {
                return 0x0;
            }
        }

        public short RowID
        {
            get
            {
                return 0x0;
            }
        }

        public short ID
        {
            get
            {
                return 0x0;
            }
        }

		public short PersonAddress {
			get
            {
				return 0x0;
			}
		}

		public short JobAttributes {
			get
            {
				return 0x0;
			}
		}
	}
}

