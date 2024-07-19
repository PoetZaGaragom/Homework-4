using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int _score;

    private void Awake() {
        if (Instance != null)
            Destroy(gameObject);

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int amount) {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(
                $"Amount should be positive: {gameObject.name}"
            );

        _score += amount;
        Debug.Log($"Score: {_score}");
    }
}
