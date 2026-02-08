namespace FMScoutFramework.Core.Entities.InGame.Interfaces
{
    public interface IContinent
    {
        int RowID { get; }
        int ID { get; }
        int RandomID { get; }
        string Name { get; }
        string ThreeLetterName { get; }
        string ContinentalityName { get; }
        string FederationName { get; }
        string ShortFederationName { get; }
        //float RegionalStrength { get; }
        string ForegroundColor { get; }
        string BackgroundColor { get; }
        string TrimColor { get; }
    }
}