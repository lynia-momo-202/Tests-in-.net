namespace GameLibrary;

public class Mage
{
    private readonly Spellbook spellbook;
    public int Mana { get; private set; }

    public Mage(Spellbook spellbook, int initialMana = 100)
    {
        this.spellbook = spellbook;
        this.Mana = initialMana;
    }

    public int CastSpell(string spellName)
    {
        if (!spellbook.HasSpell(spellName))
        {
            throw new InvalidOperationException("Spell not found");
        }

        int spellPower = spellbook.GetSpellPower(spellName);
        int manaCost = spellPower / 2;

        if (Mana < manaCost)
        {
            throw new InvalidOperationException("Not enough mana");
        }

        Mana -= manaCost;
        return spellPower;
    }
}

