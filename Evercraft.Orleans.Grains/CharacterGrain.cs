using System.Threading.Tasks;
using Evercraft.Common.Entities;
using Orleans;
using Orleans.Runtime;

namespace Evercraft.Orleans.Grains
{
    public interface ICharacterGrain : IGrainWithIntegerKey
    {
        Task HandleIncomingAttackAsync(int attackPower);
    }

    public class CharacterGrain : Grain, ICharacterGrain
    {
        private readonly IPersistentState<Character> _character;
        public CharacterGrain(IPersistentState<Character> character)
        {
            _character = character;
        }

        public Task HandleIncomingAttackAsync(int attackPower)
        {
            if (attackPower >= _character.State.Armor)
                _character.State.HitPoints -= 1;

            return Task.CompletedTask;
        }
    }
}