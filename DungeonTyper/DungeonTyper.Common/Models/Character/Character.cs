using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTyper.Common.Models
{
    public class Character : ICharacter
    {
        public int CharacterId { get; private set; }
        public string Name { get; private set; }
        public int HitPoints { get; private set; }
        public CharacterClass CharacterClass { get; private set; }
        public int Constitution { get; private set; }
        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Intelligence { get; private set; }

        public Character(int characterId, string name, CharacterClass characterClass)
        {
            CharacterId = characterId;
            Name = name;
            CharacterClass = characterClass;
        }
        public string Attack(IAbility ability)
        {
            string descriptiontext = GetAbilityCombatDescription(ability.AbilityName);

            // int DoDamage();
            // _combat.HandleDamage(int)
            return "You use" + ability.AbilityName + " " + descriptiontext;
        }
        private string GetAbilityCombatDescription(string name)
        {
            if (name == "Fireball")
            {
                return ". It hurls towards the opponent!";
            }
            else if (name == "Flash Heal")
            {
                return ". It makes you feel enlightened and refreshed!";
            }
            else if (name == "Charge")
            {
                return ". You charge towards the opponent, bump into it and deal damage!";
            }
            else if (name == "BackStab")
            {
                return ". You quickly turn to the opponent's back and stab it painfully!";
            }
            else if (name == "Stomp")
            {
                return ". You stomp violently on the ground, which causes the ground to shake!";
            }
            else return "You attacked wildly but nothing happened.";
        }
        public string CharacterLosesBattle()
        {
            return "You lose.";
        }

        public string CharacterWinsBattle()
        {
            return "You win.";
        }

        public void EquipItem(IItem item)
        {
            throw new NotImplementedException();
        }

        public void OpenInventory()
        {
            throw new NotImplementedException();
        }

        public void SetCharacterClass(CharacterClass characterClass)
        {
            CharacterClass = characterClass;
        }

        public string StartBattle()
        {
            return "You engage!";
        }

        public void TakeDamage(int damage)
        {
            throw new NotImplementedException();
        }
    }
}
