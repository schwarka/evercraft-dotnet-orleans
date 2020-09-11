using System.Threading.Tasks;
using Evercraft.Common.Entities;
using Orleans;
using Orleans.Runtime;

namespace Evercraft.Orleans.Grains
{
    public interface ICharacterGrain : IGrainWithIntegerKey
    {
        Task HandleIncomingAttackAsync(int attackPower, bool isCriticalHit = false);
    }

    public class CharacterGrain : Grain, ICharacterGrain
    {
        private readonly IPersistentState<Character> _character;
        public CharacterGrain(IPersistentState<Character> character)
        {
            _character = character;
        }

        public Task HandleIncomingAttackAsync(int attackPower, bool isCriticalHit = false)
        {
            var isSuccessfulAttack =  _character.State.IsAlive
                                      && attackPower >= _character.State.Armor;

            _character.State.HitPoints = (isSuccessfulAttack, isCriticalHit) switch
            {
                (true, true) => _character.State.HitPoints - 2,
                (true, false) => _character.State.HitPoints - 1,
                (false, _) => _character.State.HitPoints
            };

            return Task.CompletedTask;
        }
    }
}