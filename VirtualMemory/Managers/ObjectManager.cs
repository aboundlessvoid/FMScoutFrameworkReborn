using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Diagnostics;
using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Entities;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Entities.InGame;

namespace FMScoutFramework.Core.Managers
{
	public static class ObjectManagerWrapper
	{
		public static Dictionary<DatabaseModeEnum, ObjectManager> ObjectManagers =
			new Dictionary<DatabaseModeEnum, ObjectManager>();

		public static StaffMemoryAddressesWrapper StaffMemoryCache;
	}

	public class ObjectManager
	{
		public Dictionary<Type, object>ObjectStore = new Dictionary<Type, object>();
		private const int BufferSizeStaff = 16*1024*1024;
		public readonly DatabaseModeEnum DatabaseMode;
		public readonly GameManager GameManager;

		public ObjectManager (GameManager gameManager, DatabaseModeEnum databaseMode)
		{
			DatabaseMode = databaseMode;
			GameManager = gameManager;

			if (!ObjectManagerWrapper.ObjectManagers.ContainsKey (databaseMode)) {
				ObjectManagerWrapper.ObjectManagers.Add (databaseMode, null);
			}
			ObjectManagerWrapper.ObjectManagers [databaseMode] = this;
		}

		public void Load(bool refreshPersonCache)
		{
			ObjectStore.Clear ();

			if (ObjectManagerWrapper.StaffMemoryCache == null && !refreshPersonCache) {
				ObjectManagerWrapper.StaffMemoryCache = GetPersonMemoryAddresses (BufferSizeStaff);
			}
			var staffAddresses = ObjectManagerWrapper.StaffMemoryCache;

			ObjectStore.Add (typeof(Continent), RetrieveObjects<Continent> (m => m.Continent, m => m.Continent));
			ObjectStore.Add (typeof(Nation), RetrieveObjects<Nation>(m => m.Nation, m => m.Nation));
			ObjectStore.Add (typeof(City), RetrieveObjects<City> (m => m.City, m => m.City));
			ObjectStore.Add (typeof(Club), RetrieveObjects<Club> (m => m.Club, m => m.Club));
            ObjectStore.Add (typeof(Team), RetrieveObjects<Team> (m => m.Team, m => m.Team));

            #region People
            ObjectStore.Add (typeof(Player), RetrieveObjects<Player> (staffAddresses.PlayerAddresses));
			ObjectStore.Add (typeof(Staff), RetrieveObjects<Staff> (staffAddresses.StaffAddresses));
			//ObjectStore.Add (typeof(PlayerStaff), RetrieveObjects<PlayerStaff>(staffAddresses.PlayerStaffAddresses));
			#endregion
		}

		private StaffMemoryAddressesWrapper GetPersonMemoryAddresses(int maxBufferSize)
		{
			object memAddrSyncroot = new object();

			IPersonVersionOffsets personOffsets = GameManager.Version.PersonOffsets;

			var memoryAddresses = new StaffMemoryAddressesWrapper();
			memoryAddresses.PlayerAddresses = new List<Int64>();
			memoryAddresses.PlayerStaffAddresses = new List<Int64>();
			memoryAddresses.HumanManagersAddresses = new List<Int64>();
			memoryAddresses.StaffAddresses = new List<Int64>();

			List<Int64> addresses = GetMemoryAddresses(m=>m.Person, m=>m.Person);

			foreach (var address in addresses)
			{
                ushort type = ProcessManager.ReadUInt16(address);

                if (type == GameManager.Version.PersonEnum.Player)
                {
                    memoryAddresses.PlayerAddresses.Add(address);
                }
                else if (type == GameManager.Version.PersonEnum.Staff)
                {
                    memoryAddresses.StaffAddresses.Add(address);
                } /*else if (type == GameManager.Version.PersonEnum.HumanManager) {
							memoryAddresses.HumanManagersAddresses.Add (memoryAddress);
						}*/
                else if (type == GameManager.Version.PersonEnum.PlayerStaff)
                {
                    memoryAddresses.PlayerStaffAddresses.Add(address);
                }
            }

			return memoryAddresses;

			//List<List<Int64>> memoryAddressBatches = SplitMemoryAddressesIntoBuffer(addresses);
			//List<Int64> unknownAddresses = new List<Int64> ();

			//foreach (var memoryBatch in memoryAddressBatches)
			//{
   //             #if LINUX
			//	byte[] buffer = ProcessManager.ReadProcessMemory(memoryBatch.Min(), Convert.ToInt32(memoryBatch.Max() + 2000 - memoryBatch.Min()));
   //             #endif
   //             #if WINDOWS
   //             byte[] buffer = ProcessManager.ReadProcessMemory(memoryBatch.Min(), Convert.ToUInt32(memoryBatch.Max() + 2000 - memoryBatch.Min()));
   //             #endif
			//	#if MAC
			//	byte[] buffer = ProcessManager.ReadProcessMemory(memoryBatch.Min(), Convert.ToInt32(memoryBatch.Max() + 2000 - memoryBatch.Min()));
			//	#endif
			//	Int64 lowestPointerInBatch = memoryBatch.Min();
			//	foreach (Int64 memoryAddress in memoryBatch)
			//	{
   //                 //first 4 bytes contain the type
   //                 ushort type = ProcessManager.ReadUInt16(buffer, Convert.ToInt32(memoryAddress + 0x0 - lowestPointerInBatch));
			//		lock (memAddrSyncroot)
			//		{
			//			if (type == GameManager.Version.PersonEnum.Player) {
			//				memoryAddresses.PlayerAddresses.Add (memoryAddress);
			//			} else if (type == GameManager.Version.PersonEnum.Staff) {
			//				memoryAddresses.StaffAddresses.Add (memoryAddress);
			//			} /*else if (type == GameManager.Version.PersonEnum.HumanManager) {
			//				memoryAddresses.HumanManagersAddresses.Add (memoryAddress);
			//			}*/ else if (type == GameManager.Version.PersonEnum.PlayerStaff) {
			//				memoryAddresses.PlayerStaffAddresses.Add (memoryAddress);
			//			} else {
			//				// Dump it
			//				if (unknownAddresses.IndexOf (type) < 0 && type > 0x0) {
			//					int personID = ProcessManager.ReadInt32 (buffer, Convert.ToInt32(memoryAddress + 0x8 - lowestPointerInBatch));
			//					Debug.WriteLine ("Found Unknown Person Type: {0:X} @ 0x{1:X} with ID: {2}", type, memoryAddress, personID);
			//					unknownAddresses.Add (type);
			//				}
			//			}
			//		}
			//	}
			//}

			//return memoryAddresses;
		}

		/// <summary>
		/// Splits a given set of memory-addresses into chunks, that can be used for buffered reading
		/// </summary>
		/// <param name="memoryAddressesList">The original set of memoryAddresses</param>
		/// <returns>A list with lists of memoryaddresses</returns>
		public static List<List<Int64>> SplitMemoryAddressesIntoBuffer(List<Int64> memoryAddressesList)
		{
			var maxBytes = ProcessManager.FMProcess.EndPoint;
			const int bitshift = 18;

            Int64[,] chunks = new Int64[maxBytes >> bitshift, 10000L];
            Int64[] counter = new Int64[maxBytes >> bitshift];

			foreach (var m in memoryAddressesList)
			{
				if (m > maxBytes || m < 0x02) continue;

				var c = m >> bitshift;
				chunks[c, counter[c]] = m;
				counter[c]++;
			}

			List<List<Int64>> r = new List<List<Int64>>();
			for (Int64 c = 0; c < (maxBytes >> bitshift); c++)
			{
				if (counter[c] > 0)
				{
					List<Int64> list = new List<Int64>();
					for (int i = 0; i < counter[c]; i++)
					{
						list.Add(chunks[c, i]);
					}
					r.Add(list.OrderBy(d=>d).ToList());
				}
			}

			chunks = null;
			counter = null;

			return r;
		}

		private Dictionary<Int64, T> RetrieveObjects<T>(Expression<Func<IVersionMemoryAddresses, Int64>> baseObjectAddress, Func<IVersionMemoryAddresses, Int64> compiledObjectPointer)
			where T : BaseObject
		{
			return RetrieveObjects<T> (baseObjectAddress, compiledObjectPointer, null);
		}

		private Dictionary<Int64, T> RetrieveObjects<T>(List<Int64> memoryAddresses)
			where T : BaseObject
		{
			return RetrieveObjects<T> (m => m.CurrentDateTime, m => m.CurrentDateTime, memoryAddresses);
		}

		private Dictionary<Int64, T> RetrieveObjects<T>(Expression<Func<IVersionMemoryAddresses, Int64>> baseObjectPointer, Func<IVersionMemoryAddresses, Int64> compiledObjectPointer, List<Int64> memoryAddresses) where T: BaseObject
		{
			/*
			if (DatabaseMode == DatabaseModeEnum.Cached)
				return RetrieveObjectsCached */
			return RetrieveObjectRealtime<T> (baseObjectPointer, compiledObjectPointer, memoryAddresses);
		}

		private Dictionary<Int64, T> RetrieveObjectRealtime<T>(Expression<Func<IVersionMemoryAddresses, Int64>> baseObjectPointer, Func<IVersionMemoryAddresses, Int64> compiledObjectPointer, List<Int64> memoryAddresses) where T : BaseObject
		{
			if (memoryAddresses == null) {
				memoryAddresses = GetMemoryAddresses (baseObjectPointer, compiledObjectPointer);
			}

			#region CreateConstructorDelegate
			ConstructorInfo constructor = typeof(T).GetConstructor(new[] { typeof(Int64), typeof(IVersion) });
			ParameterExpression expPointer = Expression.Parameter(typeof(Int64), "memoryAddress");
			ParameterExpression vPointer = Expression.Parameter(typeof(IVersion), "version");
			Expression createNew = Expression.New(constructor, expPointer, vPointer);
			LambdaExpression lambda = Expression.Lambda(createNew, new[] { expPointer, vPointer });
			Func<Int64, IVersion, T> constructInvoker = (Func<Int64, IVersion, T>)lambda.Compile();
			#endregion

			var outputList = new Dictionary<Int64, T> (memoryAddresses.Count);
			foreach (Int64 address in memoryAddresses) {
				var obj = constructInvoker.Invoke (address, GameManager.Version);
				try {
					outputList.Add (address, obj);
				} catch {
				}
			}

			return outputList;
		}

		private static readonly Dictionary<string, MemoryAddressAttribute> MemoryAttributeCache = new Dictionary<string, MemoryAddressAttribute>();
		private List<Int64> GetMemoryAddresses(Expression<Func<IVersionMemoryAddresses, Int64>> baseObjectPointer, Func<IVersionMemoryAddresses, Int64> compiledObjectPointer)
		{
			string key = baseObjectPointer.ToString ();
			if (!MemoryAttributeCache.ContainsKey (key)) {
				MemoryAttributeCache.Add (key, (MemoryAddressAttribute)GameManager.Version.MemoryAddresses.GetType ().GetProperty (
					((MemberExpression)baseObjectPointer.Body).Member.Name).GetCustomAttributes (
						typeof(MemoryAddressAttribute), false).First ());
			}
			MemoryAddressAttribute memoryAttribute = MemoryAttributeCache [key];

            // Let's get the memory addresses now
#if LINUX
			int memoryAddress = ProcessManager.ReadInt32 (GameManager.Version.MemoryAddresses.MainAddress + GameManager.Version.MemoryAddresses.MainOffset);
#endif

#if MAC
			int memoryAddress = ProcessManager.ReadInt32 (GameManager.Version.MemoryAddresses.MainAddress + GameManager.Version.MemoryAddresses.MainOffset);
#endif

            // On windows, we have ASLR, so get the main pointer from the static offset
#if WINDOWS
            Int64 memoryAddress = (ProcessManager.fmProcess.BaseAddress + GameManager.Version.MemoryAddresses.MainAddress);
            //memoryAddress = ProcessManager.ReadInt32(memoryAddress);
            #endif

            if (GameManager.Version.MainVersionNumber == "14")
            {
				memoryAddress = ProcessManager.ReadInt32(memoryAddress);
                int xorValueOne = ProcessManager.ReadInt32(memoryAddress + memoryAttribute.BytesToSkip + 0x4);
                int xorValueTwo = ProcessManager.ReadInt32(memoryAddress + memoryAttribute.BytesToSkip);
                memoryAddress = xorValueTwo ^ xorValueOne;
            }
            else
            {
                memoryAddress = ProcessManager.ReadInt64(memoryAddress + memoryAttribute.BytesToSkip);
            }
			memoryAddress = ProcessManager.ReadInt64 (memoryAddress + GameManager.Version.MemoryAddresses.XorDistance);
			long numberOfObjects = ProcessManager.ReadArrayLength (memoryAddress);

			List<Int64> memoryAddresses = GetMemoryAddresses (ProcessManager.ReadInt64 (memoryAddress), numberOfObjects);
			return memoryAddresses;
		}

		public static List<Int64> GetMemoryAddresses(Int64 firstAddress, Int64 numberOfObjects)
		{
            #if WINDOWS
            byte[] pointerCache = ProcessManager.ReadProcessMemory(firstAddress, (uint)(numberOfObjects * 8));
            #endif

			#if LINUX || MAC
			byte[] pointerCache = ProcessManager.ReadProcessMemory (firstAddress, numberOfObjects * 4);
            #endif
			// TODO: downcast from long to int which should be fine since numberOfObjects probably could just be an int anyway?
			List<Int64> memoryAddresses = new List<Int64> ((int)numberOfObjects);

			for (int i = 0; i < pointerCache.Length; i += 8) {
				Int64 toAdd = ProcessManager.ReadInt64 (pointerCache, i);
				if (toAdd != 0)
					memoryAddresses.Add (toAdd);
			}
			return memoryAddresses;
		}

		private static readonly Dictionary<Type, MethodInfo> MethodInfos = new Dictionary<Type, MethodInfo>();
		private static readonly object MethodInfoLock = new object();
		public static MethodInfo GetMethodInfo(Type type)
		{
			Func<string, string> firstUp = s => s.Substring (0, 1).ToUpper () + s.Substring (1).ToLower ();

			bool exists;
			MethodInfo methodInfo = null;

			lock (MethodInfoLock) {
				exists = MethodInfos.ContainsKey (type);
				if (exists)
					methodInfo = MethodInfos [type];
			}

			if (!exists) {
				Type[] readTypes = new[] { typeof(byte[]), typeof(Int64) };
				if (type == typeof(string)) {
					methodInfo = typeof(ProcessManager).GetMethod ("ReadString", new[] { typeof(byte[]), typeof(Int64), typeof(Int64) });
				} else {
					methodInfo = typeof(ProcessManager).GetMethod ("Read" + firstUp.Invoke (type.Name), readTypes);
				}
				lock (MethodInfoLock) {
					MethodInfos.Add (type, methodInfo);
				}
			}
			return methodInfo;
		}
	}

	public class StaffMemoryAddressesWrapper
	{
		public List<Int64> PlayerAddresses { get; set; }
		public List<Int64> StaffAddresses { get; set; }
		public List<Int64> PlayerStaffAddresses { get; set; }
		public List<Int64> HumanManagersAddresses { get; set; }
	}
}

