using System;
using UnityEngine;
using PrimeTween;

public class Item : MonoBehaviour , ICollectable
{
    [SerializeField] private int price = 20;
    
    [SerializeField] private float spinSpeed = 0.5f;
    [SerializeField] private float moveYaxisSpeed = 0.5f;
    [SerializeField] private GameObject[] allEnemies;

    private void Start()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void FixedUpdate()
    {
        transform.Rotate(Vector3.up, spinSpeed * 90f);
        // transform.position += Vector3.up * (Time.deltaTime * moveYaxisSpeed);
    }
    
    void PrintCurrentMoney(int currentMoney)
    {
        Debug.Log($"Current moeny is {currentMoney}");
    }

    private void OnEnable()
    {
        Tween.PositionY(transform, transform.position.y + 0.9f, 1f, cycles: 9999, cycleMode: CycleMode.Yoyo);
        GameManager.Instance.OnMoneyChanged.AddListener(PrintCurrentMoney);
    }

    private void OnDisable()
    {
        GameManager.Instance.OnMoneyChanged.RemoveListener(PrintCurrentMoney);
    }

    public void Collect()
    {
        GameManager.Instance.Money += price;
        
        foreach (GameObject enemy in allEnemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.ScaredTime();
            }
        }
        Destroy(gameObject);
    }
}