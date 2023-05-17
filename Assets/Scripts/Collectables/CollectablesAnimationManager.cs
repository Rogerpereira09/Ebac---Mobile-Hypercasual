using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;

public class CollectablesAnimationManager : Singleton<CollectablesAnimationManager>
{
    public List<ItemCollectableCoin> item;

    [Header("Animations")]
    public float ScaleDuration = .2f;
    public float scaleTimeBetweenPieces = .1f;
    public Ease ease = Ease.OutBack;

    private void Start()
    {
        item = new List<ItemCollectableCoin>();
    }


    public void RegisterCoin(ItemCollectableCoin i)
    {
        if (!item.Contains(i))
        {
            item.Add(i);
            i.transform.localScale = Vector3.zero;
        }

    }
    public void StartAnimations()
    {
        StartCoroutine(ScalePiecesByTime());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            StartAnimations();
        }
    }
    IEnumerator ScalePiecesByTime()
    {
        foreach (var p in item)
        {
            p.transform.localScale = Vector3.zero;
        }
        Sort();
        yield return null;

        for (int i = 0; i < item.Count; i++)
        {
            item[i].transform.DOScale(1, ScaleDuration).SetEase(ease);
            yield return new WaitForSeconds(scaleTimeBetweenPieces);

        }
    }

    private void Sort()
    {
        item = item.OrderBy(
            x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();

    }
}
