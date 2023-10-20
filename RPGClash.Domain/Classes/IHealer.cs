using RPGClash.Domain.CharacterBehaviours;
namespace RPGClash.Domain.Classes;

public interface IHealer : ICharacter, IAttackerBehavior, IRegeneratorBehavior, IHealerBehavior {}
