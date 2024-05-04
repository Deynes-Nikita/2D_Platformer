using UnityEngine;

[RequireComponent (typeof(Inventory))]
public class Player : Character
{
    private Inventory _inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _inventory.GetMoney(coin.PickUp());
        }
    }

    protected override void GetComponents()
    {
        base.GetComponents();
        _inventory = GetComponent<Inventory>();
    }
}
