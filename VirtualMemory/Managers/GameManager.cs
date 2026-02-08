using FMScoutFramework.Core.Converters;
using FMScoutFramework.Core.Entities.GameVersions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FMScoutFramework.Core.Managers
{
	public class GameManager
	{
		private bool fmLoaded;
		private bool fmLoading;

		public GameManager ()
		{
			this.fmLoaded = false;
			this.fmLoading = false;
		}

		public bool FMLoaded {
			get { return fmLoaded; }
		}

		public bool FMLoading {
			get { return fmLoading; }
			set { fmLoading = value; }
		}

		public IVersion Version {
			get;
			private set;
		}

		private Int64 getGamePluginDllBaseAddress(FMProcess fmProcess)
		{
            var modules = fmProcess.Process.Modules;
            ProcessModule gamePluginModule = null;
            foreach (ProcessModule module in modules)
            {
                if (module.ModuleName == "game_plugin.dll")
                {
                    gamePluginModule = module;
                    break;
                }
            }

            if (gamePluginModule == null)
            {
                throw new Exception("game plugin dll not found");
            }

			return (Int64)gamePluginModule.BaseAddress;

        }

		private IntPtr getTablesAddress()
		{
			var modules = ProcessManager.fmProcess.Process.Modules;
            ProcessModule gamePluginModule = null;
            foreach (ProcessModule module in modules)
            {
                if (module.ModuleName == "game_plugin.dll")
				{
					gamePluginModule = module;
					break;
				}
            }

			if (gamePluginModule == null)
			{
				throw new Exception("game plugin dll not found");
			}

			return gamePluginModule.BaseAddress + 0x4DE1848;
        }

        private Int64 ReadArrayLength(Int64 baseOffset)
        {
            // leads to the address where the main pointer to the list definition is (+ magic offset)
            Int64 memoryAddress = ProcessManager.ReadInt64((long)getTablesAddress() + baseOffset);
            // this is the pointer to the list definition
            memoryAddress = ProcessManager.ReadInt64(memoryAddress + 0x80);
            Int64 numberOfObjects = ProcessManager.ReadArrayLength(memoryAddress);

            return numberOfObjects;
        }

		private void CountPersonTypes()
		{
            Dictionary<string, List<Int64>> personTypes = new Dictionary<string, List<Int64>>();

            // leads to the address where the main pointer to the list definition is (+ magic offset)
            Int64 memoryAddress = ProcessManager.ReadInt64((long)getTablesAddress() + 0x68);
            // this is the pointer to the list definition
            memoryAddress = ProcessManager.ReadInt64(memoryAddress + 0x80);

            long numberOfObjects = ProcessManager.ReadArrayLength(memoryAddress);

            List<Int64> memoryAddresses = ObjectManager.GetMemoryAddresses(ProcessManager.ReadInt64(memoryAddress), numberOfObjects);

			foreach (Int64 address in memoryAddresses)
			{
				string personType = ProcessManager.ReadInt64(address).ToString("X");
				personTypes.TryGetValue(personType, out List<Int64> addressList);
				if (addressList != null)
				{
                    addressList.Add(address);
                }
                else
				{
                    addressList = new List<Int64>();
                }
                personTypes[personType] = addressList;
			}

			Debug.WriteLine(personTypes.ToString());
        }

#if LINUX
		// Finds the process and loads it in memory
		public bool findFMProcess ()
		{
			FMProcess fmProcess = new FMProcess ();
			Process[] fmProcesses = Process.GetProcessesByName ("fm");
			uint pid = fmProcesses.Length > 1 ? (uint)fmProcesses[0].Id : (uint)fmProcesses[0].Id;

			if (fmProcesses.Length > 0) {
				uint buffer;
				uint bufferend;
				uint heap;
				uint endaddress;
				if (ProcessMemoryAPI.GetBaseAddress (pid, out buffer, out bufferend, out heap, out endaddress)) {
					fmProcess.Process = fmProcesses [0];
					fmProcess.BaseAddress = (int)buffer;
					fmProcess.HeapAddress = (int)heap;
					fmProcess.EndPoint = (int)endaddress;
					ProcessManager.fmProcess = fmProcess;

					// Search for the current version
					foreach (var versionType in Assembly.GetCallingAssembly().GetTypes().Where(t => typeof(IIVersion).IsAssignableFrom(t))) {
						if (versionType.IsInterface)
							continue;
						var instance = (IIVersion)Activator.CreateInstance (versionType);

						if (instance.SupportsProcess (fmProcess, null)) {
							Version = instance;
							break;
						}
					}
				}
				fmLoaded = (Version != null);
			}

			if (!fmLoaded) {
				// Try to find info about the version
				// Lookup the objects in the memory
				for (int i = fmProcess.BaseAddress; i < fmProcess.EndPoint - 4; i += 4) {
					try {
						int continents = TryGetPointerObjects(i, 0x1c, fmProcess);
						if (continents == 7)
						{
							Debug.WriteLine ("Found a candidate @ 0x{0:X}", i);
							Debug.WriteLine ("Persons: {0}", TryGetPointerObjects(i, 0x3c, fmProcess));
						}
					}
					catch {
					}
				}
			}

			return fmLoaded;
		}
#endif
#if MAC
		public bool findFMProcess() {
			FMProcess fmProcess = new FMProcess ();
			Process[] fmProcesses = Process.GetProcessesByName ("fm");
			if (fmProcesses.Length > 0) {

				Process activeProcess = fmProcesses [0];
				fmProcess.Process = activeProcess;
				fmProcess.BaseAddress = activeProcess.MainModule.BaseAddress.ToInt32 ();
				fmProcess.EndPoint = ProcessManager.GetProcessEndPoint (activeProcess.Id);

				ProcessManager.fmProcess = fmProcess;

				// Search for the current version
				foreach (var versionType in Assembly.GetCallingAssembly().GetTypes().Where(t => typeof(IIVersion).IsAssignableFrom(t))) {
					if (versionType.IsInterface)
						continue;
					var instance = (IIVersion)Activator.CreateInstance (versionType);

					if (instance.SupportsProcess (fmProcess, null)) {
						Version = instance;
						break;
					}
				}

				fmLoaded = (Version != null);

                #region ObjectScanner
				if (!fmLoaded)
				{
					int i;
					// Try to find info about the version
					// Lookup the objects in the memory
					for (i = 0x32A0000; i < fmProcess.EndPoint; i += 4)
					{
						int cities = TryGetPointerObjects(i, 0x14, fmProcess);
						int clubs = TryGetPointerObjects(i, 0x1C, fmProcess);
						int leagues = TryGetPointerObjects(i, 0x24, fmProcess);
						int stadiums = TryGetPointerObjects(i, 0x8C, fmProcess);
						int teams = TryGetPointerObjects(i, 0xA4, fmProcess);
						int continents = TryGetPointerObjects(i, 0x2C, fmProcess);
						int countries = TryGetPointerObjects(i, 0x64, fmProcess);
						int persons = TryGetPointerObjects(i, 0x6C, fmProcess);

						if (continents == 7 && countries == 240 && (
							cities > 0 && clubs > 0 && leagues > 0 && stadiums > 0 &&
							teams > 0 && persons > 0
						))
						{
							Debug.WriteLine("Found a candidate @ 0x{0:X}", i);
						}
					}
				}
                #endregion
			}

			return fmLoaded;
		}
#endif
#if WINDOWS
        public bool findFMProcess() {
			FMProcess fmProcess = new FMProcess ();
			Process[] fmProcesses = Process.GetProcessesByName ("fm");

			if (fmProcesses.Length > 0) {
				Process activeProcess = fmProcesses[0];

				fmProcess.Pointer = ProcessMemoryAPI.OpenProcess(0x001F0FFF, 1, (uint)activeProcess.Id);
				fmProcess.EndPoint = 0x7FFFFFFFFFFF; // TODO: use the function, but good enough for now. original: ProcessManager.GetProcessEndPoint (fmProcess.Pointer);
				fmProcess.Process = activeProcess;
                fmProcess.BaseAddress = getGamePluginDllBaseAddress(fmProcess);

				ProcessManager.fmProcess = fmProcess;
				//                byte[] testResult = ProcessManager.ReadProcessMemory(0x7FF993681848, 8);
				//				int[] offsets = {
				//0x08,
				//0x10,
				//0x18,
				//0x20,
				//0x28,
				//0x30,
				//0x38,
				//0x40,
				//0x48,
				//0x50,
				//0x58,
				//0x60,
				//0x68,
				//0x70,
				//0x78,
				//0x80,
				//0x88,
				//0x90,
				//0x98,
				//0xA0,
				//0xA8,
				//0xB0,
				//0xB8,
				//0x4B0,
				//0x4B8,
				//0x4C0,
				//0x4C8,
				//0x4D0,
				//0x4D8,
				//0x4E0,
				//0x4E8,
				//0x4F0,
				//0x4F8,
				//0x500,
				//0x508,
				//0x510,
				//0x518,
				//0x520,
				//0x528,
				//0x530,
				//0x538,
				//0x540,
				//0x548,
				//0x550,
				//0x558,
				//0x560,
				//0x568,
				//0x570,
				//0x578,
				//0x580,
				//0x588,
				//0x590,
				//0x598,
				//0x5A0,
				//0x5A8,
				//0x5B0,
				//0x5B8,
				//0x5C0,
				//0x5C8,
				//0x5D0,
				//0x5D8,
				//0x5E0,
				//0x6A8,
				//0x6B0
				//                };

				CountPersonTypes();

				//                foreach (int offset in offsets)
				//				{
				//					long arrayLength = ReadArrayLength(offset);
				//					Debug.WriteLine("Length of array at offset {0} is {1}", offset.ToString("X"), arrayLength.ToString());
				//                }

				fmProcess.VersionDescription = fmProcess.Process.MainModule.FileVersionInfo.ProductVersion;
				Debug.WriteLine("Version description is {0}", fmProcess.VersionDescription, "");

				// Search for the current version
				foreach (var versionType in Assembly.GetCallingAssembly().GetTypes().Where(t => typeof(IIVersion).IsAssignableFrom(t))) {
					if (versionType.IsInterface)
						continue;
					var instance = (IIVersion)Activator.CreateInstance (versionType);

					if (instance.SupportsProcess (fmProcess, null)) {
						Version = instance;
						break;
					}
				}

				fmLoaded = (Version != null);

                if (!fmLoaded)
                {
                    Int64 i;
					// Try to find info about the version
					// Lookup the objects in the memory
					// TODO: check if this address is still correct. Probably not?
					Debug.WriteLine("Game not loaded. Analysing...");
                    for (i = (fmProcess.BaseAddress + 0x1A8484E); i < fmProcess.EndPoint; i += 4)
                    {
                        Int64 cities, clubs, leagues, stadiums, teams, continents, countries, persons;
                        string[] splitVersion = fmProcess.VersionDescription.Split('.');
                        if (splitVersion[0] == "14") {
                            cities = TryGetPointerObjects(i, 0x14, fmProcess);
                            clubs = TryGetPointerObjects(i, 0x1C, fmProcess);
                            leagues = TryGetPointerObjects(i, 0x24, fmProcess);
                            stadiums = TryGetPointerObjects(i, 0x8C, fmProcess);
                            teams = TryGetPointerObjects(i, 0xA4, fmProcess);
                            continents = TryGetPointerObjects(i, 0x2C, fmProcess);
                            countries = TryGetPointerObjects(i, 0x64, fmProcess);
                            persons = TryGetPointerObjects(i, 0x6C, fmProcess);
                        }
                        else
                        {
                            cities = TryGetPointerObjects(i, 0x10, fmProcess);
                            clubs = TryGetPointerObjects(i, 0x14, fmProcess);
                            leagues = TryGetPointerObjects(i, 0x18, fmProcess);
                            stadiums = TryGetPointerObjects(i, 0x4C, fmProcess);
                            teams = TryGetPointerObjects(i, 0x58, fmProcess);
                            continents = TryGetPointerObjects(i, 0x1C, fmProcess);
                            countries = TryGetPointerObjects(i, 0x38, fmProcess);
                            persons = TryGetPointerObjects(i, 0x3C, fmProcess);
                        }


                        if (continents == 7 && countries > 230 && countries < 250 && (
                            cities > 0 && clubs > 0 && leagues > 0 && stadiums > 0 &&
                            teams > 0 && persons > 0
                            ))
                        {
                            Debug.WriteLine("Found a candidate @ 0x{0:X}", i);
                        }
                    }
                    Debug.WriteLine("Analysis done.");
                }
			}
			return fmLoaded;
		}
		#endif

		public static Int64 TryGetPointerObjects(Int64 address, Int64 offset, FMProcess fmProcess) {
			return GameManager.TryGetPointerObjects (address, offset, fmProcess, "15");
		}

		public static Int64 TryGetPointerObjects(Int64 address, Int64 offset, FMProcess fmProcess, string masterVersion)
        {
#if WINDOWS
            Int64 memoryAddress = ProcessManager.ReadInt64(address);
            Debug.WriteLine("Base 0x{0:X} -> 0x{1:X}", address, memoryAddress);
            if (memoryAddress > fmProcess.BaseAddress && memoryAddress < fmProcess.EndPoint)
            {
                memoryAddress = ProcessManager.ReadInt64(memoryAddress);
                if (memoryAddress < fmProcess.BaseAddress || memoryAddress > fmProcess.EndPoint)
                    return 0;

                string[] splitVersion = fmProcess.VersionDescription.Split('.');
                if (splitVersion[0] == "14")
                {
                    int xorValueOne = ProcessManager.ReadInt32(memoryAddress + offset + 0x4);
                    int xorValueTwo = ProcessManager.ReadInt32(memoryAddress + offset);
                    memoryAddress = xorValueTwo ^ xorValueOne;
                    if (memoryAddress < fmProcess.BaseAddress || memoryAddress > fmProcess.EndPoint)
                        return 0;
                    memoryAddress = ProcessManager.ReadInt32(memoryAddress + 0x54);
                }
                else
                {
                    memoryAddress = ProcessManager.ReadInt64(memoryAddress + offset);
                    if (memoryAddress < fmProcess.BaseAddress || memoryAddress > fmProcess.EndPoint)
                        return 0;
                    memoryAddress = ProcessManager.ReadInt64(memoryAddress + 0x40);
                }
                
                if (memoryAddress < fmProcess.BaseAddress || memoryAddress > fmProcess.EndPoint)
                    return 0;

                long numberOfObjects = ProcessManager.ReadArrayLength(memoryAddress);
                return numberOfObjects;
            }
			#endif
			#if MAC
			int memoryAddress = ProcessManager.ReadInt32 (address);
			if (masterVersion == "14") {
				memoryAddress = ProcessManager.ReadInt32 (address + 0x1C);
			}

			if (memoryAddress > fmProcess.BaseAddress && memoryAddress < fmProcess.EndPoint)
			{
				if (masterVersion == "14") {
					memoryAddress = ProcessManager.ReadInt32(memoryAddress);
					if (memoryAddress < fmProcess.BaseAddress || memoryAddress > fmProcess.EndPoint)
						return 0;
					int xorValueOne = ProcessManager.ReadInt32(memoryAddress + offset + 0x4);
					int xorValueTwo = ProcessManager.ReadInt32(memoryAddress + offset);
					memoryAddress = xorValueTwo ^ xorValueOne;
					if (memoryAddress < fmProcess.BaseAddress || memoryAddress > fmProcess.EndPoint)
						return 0;
					memoryAddress = ProcessManager.ReadInt32(memoryAddress + 0x54);
					if (memoryAddress < fmProcess.BaseAddress || memoryAddress > fmProcess.EndPoint)
						return 0;
				}
				else {
					memoryAddress = ProcessManager.ReadInt32(memoryAddress + offset);
					memoryAddress = ProcessManager.ReadInt32(memoryAddress + 0x40);
				}

				int numberOfObjects = ProcessManager.ReadArrayLength(memoryAddress);
				return numberOfObjects;
			}
			#endif
			#if LINUX
			int memoryAddress = ProcessManager.ReadInt32 (address);
			memoryAddress = ProcessManager.ReadInt32(memoryAddress + offset);
			memoryAddress = ProcessManager.ReadInt32(memoryAddress + 0x5c);

			int numberOfObjects = ProcessManager.ReadArrayLength(memoryAddress);
			return numberOfObjects;
			#endif
			return 0;
        }
	}
}

