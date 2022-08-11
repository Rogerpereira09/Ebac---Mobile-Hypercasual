using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class PlayerController : Singleton<PlayerController>
{


    //publics
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;
    public string TagToCheckEnemy = "Enemy";
    public string TagToCheckEndLine = "EndLine";

    public GameObject endScreen;

    //privates
    private Vector3 _pos;
    private bool _canRun;
    private float _currentSpeed;


    private void Start()
    {
        StartToRun();
        ResetSpeed();
    }

    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == TagToCheckEnemy)
        {
            EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == TagToCheckEndLine)
        {
            EndGame();
        }
    }

    public void StartToRun()
    {
        _canRun = true;
    }
    private void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    #region POWER UPS
    public void  PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }
    #endregion
}
