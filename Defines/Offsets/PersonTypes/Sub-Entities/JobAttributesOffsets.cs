using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMScoutFramework.Defines.Offsets.PersonTypes.Sub_Entities
{
    internal class JobAttributesOffsets
    {
        // coaching
        public const short Attacking = 0x22;
        public const short Defending = 0x23;
        public const short Fitness = 0x24;
        public const short SetPieces = 0x33;
        public const short Possession = 0x25;
        public const short Tactical = 0x27;
        public const short Technical = 0x26;
        public const short WorkingWithYoungsters = 0xC;

        // gk coaching
        public const short GKDistribution = 0x2A;
        public const short GKHandling = 0x29;
        public const short GKShotStopping = 0x1B;

        // mental
        public const short Determination = 0xD;
        public const short Authority = 0x4;
        public const short PeopleManagement = 0x1E;
        public const short Motivating = 0x1F;

        // knowledge
        public const short JudgingPlayerAbility = 0x1C;
        public const short JudgingPlayerPotential = 0x1D;
        public const short JudgingStaffAbility = 0x32;
        public const short Negotiating = 0x31;
        public const short TacticalKnowledge = 0x21;

        // medical
        public const short Physiotherapy = 0x20;
        public const short SportsScience = 0x2F;

        // analyst
        public const short AnalysingData = 0x2C;

        // chairman
        public const short Business = 0x1;
        public const short Interference = 0x6;
        public const short Resources = 0xB;
        public const short Patience = 0x9;

        // tactical
        public const short AttackingStyle = 0x0;
        public const short Depth = 0x2;
        public const short DefensiveLine = 0x13;
        public const short Directness = 0x3;
        public const short Dirtiness = 0x28;
        public const short Eccentricity = 0x30;
        public const short Fluidity = 0x14;
        public const short Flexibility = 0x15;
        public const short FreeRoles = 0x5;
        public const short Marking = 0x7;
        public const short Offside = 0x8;
        public const short PressingIntensity = 0xA;
        public const short SittingBack = 0x10;
        public const short Technique = 0x2;
        public const short Tempo = 0x18;
        public const short UseOfPlaymaker = 0x11;
        public const short UseOfSubstitutions = 0x12;
        public const short Width = 0x19;

        // non-tactical
        public const short BuyingPlayers = 0xE;
        public const short TrainingHardness = 0x16;
        public const short MindGames = 0xF;
        public const short SquadRotation = 0x17;
        public const short Versatility = 0x2B;
    }
}
