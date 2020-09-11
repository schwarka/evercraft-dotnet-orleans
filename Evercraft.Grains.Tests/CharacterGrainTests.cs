using System.Runtime.InteropServices;
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

        [Theory,
         InlineData(-1, 0),
         InlineData(0, -2),
         InlineData(1, -2)]
        public async void Character_SuffersTwoPointsOfDamage_WhenIncomingAttack_GreaterOrEqualToArmorRating_AndIsCritical(int attackRelativeToArmor, int expectedHitPointChange)
        {
            var attack = _subjectState.Armor + attackRelativeToArmor;
            var expectedHitPoints = _subjectState.HitPoints + expectedHitPointChange;

            await _subject.HandleIncomingAttackAsync(attack, true);

            _subjectState.HitPoints.Should().Be(expectedHitPoints);
        }

        [Fact]
        public async void Character_DoesNotSufferAdditionalDamage_WhenDead()
        {
            _subjectState.HitPoints = 0;

            await _subject.HandleIncomingAttackAsync(20, true);

            _subjectState.HitPoints.Should().Be(0);
        }
    }
}