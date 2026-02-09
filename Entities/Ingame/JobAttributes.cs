using FMScoutFramework.Core.Entities.GameVersions;
using FMScoutFramework.Core.Entities.InGame.Interfaces;
using FMScoutFramework.Core.Managers;
using FMScoutFramework.Core.Offsets;
using FMScoutFramework.Defines.Offsets.PersonTypes.Sub_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMScoutFramework.Core.Entities.InGame
{
    public class JobAttributes : BaseObject, IJobAttributes
    {
        public JobAttributes(Int64 memoryAddress, IVersion version)
            : base(memoryAddress, version)
        { }
        public JobAttributes(Int64 memoryAddress, ArraySegment<byte> originalBytes, IVersion version)
            : base(memoryAddress, originalBytes, version)
        { }

        public byte Attacking
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Attacking, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Defending
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Defending, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Fitness
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Fitness, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte SetPieces
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.SetPieces, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Possession
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Possession, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Tactical
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Tactical, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Technical
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Technical, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte WorkingWithYoungsters
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.WorkingWithYoungsters, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte GKDistribution
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.GKDistribution, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte GKHandling
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.GKHandling, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte GKShotStopping
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.GKShotStopping, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Determination
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Determination, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Authority
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Authority, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte PeopleManagement
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.PeopleManagement, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Motivating
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Motivating, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte JudgingPlayerAbility
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.JudgingPlayerAbility, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte JudgingPlayerPotential
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.JudgingPlayerPotential, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte JudgingStaffAbility
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.JudgingStaffAbility, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Negotiating
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Negotiating, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte TacticalKnowledge
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.TacticalKnowledge, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Physiotherapy
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Physiotherapy, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte SportsScience
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.SportsScience, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte AnalysingData
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.AnalysingData, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Business
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Business, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Interference
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Interference, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Resources
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Resources, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Patience
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Patience, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte AttackingStyle
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.AttackingStyle, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Depth
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Depth, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte DefensiveLine
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.DefensiveLine, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Directness
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Directness, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Dirtiness
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Dirtiness, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Eccentricity
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Eccentricity, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Fluidity
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Fluidity, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Flexibility
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Flexibility, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte FreeRoles
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.FreeRoles, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Marking
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Marking, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Offside
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Offside, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte PressingIntensity
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.PressingIntensity, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte SittingBack
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.SittingBack, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Technique
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Technique, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Tempo
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Tempo, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte UseOfPlaymaker
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.UseOfPlaymaker, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte UseOfSubstitutions
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.UseOfSubstitutions, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Width
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Width, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte BuyingPlayers
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.BuyingPlayers, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte TrainingHardness
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.TrainingHardness, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte MindGames
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.MindGames, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte SquadRotation
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.SquadRotation, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }
        public byte Versatility
        {
            get
            {
                return PropertyInvoker.Get<byte>(JobAttributesOffsets.Versatility, OriginalBytes, MemoryAddress, DatabaseMode);
            }
        }

    }
}
