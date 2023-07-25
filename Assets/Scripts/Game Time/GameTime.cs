using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    public GameObject trophyPrefab;

    public int hoursPlayed = 5;
    public int daysPlayed = 7;

    public int totalHours
    {
        get { return hoursPlayed * daysPlayed; }
    }

    public void CreateTrophyPrefab()
    {
        var a = Instantiate(trophyPrefab);
        a.transform.position = Vector3.zero;
    }
}
