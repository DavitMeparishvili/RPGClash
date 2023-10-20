using RPGClash.Domain.CharacterBehaviours;

namespace RPGClash.Domain.Classes;

public interface IMarksman : ICharacter, IAttackerBehavior, IRegeneratorBehavior, IHunterBehavior { }
