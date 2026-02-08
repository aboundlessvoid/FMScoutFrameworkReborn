namespace FMScoutFramework.Core.Entities.InGame.Interfaces
{
    public interface INation
    {
        int RowID { get; }
        int ID { get; }
        int RandomID { get; }
        string Name { get; }
        string NationalityName { get; }
        //RivalNation[] RivalNations { get; }
        string ShortName { get; }
        //Team[] Teams { get; }
        string ThreeLetterName { get; }
        Continent Continent { get; }
        //Region Region { get; } TODO
        //Currency Currency { get; } TODO
        //Stadium NationalStadium { get; } TODO
        // TODO: very incomplete
    }
}