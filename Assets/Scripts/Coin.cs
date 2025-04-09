using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int price = 5;
    void PrintCurrentMoney(int currentMoney)
    {
        Debug.Log($"Current moeny is {currentMoney}");
    }

    private void OnEnable()
    {
        GameManager.Instance.OnMoneyChanged.AddListener(PrintCurrentMoney);
    }

    private void OnDisable()
    {
        GameManager.Instance.OnMoneyChanged.RemoveListener(PrintCurrentMoney);
    }

    public void Collect()
    {
        GameManager.Instance.Money = price;
         Destroy(gameObject);
    }
}
