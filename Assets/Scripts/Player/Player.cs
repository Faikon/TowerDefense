using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<int> GoldChanged;

    public int Gold { get; private set; }

    private void Start()
    {
        Gold = 2000;
    }

    public void AddGold(int gold)
    {
        if (gold > 0)
        {
            Gold += gold;
            GoldChanged?.Invoke(Gold);
        }
    }

    public bool TrySpendGold(int gold)
    {
        if (gold > 0 && Gold - gold >= 0)
        {
            Gold -= gold;
            GoldChanged?.Invoke(Gold);

            return true;
        }

        return false;
    }
}
