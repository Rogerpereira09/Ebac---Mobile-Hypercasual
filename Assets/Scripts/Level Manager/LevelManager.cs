using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    //Publics
    public Transform container;
    public List<GameObject> levels;
    public float timeBetweenPieces = .3f;
    public List<LevelPieceBaseSetup> levelPieceBaseSetups;

    /*
    [Header("Pieces")]
    public List<LevelPieceBase> levelPiecesStart;
    public List<LevelPieceBase> levelPieces;
    public List<LevelPieceBase> levelPiecesEnd;
    public int piecesStartNumber = 3;
    public int piecesNumber = 5;
    public int piecesEndNumber = 1;
    */

    //privates
    [SerializeField] private int _index;
    private GameObject _currentLevel;

    [SerializeField] private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
    private LevelPieceBaseSetup _currentSetup;


    [Header("Animations")]
    public float ScaleDuration = .2f;
    public float scaleTimeBetweenPieces = .1f;
    public Ease ease = Ease.OutBack;
    
    public void Awake()
    {
        //SpawnNextLevel();
        CreateLevelPieces();
    }

    private void SpawnNextLevel()
    {
        if (_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;
            if (_index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }
        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            SpawnNextLevel();
        }
    }
    #region

    private void CreateLevelPieces()
    {
      //_spawnedPieces = new List<LevelPieceBase>();
        CleanSpawnedPieces();


        if (_currentSetup != null)
        {
            _index++;
            if(_index >= levelPieceBaseSetups.Count)
            {
                ResetLevelIndex();
            }
        }

        _currentSetup = levelPieceBaseSetups[_index];

        for (int i = 0; i < _currentSetup.piecesStartNumber; i++)
        {
            CreateLevelPiece(_currentSetup.levelPiecesStart);

        }for (int i = 0; i < _currentSetup.piecesNumber; i++)
        {
            CreateLevelPiece(_currentSetup.levelPieces);
        }

        for (int i = 0; i < _currentSetup.piecesEndNumber; i++)
        {
            CreateLevelPiece(_currentSetup.levelPiecesEnd);
        }

        ColorManager.Instance.ChangeColorByType(_currentSetup.artType);

        StartCoroutine(ScalePiecesByTime());
        // StartCoroutine(CreateLevelPiecesCorroutine());
    }

    IEnumerator ScalePiecesByTime()
    {
        foreach(var p in _spawnedPieces)
        {
            p.transform.localScale = Vector3.zero;
        }
        yield return null;

        for(int  i = 0; i < _spawnedPieces.Count; i++)
        {
            _spawnedPieces[i].transform.DOScale(1, ScaleDuration).SetEase(ease);
            yield return new WaitForSeconds(scaleTimeBetweenPieces);

        }
    }

    private void CreateLevelPiece(List<LevelPieceBase> list)
    {
        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if (_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];
            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }
        else
        {
            spawnedPiece.transform.localPosition = Vector3.zero;
        }

        foreach(var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            p.ChangePiece(ArtManager.Instance.GetSetupByType(_currentSetup.artType).gameObject);

        }

        _spawnedPieces.Add(spawnedPiece);


    }

    private void CleanSpawnedPieces()
    {
        for(int i =_spawnedPieces.Count -1; i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }
        _spawnedPieces.Clear();
    }

    IEnumerator CreateLevelPiecesCorroutine()
    {
        _spawnedPieces = new List<LevelPieceBase>();
        for (int i = 0; i < _currentSetup.piecesNumber; i++)
        {
            CreateLevelPiece(_currentSetup.levelPieces);
            yield return new WaitForSeconds(timeBetweenPieces);
        }


        #endregion
    }

}