namespace FMScoutFramework.Core.Entities.InGame.Interfaces
{
    public interface ITeam
    {
        int ID { get; }
        int RowID { get; }
        int RandomID { get; }
        Club Club { get; }
        Player[] Players { get; }
        ushort Reputation { get; }
        TeamType TeamType { get; }
    }
}