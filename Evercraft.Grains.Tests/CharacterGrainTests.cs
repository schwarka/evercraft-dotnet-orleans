using Evercraft.Common.Entities;
using Evercraft.Orleans.Grains;
using FluentAssertions;
using NSubstitute;
using Orleans.Runtime;
using Xunit;

namespace Evercraft.Grains.Tests
{
    public class CharacterGrainTests
    {
        private readonly ICharacterGrain _subject;
        private readonly Character _subjectState;

        public CharacterGrainTests()
        {
            _subjectState = new Character();

            var persistentState = Substitute.For<IPersistentState<Character>>();
            persistentState.State.Returns(_subjectState);

            _subject = new CharacterGrain(persistentState);
        }

        #region Character Can Be Damaged

        [Theory,
         InlineData(-1, 0),
         InlineData(0, -1),
         InlineData(1, -1)]
        public async void Character_SuffersOnePointOfDamage_WhenIncomingAttack_GreaterOrEqualToArmorRating(int attackRelativeToArmor, int expectedHitPointChange)
        {
            var attack = _subjectState.Armor + attackRelativeToArmor;
            var expectedHitPoints = _subjectState.HitPoints + expectedHitPointChange;

            await _subject.HandleIncomingAttackAsync(attack);

            _subjectState.HitPoints.Should().Be(expectedHitPoints);
        }

        #endregion

    }
}