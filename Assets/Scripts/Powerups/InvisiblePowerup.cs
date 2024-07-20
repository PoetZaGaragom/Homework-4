using UnityEngine;

public class InvisiblePowerup : TemporaryPowerup
{
    private GameObject _player;

    public override void Apply(GameObject target) {
        _player = target;
        int layer = LayerMask.NameToLayer("PlayerInvisible");
        _player.layer = layer;

        Color color = _player.GetComponent<Renderer>().material.color;
        color.a = 0.35f;
        _player.GetComponent<Renderer>().material.color = color;

        base.Apply(target);
    }

    protected override void OnExpire() {
        int layer = LayerMask.NameToLayer("Player");
        _player.layer = layer;

        Color color = _player.GetComponent<Renderer>().material.color;
        color.a = 1.0f;
        _player.GetComponent<Renderer>().material.color = color;
    }
}
