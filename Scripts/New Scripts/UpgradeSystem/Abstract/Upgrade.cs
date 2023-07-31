using UnityEngine;
using UnityEngine.UI;

public abstract class Upgrade : MonoBehaviour
{

    #region Variables

    [SerializeField] private int _upgradeID;
    [SerializeField] private Text _costText;
    [SerializeField] private Text _levelText;
    [SerializeField] private int[] _upgradeCosts;

    protected int _upgradeLevel;

    private Button _myButton;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        _myButton = GetComponent<Button>();
    }

    #endregion

    #region Other Mehods

    protected void LevelUp()
    {
        UpgradeManager.Instance.SetCoin(_upgradeCosts[_upgradeLevel - 1]);
        _upgradeLevel++;
        PlayerPrefs.SetInt(_upgradeID.ToString(), _upgradeLevel);
        UpdateText();
    }

    public void GetData()
    {
        _upgradeLevel = PlayerPrefs.GetInt(_upgradeID.ToString(), 1);
        UpdateText();
        MoneyControll();
    }

    public void MoneyControll()
    {
        int _coin = UpgradeManager.Instance.coin;
        if (_coin >= _upgradeCosts[_upgradeLevel - 1])
            _myButton.interactable = true;
        else
            _myButton.interactable = false;
    }

    private void UpdateText()
    {
        _costText.text = _upgradeCosts[_upgradeLevel - 1].ToString();
        _levelText.text = _upgradeLevel.ToString();
    }

    #endregion
}
