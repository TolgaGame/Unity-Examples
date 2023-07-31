using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    #region Variables

    // Kontrol edilecek obje.
    [SerializeField] private Transform _target;
    // Swipe hassasiyeti.
    [SerializeField] private float _smoothness;

    // İlk nokta.
    private float _firstValue;
    // Son Nokta.
    private float _lastValue;
    // İki nokta arasındaki mesafe.
    private float _distance;
    // Belli bir matematiğe göre hesaplanmış input değeri.
    private float _calculatedValue;

    #endregion

    #region MonoBehaviour Callbacks

    private void Update()
    {
        SwipeControll();
    }

    #endregion

    #region Other Methods

    private void SwipeControll()
    {
        if (Input.GetMouseButtonDown(0))
            _firstValue = Input.mousePosition.y;
        else if (Input.GetMouseButton(0))
        {
            _lastValue = Input.mousePosition.y;
            _distance = _lastValue - _firstValue;
            // Yukarıya göre bir Swipe hareketi olduğu için.[Screen.height]
            // Her ekranda aynı hassasiyet olması için bu matematik kullanılır.
            _calculatedValue = (_distance / Screen.height);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Dokunmayı bıraktıktan sonra eğer ki hareket için gerekli hassasiyeti sağladıysak hareket başlar.
            if (Mathf.Abs(_calculatedValue) >= _smoothness)
            {
                Player.Instance.Swipe(_distance);
                // Hareket bittiği için değer sıfırlanır.
                _firstValue = _lastValue;
            }
        }
    }

    #endregion
}
