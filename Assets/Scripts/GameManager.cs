using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    public UnityEvent<int> OnMoneyChanged;
    
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
}
