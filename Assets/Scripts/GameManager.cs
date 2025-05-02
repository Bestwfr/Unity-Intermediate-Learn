using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    public UnityEvent<int> OnMoneyChanged;
    
    public enum PowerUpType { Money, DoubleMoney, ResetMoney }
    
    [SerializeField] private TMP_Text _moneyText;
    private int _money;

    public int Money
    {
        get { return _money; }
        
        set
        {
            //Money += 123
            //value = 123
            _money = value;
            //_money += value
            OnMoneyChanged.Invoke(_money);
        }
    }

    private void Update()
    {
        _moneyText.text = _money.ToString();
    }

    public void ApplyPowerUp(PowerUpType powerUpType, int amount = 0)
    {
        switch (powerUpType)
        {
            case PowerUpType.Money:
                Money += amount;
                break;
            case PowerUpType.DoubleMoney:
                Money *= 2;
                break;
            case PowerUpType.ResetMoney:
                Money = 0;
                break;
        }
    }

    [Button("Debug Money")]
    public void DebugCurrentMoney()
    {
        Debug.Log($"Current money: {_money}");
    }
}
