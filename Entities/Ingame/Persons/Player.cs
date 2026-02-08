using System;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Attributes;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Entities.InGame.Interfaces;
using FMScoutFramework.Core.Utilities;

namespace FMScoutFramework.Core.Entities.InGame
{
	public class Player : Person, IPlayer
    {
        private readonly PlayerOffsets PlayerOffsets;
		public Player (long memoryAddress, IVersion version) 
			: base(memoryAddress, version)
		{
            this.PlayerOffsets = new PlayerOffsets(version);
        }
		public Player (long memoryAddress, ArraySegment<byte> originalBytes, IVersion version) 
			: base(memoryAddress, originalBytes, version)
		{
            this.PlayerOffsets = new PlayerOffsets(version);
        }

		private long PlayerAddress {
			get {
				return (MemoryAddress + Version.PersonOffsets.Player);
			}
		}

		public PlayerStats PlayerStats {
			get {
                long startAddress = PlayerAddress + PlayerOffsets.PlayerStats;
				return new PlayerStats (startAddress, Version);
			}
		}

		//public long InjuriesAddress {
		//	get {
		//		return PropertyInvoker.Get<Int64> (PlayerOffsets.Injuries, OriginalBytes, PlayerAddress, DatabaseMode);
		//	}
		//}

		//public Injury[] Injuries {
		//	get {
		//		long numberOfInjuries = ProcessManager.ReadArrayLength (InjuriesAddress);
		//		Injury[] retVal = new Injury[numberOfInjuries];
		//		for (int i = 0; i < numberOfInjuries; i++) {
		//                  Int64 injuryAddress = PropertyInvoker.Get<Int64> ((i * 4), OriginalBytes, InjuriesAddress, DatabaseMode);
		//			injuryAddress = PropertyInvoker.Get<Int64> (0x0, OriginalBytes, injuryAddress, DatabaseMode);
		//			retVal [i] = PropertyInvoker.GetPointer<Injury> (0x8, OriginalBytes, injuryAddress, DatabaseMode, Version);
		//		}

		//		return retVal;
		//	}
		//}

		//public bool isInjured {
		//	get {
		//		return (Injuries.Length > 0);
		//	}
		//}

		//      public void Heal()
		//      {
		//          ProcessManager.ResizeArray(InjuriesAddress, 0);
		//      }

		//public long BansAddress {
		//	get {
		//		return PropertyInvoker.Get<Int64> (PlayerOffsets.BansOffset, OriginalBytes, InjuriesAddress, DatabaseMode);
		//	}
		//}

		//public bool isBanned {
		//	get {
		//		return ProcessManager.ReadArrayLength (BansAddress) > 0;
		//	}
		//}

		//public Team Team {
		//	get {
		//		return PropertyInvoker.GetPointer<Team> (PlayerOffsets.Team, OriginalBytes, PlayerAddress, DatabaseMode, Version);
		//	}
		//}

		public int Value
		{
			get
			{
				return PropertyInvoker.Get<Int32>(PlayerOffsets.Value, OriginalBytes, PlayerAddress, DatabaseMode);
			}
		}

		public int AskingPrice
		{
			get
			{
				return PropertyInvoker.Get<Int32>(PlayerOffsets.AskingPrice, OriginalBytes, PlayerAddress, DatabaseMode);
			}
		}

		public short Fitness {
			get {
				return PropertyInvoker.Get<short> (PlayerOffsets.Fitness, OriginalBytes, PlayerAddress, DatabaseMode);
			}
		}

		public short Jadedness {
			get {
				return PropertyInvoker.Get<short> (PlayerOffsets.Jadedness, OriginalBytes, PlayerAddress, DatabaseMode);
			}
		}

		public short Condition {
			get {
				return PropertyInvoker.Get<short> (PlayerOffsets.Condition, OriginalBytes, PlayerAddress, DatabaseMode);
			}
		}

		public short HomeReputation {
			get {
				return PropertyInvoker.Get<short> (PlayerOffsets.HomeReputation, OriginalBytes, PlayerAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<short>(PlayerOffsets.HomeReputation, OriginalBytes, PlayerAddress, DatabaseMode, value);
            }
		}

		public short CurrentReputation {
			get {
				return PropertyInvoker.Get<short> (PlayerOffsets.CurrentReputation, OriginalBytes, PlayerAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<short>(PlayerOffsets.CurrentReputation, OriginalBytes, PlayerAddress, DatabaseMode, value);
            }
        }

		public short WorldReputation {
			get {
				return PropertyInvoker.Get<short> (PlayerOffsets.WorldReputation, OriginalBytes, PlayerAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<short>(PlayerOffsets.WorldReputation, OriginalBytes, PlayerAddress, DatabaseMode, value);
            }
        }

		public ushort CA {
			get {
				return PropertyInvoker.Get<ushort> (PlayerOffsets.CA, OriginalBytes, PlayerAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<ushort>(PlayerOffsets.CA, OriginalBytes, PlayerAddress, DatabaseMode, value);
            }
		}

		public ushort PA {
            get
            {
                return PropertyInvoker.Get<ushort>(PlayerOffsets.PA, OriginalBytes, PlayerAddress, DatabaseMode);
            }
            set
            {
                PropertyInvoker.Set<ushort>(PlayerOffsets.PA, OriginalBytes, PlayerAddress, DatabaseMode, value);
            }
        }

		// TODO: turn into enum
		public byte BodyType {
			get {
				return PropertyInvoker.Get<byte> (PlayerOffsets.BodyType, OriginalBytes, PlayerAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<byte>(PlayerOffsets.BodyType, OriginalBytes, PlayerAddress, DatabaseMode, value);
            }
        }

		public ushort Height {
			get {
				return PropertyInvoker.Get<ushort> (PlayerOffsets.Height, OriginalBytes, PlayerAddress, DatabaseMode);
			}
            set
            {
                PropertyInvoker.Set<ushort>(PlayerOffsets.Height, OriginalBytes, PlayerAddress, DatabaseMode, value);
            }
		}

		public byte Morale
		{
            get
            {
                return PropertyInvoker.Get<byte>(PlayerOffsets.Morale, OriginalBytes, PlayerAddress, DatabaseMode);
            }
            set
            {
                PropertyInvoker.Set<byte>(PlayerOffsets.Morale, OriginalBytes, PlayerAddress, DatabaseMode, value);
            }
        }

        public byte PreferredCentralPosition
        {
            get
            {
                return PropertyInvoker.Get<byte>(PlayerOffsets.PreferredCentralPosition, OriginalBytes, PlayerAddress, DatabaseMode);
            }
            set
            {
                PropertyInvoker.Set<byte>(PlayerOffsets.PreferredCentralPosition, OriginalBytes, PlayerAddress, DatabaseMode, value);
            }
        }

        public byte RoleUsedToFillEmptyAttributes
        {
            get
            {
                return PropertyInvoker.Get<byte>(PlayerOffsets.RoleUsedToFillEmptyAttributes, OriginalBytes, PlayerAddress, DatabaseMode);
            }
            set
            {
                PropertyInvoker.Set<byte>(PlayerOffsets.RoleUsedToFillEmptyAttributes, OriginalBytes, PlayerAddress, DatabaseMode, value);
            }
        }

        public double GrowthPotential {
			get {
				if (PlayerStats != null && Attributes != null) {
					double DAP = (((PlayerStats.Determination / 5) * 0.05) + (Attributes.Ambition * 0.09) + (Attributes.Professionalism * 0.115));
					if (Age < 24) {
						if (PA <= (CA + 10)) {
							DAP -= 0.5;
						}
					} else if (Age >= 24 && Age < 29) {
						DAP -= 0.5;
						if (PA <= (CA + 10)) {
							DAP -= 0.5;
						}
					} else if (Age >= 29 && Age < 34) {
						DAP -= 1.0;
						if (PA <= (CA + 10)) {
							DAP -= 0.5;
						}
					} else if (Age >= 34) {
						if (PA <= (CA + 10) && PlayerStats.Goalkeeper >= 15) {
							DAP = 0.5;
						} else {
							DAP = 0.0;
						}
					}

					DAP *= 2.0;
					DAP = Math.Round (DAP, MidpointRounding.AwayFromZero);
					DAP /= 2.0;

					return DAP;
				}

				return 0.0;
			}
		}

		public override string ToString () {
			return Firstname + " " + Lastname;
		}
	}
}

