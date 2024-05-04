using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _denomination = 1;

    public event Action <Coin> HaveTaken;

    public int PickUp()
    {
        HaveTaken?.Invoke(this);

        return _denomination;
    }
}
