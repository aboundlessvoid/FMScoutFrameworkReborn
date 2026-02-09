using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMScoutFramework.Core.Entities.GameVersions
{
    internal class Steam_26_1_2_Windows : IIVersion
    {
        public IVersionMemoryAddresses MemoryAddresses { get; private set; }
        public IVersionPersonEnumPointers PersonEnum { get; private set; }
        public IPersonVersionOffsets PersonOffsets { get; private set; }

        public Steam_26_1_2_Windows()
        {
            MemoryAddresses = new VersionMemoryAddresses();
            PersonEnum = new VersionPersonEnumPointers();
            PersonOffsets = new PersonVersionOffsets();
        }

        public string Description
        {
            get { return "26.1.2 Steam"; }
        }

        public string MainVersionNumber
        {
            get { return "26"; }
        }

        public bool SupportsProcess(FMProcess process, byte[] context)
        {
#if LINUX || MAC
			return false;
#endif

#if WINDOWS
            if (process.VersionDescription != "6000.0.52f1-fm26-05f1 (87a0370e9917)") return false;

            return true;
#endif
        }

        public class VersionMemoryAddresses : IVersionMemoryAddresses
        {
            public Int64 MainAddress { get { return 0x04DE1848; } }
            public Int64 MainOffset { get { return 0x0; } }
            public Int64 XorDistance { get { return 0x80; } } // TODO: rename
            public int StringOffset { get { return 0x0; } }

            [MemoryAddressAttribute(CountLength = 8, BytesToSkip = 0x20)]
            public Int64 Continent { get { return 0x0; } }
            [MemoryAddressAttribute(CountLength = 8, BytesToSkip = 0x68)]
            public Int64 Person { get { return 0x0; } }
            [MemoryAddressAttribute(CountLength = 8, BytesToSkip = 0x28)]
            public Int64 Nation { get { return 0x0; } }
            [MemoryAddressAttribute(CountLength = 8, BytesToSkip = 0x8)]
            public Int64 City { get { return 0x0; } }
            [MemoryAddressAttribute(CountLength = 8, BytesToSkip = 0x10)]
            public Int64 Club { get { return 0x0; } }
            [MemoryAddressAttribute(CountLength = 8, BytesToSkip = 0x98)]
            public Int64 Team { get { return 0x0; } }
            public Int64 CurrentDateTime { get { return 0x04D8C9D8; } } // TODO: not sure if this is stable
        }
        public class VersionPersonEnumPointers : IVersionPersonEnumPointers
        {
            public ushort Player { get { return 0xFD08; } }
            public ushort Staff { get { return 0x7528; } }
            //public ushort NonPlayer { get { return 0x2263EBC; } }
            public ushort PlayerStaff { get { return 0xF6E8; } }
            //public ushort HumanManager { get { return 0x02776720; } }
            public ushort Official { get { return 0xE1C8; } }
            public ushort RetiredPerson { get { return 0xDE48; } }
            //public ushort Journalist { get { return 0x226A7C4; } }
        }

        /// <summary>
        /// How many bytes the pointer should be corrected for persons.
        /// </summary>
        public class PersonVersionOffsets : IPersonVersionOffsets
        {
            public int Person { get { return 0x0; } }
            public int Player { get { return -0x288; } }
            public int Staff { get { return -0x100; } }
            public int NonPlayer { get { return 0x0; } }
            public int HumanManager { get { return 0x0; } }
            public int PlayerStaff { get { return 0x0; } }
            public int Official { get { return 0x0; } }
            public int Retired { get { return 0x0; } }
            public int Journalist { get { return 0x0; } }
        }
    }
}
