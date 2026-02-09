using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMScoutFramework.Core.Entities.InGame.Interfaces
{
    internal interface IJobAttributes
    {
        // coaching
        byte Attacking { get; }
        byte Defending { get; }
        byte Fitness { get; }
        byte SetPieces { get; }
        byte Possession { get; }
        byte Tactical { get; }
        byte Technical { get; }
        byte WorkingWithYoungsters { get; }
        // gk coaching
        byte GKDistribution { get; }
        byte GKHandling { get; }
        byte GKShotStopping { get; }
        // mental
        byte Determination { get; }
        byte Authority { get; }
        byte PeopleManagement { get; }
        byte Motivating { get; }
        // knowledge
        byte JudgingPlayerAbility { get; }
        byte JudgingPlayerPotential { get; }
        byte JudgingStaffAbility { get; }
        byte Negotiating { get; }
        byte TacticalKnowledge { get; }
        // medical
        byte Physiotherapy { get; }
        byte SportsScience { get; }
        // analyst
        byte AnalysingData { get; }
        // chairman
        byte Business { get; }
        byte Interference { get; }
        byte Resources { get; }
        byte Patience { get; }
        // tactical
        byte AttackingStyle { get; }
        byte Depth { get; }
        byte DefensiveLine { get; }
        byte Directness { get; }
        byte Dirtiness { get; }
        byte Eccentricity { get; }
        byte Fluidity { get; }
        byte Flexibility { get; }
        byte FreeRoles { get; }
        byte Marking { get; }
        byte Offside { get; }
        byte PressingIntensity { get; }
        byte SittingBack { get; }
        byte Technique { get; }
        byte Tempo { get; }
        byte UseOfPlaymaker { get; }
        byte UseOfSubstitutions { get; }
        byte Width { get; }
        // non-tactical
        byte BuyingPlayers { get; }
        byte TrainingHardness { get; }
        byte MindGames { get; }
        byte SquadRotation { get; }
        byte Versatility { get; }
    }
}
