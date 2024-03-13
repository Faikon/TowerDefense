using System;
using UnityEngine;

public class TowerUpgradeArea : MonoBehaviour
{
    public event Action<bool> IsPlayerStanding;

    private bool _isPlayerStaying;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isPlayerStaying = true;
            IsPlayerStanding?.Invoke(_isPlayerStaying);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _isPlayerStaying = false;
            IsPlayerStanding?.Invoke(_isPlayerStaying);
        }
    }
}
