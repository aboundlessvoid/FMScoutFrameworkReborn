namespace FMScoutFramework.Core.Entities.InGame.Interfaces
{
    public interface IStaff
    {
        short CurrentReputation { get; }
        short HomeReputation { get; }
        short WorldReputation { get; }
        ushort CA { get; }
        ushort PA { get; }
        JobAttributes JobAttributes { get; }
    }
}