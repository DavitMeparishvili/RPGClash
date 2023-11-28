using Microsoft.Extensions.DependencyInjection;
using RPGClash.Domain;
using RPGClash.Domain.Characters;
using RPGClash.GameEngine.Factory.Abstract;
using System.Reflection;

namespace RPGClash.GameEngine.Factory.Concrete
{
    public class CharacterFactory : ICharacterFactory
    {
        public Character CreateCharacter(CharacterName character)
        {
            Assembly[] loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            var domainAssemblies = loadedAssemblies
                .Where(assembly => assembly == typeof(AssamblyReference).Assembly)
                .ToList();

            // Iterate through the assemblies and types to find a suitable type
            foreach (var assembly in domainAssemblies)
            {
                var characterType = assembly.GetTypes()
                    .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(Character)))
                    .FirstOrDefault(t =>
                    {
                        var nameProperty = t.GetProperty("Name");
                        if (nameProperty != null)
                        {
                            var defaultValue = nameProperty.GetValue(Activator.CreateInstance(t));
                            return defaultValue?.ToString() == character.ToString();
                        }
                        return false;
                    });

                if (characterType != null)
                {
                    // Create an instance of the found type
                    return (Character)Activator.CreateInstance(characterType);
                }
            }

            // If no suitable type is found, return null or handle the case accordingly.
            return null;
        }
    }
}
