using System;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Entities.InGame.Interfaces;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Defines.Offsets;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Continent : BaseObject, IContinent
    {
		public Continent (Int64 memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{	}
		public Continent (Int64 memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{	}

		public int RowID
		{
			get
			{
				return PropertyInvoker.Get<Int32>(ContinentOffsets.RowID, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public int ID
		{
			get
			{
				return PropertyInvoker.Get<Int32>(ContinentOffsets.ID, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public int RandomID
		{
			get
			{
				return PropertyInvoker.Get<Int32>(ContinentOffsets.RandomID, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public string Name
		{
			get
			{
				return PropertyInvoker.GetString(ContinentOffsets.Name, -1, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public string ThreeLetterName
        {
			get
			{
				return PropertyInvoker.GetString(ContinentOffsets.ThreeLetterName, -1, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public string ContinentalityName
        {
			get
			{
				return PropertyInvoker.GetString(ContinentOffsets.ContinentalityName, -1, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public string FederationName
        {
			get
			{
				return PropertyInvoker.GetString(ContinentOffsets.FederationName, -1, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public string ShortFederationName
        {
			get
			{
				return PropertyInvoker.GetString(ContinentOffsets.ShortFederationName, -1, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public string ForegroundColor
        {
			get
			{
				return PropertyInvoker.GetHexColorValue(ContinentOffsets.ForegroundColor, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public string BackgroundColor
        {
			get
			{
				return PropertyInvoker.GetHexColorValue(ContinentOffsets.BackgroundColor, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}

		public string TrimColor
        {
			get
			{
				return PropertyInvoker.GetHexColorValue(ContinentOffsets.TrimColor, OriginalBytes, MemoryAddress, DatabaseMode);
			}
		}
	}
}

