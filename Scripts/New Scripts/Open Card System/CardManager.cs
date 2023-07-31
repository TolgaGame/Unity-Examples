using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    #region Variables

    // Singleton
    public static CardManager Instance;

    // Karıştırma hareket sayısı.
    [SerializeField] private int _shuffleTimes;
    // Her kart açmada harcanacak para.
    [SerializeField] private int _openCardCost;
    // Her kartın orjinal çerçeve rengi.
    [SerializeField] private Color _defaultColor;
    // Karıştırma esnasında üzerinden geçilen kartın rengi.
    [SerializeField] private Color _frameColor;
    // Seçilen kartın çerçeve rengi
    [SerializeField] private Color _selectedColor;
    // Kart açma butonu.
    [SerializeField] private Button _openCardButton;

    // Bütün skin kartları.
    private Card[] _allCards;
    // Kapalı olan kartların listesi.
    private List<Card> _lockedCards;
    // Karıştırma esnasında üzerinden geçilen kart.
    private Card _currentCard;
    // Seçilen kart.
    private Card _selectedCard;
    // Karıştırma esnasında aynı index değerlerinin gelmesini engellemek için en sonki random sayı tutulur.
    private int _lastRandom;
    // Para.
    private int _coin;
    // Paramız var mı ?
    private bool _haveMoney;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        Instance = this;
        GetData();
        _lastRandom = -1;
        _allCards = GetComponentsInChildren<Card>();
        _lockedCards = new List<Card>();
        StartCoroutine(LoadCards());
    }

    #endregion

    #region Other Methods

    // Kart açma butonunun fonksiyonu.
    public void OpenCard()
    {
        if (_lockedCards.Count > 1)
            StartCoroutine(ShuffleCards());
        else
            UnlockLastCard();
    }

    // Kart seçme.
    public void SelectCard(Image _frame,Card _selected)
    {
        if (_selectedCard != null)
        {
            _selectedCard.GetFrame().color = _defaultColor;
            _selectedCard.ToggleCard(false);
        }
        _selectedCard = _selected;
        _frame.color = _selectedColor;
    }

    // Karıştırma sırasında çekilen random sayı.
    private int GetRandom()
    {
        int _randomNumber;

        int _random = Random.Range(0, _lockedCards.Count);

        if (_random != _lastRandom)
        {
            _randomNumber = _random;
            _lastRandom = _randomNumber;
        }
        else
            _randomNumber = GetRandom();

        return _randomNumber;
    }

    // Son kart kalma durumu.
    private void UnlockLastCard()
    {
        SetCoin(-_openCardCost);
        _openCardButton.interactable = false;
        _currentCard.GetFrame().color = _defaultColor;
        _currentCard = _lockedCards[0];
        _currentCard.GetFrame().color = _frameColor;
        _lockedCards.Clear();
        _currentCard.UnlockCard();
    }

    // Kartları karıştırma.
    private IEnumerator ShuffleCards()
    {
        SetCoin(-_openCardCost);
        _openCardButton.interactable = false;
        for (int i = 0; i < _shuffleTimes; i++)
        {
            if (_currentCard != null && _currentCard != _selectedCard)
                _currentCard.GetFrame().color = _defaultColor;
            int _random = GetRandom();
            _lockedCards[_random].GetFrame().color = _frameColor;
            _currentCard = _lockedCards[_random];
            yield return new WaitForSeconds(.1f);
        }

        _lockedCards.Remove(_currentCard);
        _currentCard.UnlockCard();
        if(_haveMoney)
            _openCardButton.interactable = true;
    }

    // Açılmayan kartların listeye aktarılması.
    private IEnumerator LoadCards()
    {
        yield return new WaitForSeconds(.5f);
        for (int i = 0; i < _allCards.Length; i++)
        {
            if (!_allCards[i].isUnlocked)
                _lockedCards.Add(_allCards[i]);
        }
    }

    // Para değişikliği.
    private void SetCoin(int _newCoin)
    {
        _coin += _newCoin;
        PlayerPrefs.SetInt("Coin",_coin);
        MoneyControll();
    }

    private void GetData()
    {
        _coin = PlayerPrefs.GetInt("Coin", 1000);
        MoneyControll();
    }

    // Para kontrolü.
    private void MoneyControll()
    {
        _haveMoney = _coin >= _openCardCost ? true : false;
        _openCardButton.interactable = _haveMoney;
    }

    #endregion
}
