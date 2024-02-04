using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
    // Kartın açık olup olmadığını kontrol eder.
    [HideInInspector] public bool IsUnlocked;
    // Resim olarak hangi sprite olmalı.
    [SerializeField] private Sprite _skinSprite;
    // Sprite ının değiştirdiğimiz Image componenti.
    private Image _myImage;
    // Çerçevemiz.
    private Image _myFrame;
    // Buttonumuz.
    private Button _myButton;
    // Kartın seçili olup olmadığını kontrol eder.
    private bool _isSelected;

    private void Awake() {
        _myImage = GetComponent<Image>();
        _myFrame = transform.parent.GetComponent<Image>();
        _myButton = GetComponent<Button>();
    }

    private void Start() {
        GetData();
        if (IsUnlocked)
            OpenCard();
    }

    // Kart kilidini açma.
    public void UnlockCard() {
        IsUnlocked = true;
        PlayerPrefs.SetInt("Card" + transform.parent.name, 1);
        _myButton.interactable = IsUnlocked;
        OpenCard();
    }

    // Kartı seçme.
    public void SelectCard() {
        ToggleCard(true);
        CardManager.Instance.SelectCard(_myFrame, this);
    }

    // Kartı seçme durumu.
    public void ToggleCard(bool _isSelected) {
        int _active = _isSelected ? 1 : 0;
        PlayerPrefs.SetInt(transform.parent.name + "Selected", _active);
    }

    public Image GetFrame() {
        return _myFrame;
    }

    // Kartı açınca kendi skin sprite ı resmin yerine gelir.
    private void OpenCard() {
        _myImage.sprite = _skinSprite;
    }

    private void GetData() {
        IsUnlocked = PlayerPrefs.GetInt("Card" + transform.parent.name, 0) == 1 ? true : false;
        _isSelected = PlayerPrefs.GetInt(transform.parent.name + "Selected", 0) == 1 ? true : false;
        _myButton.interactable = IsUnlocked;
        if (_isSelected)
            SelectCard();
    }
}