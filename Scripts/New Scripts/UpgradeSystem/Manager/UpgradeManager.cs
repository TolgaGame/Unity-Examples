using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    #region Variables

    public static UpgradeManager Instance;

    public int coin;

    private Upgrade[] _upgrades;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        Instance = this;
        _upgrades = GetComponentsInChildren<Upgrade>();
    }

    private void Start()
    {
        GetData();
    }

    #endregion

    #region Other Methods

    public void SetCoin(int _newCoin)
    {
        coin -= _newCoin;
        PlayerPrefs.SetInt("Coin", coin);
        MoneyControll();
    }

    private void GetData()
    {
        coin = PlayerPrefs.GetInt("Coin", 1000);
        for (int i = 0; i < _upgrades.Length; i++)
            _upgrades[i].GetData();
    }

    private void MoneyControll()
    {
        for (int i = 0; i < _upgrades.Length; i++)
            _upgrades[i].MoneyControll();
    }

    #endregion
}
