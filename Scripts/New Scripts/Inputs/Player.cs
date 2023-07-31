using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables

    // Singleton referansı.
    public static Player Instance;

    // Hareket hızı.
    [SerializeField] private float _moveSpeed;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        // Singleton
        Instance = this;
    }

    #endregion

    #region Other Methods

    public void MoveX(float value)
    {
        // Gelen input değerine göre sağa veya sola hareket yapar.
        // Space.World -> Nesnenin her zamana local eksene göre hareket etmesini sağlar.
        transform.Translate(transform.right * _moveSpeed * value * Time.deltaTime, Space.World);
    }

    public void Swipe(float value)
    {
        // Swipe yönü.
        float _direction;
        if (value > 0)
            _direction = 1;
        else
            _direction = -1;

        // Input değerine göre ile veya geri hareket eder.
        transform.Translate(transform.forward * _direction * _moveSpeed);
    }

    #endregion
}
