using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvincible : PowerUpBase
{


    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.SetPowerUptext("You found a letter!");
        PlayerController.Instance.SetInvincible();
        PlayerController.Instance.Bounce();
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.SetInvincible(false);
        PlayerController.Instance.SetPowerUptext("");
    }

}
