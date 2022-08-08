using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{

    public Collider2D Collider;
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins();
        Collider.enabled = false;
    }
}
