using System;

namespace FMScoutFramework.Core.Entities.InGame.Interfaces
{
    public interface IPlayer
    {
        int AskingPrice { get; }
        //long BansAddress { get; }
        byte BodyType { get; }
        ushort CA { get; }
        short Condition { get; }
        short CurrentReputation { get; }
        short Fitness { get; }
        double GrowthPotential { get; }
        ushort Height { get; }
        short HomeReputation { get; }
        //Injury[] Injuries { get; }
        //long InjuriesAddress { get; }
        //bool isBanned { get; }
        //bool isInjured { get; }
        short Jadedness { get; }
        byte Morale { get; }
        ushort PA { get; }
        PlayerStats PlayerStats { get; }
        // TODO: create and use enum
        byte PreferredCentralPosition { get; }
        // TODO: create and use enum
        byte RoleUsedToFillEmptyAttributes { get; }
        //Team Team { get; }
        int Value { get; }
        short WorldReputation { get; }
        //Contract LoanContract { get; } // TODO: should be its own type
        //Contract BClubContract { get; }
        //Contract NationContract { get; }
    }
}