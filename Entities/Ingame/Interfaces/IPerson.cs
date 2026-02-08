using System;

namespace FMScoutFramework.Core.Entities.InGame.Interfaces
{
    public interface IPerson
    {
        int Age { get; }
        PersonAttributes Attributes { get; }
        //Club Club { get; }
        Contract Contract { get; }
        DateTime DateOfBirth { get; }
        string Firstname { get; }
        string Fullname { get; }
        int ID { get; }
        byte InternationalApps { get; }
        byte InternationalGoals { get; }
        string Lastname { get; }
        Nation Nationality { get; }
        string Nickname { get; }
        int RowID { get; }
        byte U21InternationalApps { get; }
        byte U21InternationalGoals { get; }
    }
}