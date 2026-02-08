using System;

namespace FMScoutFramework.Core.Entities.GameVersions
{
	public interface IVersionPersonEnumPointers
	{
        ushort Player { get; }
        ushort Staff { get; }
        ushort PlayerStaff { get; }
        //ushort HumanManager { get; }
        ushort Official { get; }
	}
}