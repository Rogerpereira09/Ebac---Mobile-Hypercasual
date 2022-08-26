using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoins : PowerUpBase
{

    [Header("Coins Collector")]
    public float sizeAmount = 9;


    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.ChangeCoinCollectorSize(sizeAmount);
    }


    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ChangeCoinCollectorSize(1);
    }
}
