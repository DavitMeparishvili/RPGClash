using RPGClash.Domain.Characters;

namespace RPGClash.UnitTests
{
    public class CharacterConcreteTypesData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { new Cedrick()};
                yield return new object[] { new Guladi() };
                yield return new object[] { new Lucia() };
                yield return new object[] { new Zezva() };
            }
        }
    }
}
