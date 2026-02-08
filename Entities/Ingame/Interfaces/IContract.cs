using System;

namespace FMScoutFramework.Core.Entities.InGame.Interfaces
{
    public interface IContract
    {
        //ContractBonus[] ContractBonuses { get; }
        //ContractClause[] ContractClauses { get; }
        ContractType ContractType { get; }
        DateTime DateExpires { get; }
        DateTime DateStarted { get; }
        bool IsTransferListed { get; }
        bool IsListedByRequest { get; }
        bool IsNotForSale { get; }
        bool IsSetForRelease { get; }
        bool IsLoanListed { get; }
        bool IsUnavailableForLoan { get; }
        JobType JobType { get; }
        sbyte SquadNumber { get; }
        sbyte PreferredSquadNumber { get; }
        SquadStatus PlayingTime { get; }
        SquadStatus PreviousPlayingTime { get; }
        SquadStatus FuturePlayingTime { get; }
        short FuturePlayingTimeYear { get; }
        sbyte PlayingTimeHappiness { get; }
        sbyte Happiness { get; }
        //Team Team { get; } // TODO: Club or Team?
        int Wage { get; }
        int LoyaltyBonus { get; }
        int AgentFees { get; }
        DateTime DateSigned { get; }

    }
}