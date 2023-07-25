using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(GameTime))]
public class GameTimeEditor : Editor
{

    public override void OnInspectorGUI()
    {
        GameTime myTarget = (GameTime)target;


        myTarget.trophyPrefab = (GameObject)EditorGUILayout.ObjectField(myTarget.trophyPrefab, typeof(GameObject), true);
        myTarget.daysPlayed = EditorGUILayout.IntField("Number of days played", myTarget.daysPlayed);
        myTarget.hoursPlayed = EditorGUILayout.IntField("Daily hours", myTarget.hoursPlayed);

        EditorGUILayout.LabelField("Total hours played", myTarget.totalHours.ToString());

        if(myTarget.totalHours > 100)
        {
            EditorGUILayout.HelpBox("Trophy Earned!", MessageType.Info);
        }

        if(GUILayout.Button("Create Trophy"))
        {
            myTarget.CreateTrophyPrefab();
        }

    }



}
