using Evercraft.Common.Entities;
using FluentAssertions;
using Xunit;

namespace Evercraft.Common.Tests.Entities
{
    public class CharacterTests
    {
        private readonly Character _subject;

        public CharacterTests()
        {
            _subject = new Character();
        }

        #region Name

        [Fact]
        public void Name_DefaultsTo_EmptyString()
        {
            _subject.Name.Should().BeEmpty();
        }

        [Fact]
        public void Name_CanBeChanged()
        {
            const string expectedName = "The Dude";
            _subject.Name = expectedName;
            _subject.Name.Should().Be(expectedName);
        }

        #endregion

        #region Alignment

        [Fact]
        public void Alignment_DefaultsTo_Neutral()
        {
            _subject.Alignment.Should().Be(CharacterAlignment.Neutral);
        }

        [Theory,
         InlineData(CharacterAlignment.Good),
         InlineData(CharacterAlignment.Neutral),
         InlineData(CharacterAlignment.Evil)]
        public void Alignment_CanBeChanged_ToAnyValidAlignment(CharacterAlignment alignment)
        {
            _subject.Alignment = alignment;
            _subject.Alignment.Should().Be(alignment);
        }

        #endregion

        #region Armor

        [Fact]
        public void Armor_DefaultsTo_10()
        {
            _subject.Armor.Should().Be(10);
        }

        [Fact]
        public void Armor_CanBeChanged()
        {
            const int expectedArmor = 42;
            _subject.Armor = expectedArmor;
            _subject.Armor.Should().Be(expectedArmor);
        }

        #endregion

        #region Hit Points

        [Fact]
        public void HitPoints_DefaultTo_5()
        {
            _subject.HitPoints.Should().Be(5);
        }

        [Fact]
        public void HitPoints_CanBeChanged()
        {
            _subject.HitPoints = int.MaxValue;
            _subject.HitPoints.Should().Be(int.MaxValue);
        }

        #endregion
    }
}