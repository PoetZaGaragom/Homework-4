using UnityEngine;

public abstract class TemporaryPowerup : MonoBehaviour, IPowerup {
    [SerializeField] protected float _duration;

    public virtual void Apply(GameObject target) {
        ActionOnTimer executer = target.GetComponent<ActionOnTimer>();
        if (executer != null)
            executer.ExecuteAfterTime(OnExpire, _duration);
    }

    protected abstract void OnExpire();
}
