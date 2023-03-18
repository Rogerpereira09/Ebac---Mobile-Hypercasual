using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Publics
    public Transform container;
    public List<GameObject> levels;


    //privates
   [SerializeField] private int _index;

    public void Awake()
    {
        SpawnLevel();
    }

    private void SpawnLevel()
    {
        var currentLevel = Instantiate(levels[_index], container);
        currentLevel.transform.localPosition = Vector3.zero;
    }
}
