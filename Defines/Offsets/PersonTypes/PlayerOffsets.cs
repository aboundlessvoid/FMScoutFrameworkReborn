using System;
using FMScoutFramework.Core.Entities.GameVersions;

namespace FMScoutFramework.Core.Offsets
{
	public sealed class PlayerOffsets
	{

        public IVersion Version;

        public PlayerOffsets(IVersion version) {
            this.Version = version;
        }

        public short PlayerStats
        {
            get
            {
                return 0x150;
            }
        }

        //public short Injuries
        //{
        //    get
        //    {
        //        return 0x0; // TODO:
        //    }
        //}

        //public short BansOffset
        //{
        //    get
        //    {
        //        return 0x0; // TODO:
        //    }
        //}

        //public short Team
        //{
        //    get
        //    {
        //        return 0x0; // TODO:
        //    }
        //}

        public short Value
        {
            get
            {
                return 0x234;
            }
        }

        public short AskingPrice
        {
            get
            {
                return 0x238;
            }
        }

        // TODO: possible rename to Physical Condition
        public short Fitness
        {
            get
            {
                return 0x25C;
            }
        }

        // TODO: possibly rename to Fatigue
        public short Jadedness
        {
            get
            {
                return 0x25A;
            }
        }

        // TODO: likely rename to Match Sharpness
        public short Condition
        {
            get
            {
				return 0x258;
            }
        }

        public short HomeReputation
        {
            get
            {
				return 0x25E;
            }
        }

        public short CurrentReputation
        {
            get
            {
				return 0x260;
            }
        }

        public short WorldReputation
        {
            get
            {
				return 0x262;
            }
        }

        public short CA
        {
            get
            {
				return 0x264;
            }
        }

        public short PA
        {
            get
            {
				return 0x266;
            }
        }

        public short BodyType
        {
            get
            {
                return 0x230;
            }
        }

        public short Height
        {
            get
            {
                return 0x22E;
            }
        }

        public short Morale
        {
            get
            {
                return 0x26C;
            }
        }

        public short PreferredCentralPosition
        {
            get
            {
                return 0x276;
            }
        }

        public short RoleUsedToFillEmptyAttributes
        {
            get
            {
                return 0x277;
            }
        }
    }
}

