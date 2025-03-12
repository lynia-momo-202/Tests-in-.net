namespace GameLibrary;

public interface ISpellRepository
{
    int? GetSpellPower(string spellName);
}
