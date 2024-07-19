using BHSCamp.FSM;
using UnityEngine;

namespace BHSCamp
{
    public class DeadState : FsmState
    {
        private PatrolEnemy _enemy;
        private Animator _animator;
        private Health _health;
        private bool _respawn;
        private float _respawnTime;
        private float _timer;

        public DeadState(Fsm fsm, PatrolEnemy enemy, bool respawn, float respawnTime) : base(fsm)
        {
            _respawn = respawn;
            _respawnTime = respawnTime;
            _animator = enemy.GetComponent<Animator>();
            _enemy = enemy;
            _health = enemy.GetComponent<Health>();
        }

        public override void Enter()
        {
            _animator.SetBool("IsDead", true);
            _timer = 0;
        }

        // STEP 11: Если _respawn == true,
        // через _respawnTime секунд мы должны выйти из состояния Dead
        // и восстановить здоровье
        public override void Update(float deltaTime) {
            if (_respawn) {
                _timer += deltaTime;
                if (_timer >= _respawnTime) {
                    _animator.SetBool("IsDead", false);
                    _health.Heal(_health.MaxHealth);
                    Fsm.SetState<PatrolState>();
                }
            }
        }
    }
}