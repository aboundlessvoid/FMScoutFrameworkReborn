namespace FMScoutFramework.Core.Entities.InGame.Interfaces
{
    public interface IClub
    {
        Nation BasedNation { get; }
        Nation ContinentalCupNation { get; }
        City City { get; }
        //ClubFinances ClubFinances { get; } TODO
        //int ClubFinancesAddress { get; }
        int ID { get; }
        int RowID { get; }
        int RandomID { get; }
        string FullName { get; }
        Nation Nation { get; }
        string ShortName { get; }
        string SixLetterName { get; }
        Team[] Teams { get; }
    }
}