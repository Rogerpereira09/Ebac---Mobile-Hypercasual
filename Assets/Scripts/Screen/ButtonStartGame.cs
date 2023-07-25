using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStartGame : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public void Onclick()
    {
        particleSystem.Play();
    }
}
