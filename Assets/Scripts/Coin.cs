using System;
using UnityEngine;
using PrimeTween;

public class Coin : MonoBehaviour , ICollectable
{
    [SerializeField] private int price = 5;
    
    [SerializeField] private float spinSpeed = 0.5f;
    [SerializeField] private float moveYaxisSpeed = 0.5f;

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
        Tween.PositionY(transform, transform.position.y + 0.25f, 1f, cycles: 9999, cycleMode: CycleMode.Yoyo);
        GameManager.Instance.OnMoneyChanged.AddListener(PrintCurrentMoney);
    }

    private void OnDisable()
    {
        GameManager.Instance.OnMoneyChanged.RemoveListener(PrintCurrentMoney);
    }

    public void Collect()
    {
        GameManager.Instance.Money += price;
         Destroy(gameObject);
    }
}
