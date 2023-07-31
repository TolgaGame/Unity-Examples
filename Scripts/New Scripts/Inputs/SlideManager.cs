using UnityEngine;

public class SlideManager : MonoBehaviour
{
    #region Variables

    // Kontrol edilecek obje.
    [SerializeField] private Transform _target;
    // Slide hassasiyeti.
    [SerializeField] private float _smoothness;

    // Tıklanan ilk nokta.
    private float _firstValue;
    // Tıklanan son nokta.
    private float _lastValue;
    // İlk nokta ile son nokta arasındaki mesafe.
    private float _distance;
    // Ekran oranına göre hesaplanmış "distance" değeri.
    private float _calculatedValue;

    #endregion

    #region MonoBehaviour Callbacks

    private void Update()
    {
        ControllInput();
    }

    #endregion

    #region Other Methods

    private void ControllInput()
    {
        if (Input.GetMouseButtonDown(0))
            _firstValue = Input.mousePosition.x;
        else if (Input.GetMouseButton(0))
        {
            _lastValue = Input.mousePosition.x;
            _distance = _lastValue - _firstValue;
            // X'de hareket edildiği için ekran genişliğine göre bir oran veriliyor -> [Screen.width]
            _calculatedValue = (_distance / Screen.width) * _smoothness;

            // Değere göre hareket ediliyor.
            Player.Instance.MoveX(_calculatedValue); 
            
            // İlk nokta son noktanın yerini alıyor. Aksi halde ilk tıkladığımız noktaya göre işlem yapılmaya devam edilir.
            _firstValue = _lastValue;
        }
    }

    #endregion
}
