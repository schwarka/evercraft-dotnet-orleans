namespace Evercraft.Common.Entities
{
    public enum CharacterAlignment
    {
        Evil,
        Good,
        Neutral,
    }

    public class Character
    {
        private CharacterAlignment? _alignment;
        private int? _armor;
        private int? _hitPoints;
        private string _name;

        public CharacterAlignment Alignment
        {
            get => _alignment ?? CharacterAlignment.Neutral;
            set => _alignment = value;
        }

        public int Armor
        {
            get => _armor ?? 10;
            set => _armor = value;
        }

        public int HitPoints
        {
            get => _hitPoints ?? 5;
            set => _hitPoints = value;
        }

        public string Name
        {
            get => _name ?? string.Empty;
            set => _name = value;
        }
    }
}