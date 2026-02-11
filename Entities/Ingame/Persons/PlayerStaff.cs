using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Entities.InGame.Interfaces;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class PlayerStaff : BaseObject
	{
		public Player playerObject;
		public Staff staffObject;

		public PlayerStaff (Int64 memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{
			playerObject = new Player(memoryAddress, version);
			staffObject = new Staff(memoryAddress, version);
		}
		public PlayerStaff (Int64 memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{
			playerObject = new Player(memoryAddress, originalBytes, version);
            staffObject = new Staff(memoryAddress, originalBytes, version);
		}
	}
}

