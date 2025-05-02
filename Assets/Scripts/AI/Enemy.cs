using System;
using System.Collections;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    public Transform[] ObserveLocation => _observeLocation;
    
    [SerializeField]private Transform[] _observeLocation;
    [SerializeField]private NavMeshAgent _agent;
    [SerializeField]private GameObject _enemyPrefab;
    [SerializeField]private Transform _spawnPoint;
    

    [SerializeField] private Material _scaredMaterial;
    private Material _originalMaterial;
    
    
    public float detectionRadius = 5f;
    public float atkRange = 1f;
    public Transform target;
    public bool isScared = false;
    
    private State _currentState;

    private void Start()
    {
       _originalMaterial = _enemyPrefab.GetComponent<MeshRenderer>().material;
        _currentState = new Roaming(this, _agent);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void Attack(Character target)
    {
        Debug.Log("I attack player");
        base.Attack(target);
    }
    
    private Coroutine _scaredCoroutine;

    public void ScaredTime(float duration = 6f)
    {
        if (_scaredCoroutine != null)
        {
            StopCoroutine(_scaredCoroutine);
        }
        _scaredCoroutine = StartCoroutine(ScaredRoutine(duration));
    }
    private IEnumerator ScaredRoutine(float duration)
    {
        isScared = true;
        _enemyPrefab.GetComponent<MeshRenderer>().material = _scaredMaterial;

        yield return new WaitForSeconds(duration);

        isScared = false;
        _enemyPrefab.GetComponent<MeshRenderer>().material = _originalMaterial;
        _scaredCoroutine = null;
    }

    private void Update()
    {
        _currentState = _currentState.Process();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isScared)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                
                transform.position = _spawnPoint.transform.position;
                
                isScared = false;
                _enemyPrefab.GetComponent<MeshRenderer>().material = _originalMaterial;
            }
        }
    }
}
