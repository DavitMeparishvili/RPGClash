using RPGClash.Domain.CharacterBehaviours;
using RPGClash.Domain.Classes;

public interface ITank : ICharacter, IAttackerBehavior, IRegeneratorBehavior, ITaunterBehavior {}
