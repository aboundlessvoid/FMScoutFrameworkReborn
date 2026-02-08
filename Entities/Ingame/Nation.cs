using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Entities.InGame.Interfaces;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Defines.Offsets;
using System;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Nation : BaseObject, INation
    {
        public NationOffsets NationOffsets;
		public Nation (Int64 memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{
            this.NationOffsets = new NationOffsets(Version);
        }
		public Nation (Int64 memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{
            this.NationOffsets = new NationOffsets(Version);
        }

        public int RowID
        {
            get
            {
                return PropertyInvoker.Get<Int32>(NationOffsets.RowID, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public int ID
        {
            get
            {
                return PropertyInvoker.Get<Int32>(NationOffsets.ID, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public int RandomID
        {
            get
            {
                return PropertyInvoker.Get<Int32>(NationOffsets.RandomID, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        //public Team[] Teams
        //{
        //    get
        //    {
        //        long teamCount = ProcessManager.ReadArrayLength(MemoryAddress + NationOffsets.Teams);
        //        Team[] result = new Team[teamCount];

        //        for (int i = 0; i < teamCount; i++)
        //        {
        //            Int64 teamAddress = PropertyInvoker.Get<Int64>(NationOffsets.Teams, OriginalBytes, MemoryAddress, DatabaseMode);
        //            result[i] = PropertyInvoker.GetPointer<Team>(0x0, OriginalBytes, (teamAddress + (i * 8)), DatabaseMode, Version);
        //        }

        //        return result;
        //    }
        //}

        //public RivalNation[] RivalNations
        //{
        //    get
        //    {
        //        long nationCount = ProcessManager.ReadArrayLength(MemoryAddress + NationOffsets.RivalNations, 0xC);
        //        RivalNation[] result = new RivalNation[nationCount];

        //        for (int i = 0; i < nationCount; i++)
        //        {
        //            Int64 nationAddress = PropertyInvoker.Get<Int64>(NationOffsets.RivalNations, OriginalBytes, MemoryAddress, DatabaseMode);
        //            result[i] = new RivalNation((nationAddress + (i * 0xC)), Version);
        //        }

        //        return result;
        //    }
        //}

        public string Name {
            get {
                return PropertyInvoker.GetString(NationOffsets.Name, -1, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public string ShortName {
            get {
                return PropertyInvoker.GetString (NationOffsets.ShortName, -1, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public string ThreeLetterName {
            get {
                return PropertyInvoker.GetString (NationOffsets.ThreeLetterName, -1, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public string NationalityName {
            get {
                return PropertyInvoker.GetString (NationOffsets.Nationality, -1, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

        public Continent Continent
        {
            get
            {
                return PropertyInvoker.GetPointer<Continent>(NationOffsets.Continent, OriginalBytes, MemoryAddress, DatabaseMode, Version);
            }
        }

		public override string ToString ()
		{
			return Name;
		}
	}
}

