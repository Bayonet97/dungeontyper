using System.Collections.Generic;

namespace DungeonTyper.Common.Models
{
    public interface ICharacter : ICreature
    {
        ICharacterClass CharacterClass { get; }

        List<IAbility> CharacterAbilities { get; }
        bool Alive { get; }

        int CharacterId { get; }
        //int Constitution { get; }
        //int Strength { get; }
        //int Dexterity { get; }
        //int Intelligence { get; }
    }
}