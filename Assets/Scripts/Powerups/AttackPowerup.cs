using BHSCamp;
using UnityEngine;

public class AttackPowerup : TemporaryPowerup {
    [SerializeField] private int _attackMultiplier;
    private InstantDamageDealer _instantDamageDealer;

    public override void Apply(GameObject target) {
        _instantDamageDealer = target.GetComponentInChildren<InstantDamageDealer>(true);
        _instantDamageDealer?.SetMultiplier(_attackMultiplier);
        base.Apply(target);
    }

    protected override void OnExpire() {
        _instantDamageDealer?.SetMultiplier(1);
    }
}