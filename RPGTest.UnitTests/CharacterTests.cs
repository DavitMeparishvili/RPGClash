using FluentAssertions;
using RPGClash.Domain.Characters;
using RPGClash.UnitTests.Shared;

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
            //Assert
            character.Name.Should().NotBe(0); // Assert that Age is not the default value
        }

        [Theory]
        [MemberData("TestData", MemberType = typeof(CharacterConcreteTypesData))]
        public void Charater_MaxHealthIsSet(Character character)
        {
            //Assert
            character.MaxHealth.Should().NotBe(0); // Assert that Age is not the default value
        }

        [Theory]
        [MemberData("TestData", MemberType = typeof(CharacterConcreteTypesData))]
        public void Charater_MaxManaIsSet(Character character)
        {
            //Assert
            character.MaxMana.Should().NotBe(0); // Assert that Age is not the default value
        }

        [Theory]
        [MemberData("TestData", MemberType = typeof(CharacterConcreteTypesData))]
        public void Charater_OnCreationCurrentManaIsMaxMana(Character character)
        {
            //Act
            character.MaxHealth.Should().NotBe(0);
            
            //Assert
            character.MaxMana.Should().Be(character.CurrentMana);
        }

        [Theory]
        [MemberData("TestData", MemberType = typeof(CharacterConcreteTypesData))]
        public void Charater_OnCreationCurrentHealthIsMaxHealth(Character character)
        {
            //Act
            character.MaxMana.Should().NotBe(0);
            
            //Assert
            character.MaxHealth.Should().Be(character.CurrentHealth);
        }

        [Theory]
        [MemberData("TestData", MemberType = typeof(CharacterConcreteTypesData))]
        public void Charater_BasicAttackShouldHaveNoManaCost(Character character)
        {
            //Act
            character.BasicAttack(_dummy);

            //Assert
            character.MaxMana.Should().Be(character.CurrentMana);
        }

        [Theory]
        [MemberData("TestData", MemberType = typeof(CharacterConcreteTypesData))]
        public void Charater_BasicAttackReducesHealthByBasicHeatPoint(Character character)
        {
            // Arrange and Act
            var dummy = character.BasicAttack(_dummy);

            //Assert
            dummy.CurrentHealth.Should().Be(dummy.MaxHealth - character.BasicHeatPoint);
        }

        [Theory]
        [MemberData("TestData", MemberType = typeof(CharacterConcreteTypesData))]
        public void Character_RegenerateRestoresHealth(Character character)
        {
            // Arrange
            var damage = 600;
            character.CurrentHealth -= damage;

            //Act
            character.Regenerate();

            //Assert
            character.CurrentHealth.Should().Be(character.MaxHealth - damage + character.BasicHealingPoint);
        }

        [Theory]
        [MemberData("TestData", MemberType = typeof(CharacterConcreteTypesData))]
        public void Character_RegenerateConsumesMana(Character character)
        {
            // Arrange
            var damage = 600;
            character.CurrentHealth -= damage;

            //Act
            character.Regenerate();

            //Assert
            character.CurrentMana.Should().Be(character.MaxMana - 60);
        }


        [Theory]
        [MemberData("TestData", MemberType = typeof(CharacterConcreteTypesData))]
        public void Character_RegenerateAvoidsOverHeal(Character character)
        {
            // Arrange
            var damage = 1;
            character.CurrentHealth -= damage;

            //Act
            character.Regenerate();

            //Assert
            character.CurrentHealth.Should().Be(character.MaxHealth);
        }

        [Theory]
        [MemberData("TestData", MemberType = typeof(CharacterConcreteTypesData))]
        public void Character_IsKilledWhenGivenFatalBlowWithZeroHealth(Character character)
        {
            // Arrange
            _dummy.CurrentHealth = 1;

            //Act
            character.BasicAttack(_dummy);

            //Assert
            _dummy.IsAlive.Should().Be(false);
            _dummy.CurrentHealth.Should().Be(0);
        }

        [Theory]
        [MemberData("TestData", MemberType = typeof(CharacterConcreteTypesData))]
        public void Character_TauntedCharacterCanOnlyHitTaunter(Character character)
        {
            // Arrange
            var tank = new Zezva();
            tank.Taunt(character);

            //Act
            character.BasicAttack(_dummy);

            //Assert
            _dummy.CurrentHealth.Should().Be(_dummy.MaxHealth);
            tank.CurrentHealth.Should().Be(tank.MaxHealth - character.BasicHeatPoint);
        }
    }
}
