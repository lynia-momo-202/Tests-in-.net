namespace GameLibrary;

public class Spellbook
{
    private readonly ISpellRepository repository;

    public Spellbook(ISpellRepository repository)
    {
        this.repository = repository;
    }

    public bool HasSpell(string spellName)
    {
        return repository.GetSpellPower(spellName).HasValue;
    }

    public int GetSpellPower(string spellName)
    {
        return repository.GetSpellPower(spellName) ?? 0;
    }
}
