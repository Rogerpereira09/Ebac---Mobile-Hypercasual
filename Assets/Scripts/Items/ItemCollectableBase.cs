using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{

    public string compareTag = "Player";
    public ParticleSystem ParticleSystem;
    public float timeToHide = 3;
    public GameObject graphicItem;



    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
        //if (ParticleSystem != null) ParticleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        HideItens();
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (ParticleSystem != null)
        {
            ParticleSystem.transform.SetParent(null);
            ParticleSystem.Play();
        }
        if (audioSource != null) audioSource.Play();
    }

    protected virtual void HideItens()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        Invoke("HideObject", timeToHide);
    }
        
}
