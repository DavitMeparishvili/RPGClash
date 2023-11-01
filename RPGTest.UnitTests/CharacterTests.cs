using FluentAssertions;
using RPGClash.Domain.Characters;

namespace RPGClash.UnitTests
{
    public class CharacterTests
    {
        private Character _dummy;
        public CharacterTests()
        {
            _dummy = new Guladi();
        }

        [Theory]
        [MemberData("TestData", MemberType =typeof(CharacterConcreteTypesData))]
        public void Charater_NameShouldExist(Character character)
        {
            character.Name.Should().NotBe(0); // Assert that Age is not the default value
        }

        [Theory]
        [MemberData("TestData", MemberType = typeof(CharacterConcreteTypesData))]
        public void Charater_MaxHealthIsSet(Character character)
        {
            character.MaxHealth.Should().NotBe(0); // Assert that Age is not the default value
        }

        [Theory]
        [MemberData("TestData", MemberType = typeof(CharacterConcreteTypesData))]
        public void Charater_MaxManaIsSet(Character character)
        {
            character.MaxMana.Should().NotBe(0); // Assert that Age is not the default value
        }

        [Theory]
        [MemberData("TestData", MemberType = typeof(CharacterConcreteTypesData))]
        public void Charater_OnCreationCurrentManaIsMaxMana(Character character)
        {
            character.MaxHealth.Should().NotBe(0);
            character.MaxMana.Should().Be(character.CurrentMana);
        }

        [Theory]
        [MemberData("TestData", MemberType = typeof(CharacterConcreteTypesData))]
        public void Charater_OnCreationCurrentHealthIsMaxHealth(Character character)
        {
            character.MaxMana.Should().NotBe(0);
            character.MaxHealth.Should().Be(character.CurrentHealth);
        }

        [Theory]
        [MemberData("TestData", MemberType = typeof(CharacterConcreteTypesData))]
        public void Charater_BasicAttackShouldHaveNoManaCost(Character character)
        {
            character.BasicAttack(_dummy);
            character.MaxMana.Should().Be(character.CurrentMana);
        }

        [Theory]
        [MemberData("TestData", MemberType = typeof(CharacterConcreteTypesData))]
        public void Charater_BasicAttackReducesHealthByBasicHealPoint(Character character)
        {
            var dummy = character.BasicAttack(_dummy);
            dummy.CurrentHealth.Should().Be(dummy.MaxHealth - character.BasicHealPoint);
        }
    }
}
