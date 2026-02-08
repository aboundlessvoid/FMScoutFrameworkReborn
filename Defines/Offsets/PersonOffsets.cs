using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Offsets
{
	public sealed class PersonOffsets
	{
		public IVersion Version;

		public PersonOffsets(IVersion version)
		{
			this.Version = version;
		}

		public short DateOfBirth
		{
			get
			{
                return 0x88;
			}
		}

		public short Fullname
		{
			get
			{
                return 0x40;
			}
		}

		public short Firstname
		{
			get
			{
                return 0x50;
			}
		}

		public short Lastname
		{
			get
			{
                return 0x58;
			}
		}

		public short Nickname
		{
			get
			{
                return 0x60;
			}
		}

		public short CityOfBirth
		{
			get
			{
                return 0x80;
			}
		}

		public short Nationality
		{
			get
			{
				return 0x68;
			}
		}

		public short Attributes
		{
			get
			{
                return 0x70;
			}
		}

		public short Contract
		{
			get
			{
				return 0xA8;
			}
		}

		//public short Club
		//{
		//	get
		//	{
		//              if (Version.GetType() == typeof(Steam_16_3_2_Windows))
		//                  return 0x10;
		//              else
		//                  return 0x22C;
		//	}
		//}
		public short InternationalApps
        {
            get
            {
                return 0x134;
            }
        }

        public short U21InternationalApps
        {
            get
            {
                return 0x138;
            }
        }

        public short InternationalGoals
        {
            get
            {
                return 0x136;
            }
        }

        public short U21InternationalGoals
        {
            get
            {
                return 0x13A;
            }
        }

        public short RowID
        {
            get
            {
                return 0x8;
            }
        }

        public short ID
        {
            get
            {
                return 0xC;
            }
        }
    }
}
