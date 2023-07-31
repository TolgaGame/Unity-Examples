using UnityEngine;

// Eğik atış
public class Launcher : MonoBehaviour
{
    #region Variables

    // Fırlatılacak obje.
    [SerializeField] private Rigidbody _myObject;
    // Fırlatılacak hedef.
    [SerializeField] private Transform _targetPoint;
    // Eğik atışın tepe noktası.
    [SerializeField] private float _h;
    // Yer çekimi
    [SerializeField] private float _gravity;

    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        Launch();
    }

    #endregion

    #region Other Methods

    public void Launch()
    {
        Physics.gravity = Vector3.up * _gravity;
        // Eğik atış formülüne göre objeye kuvvet uygulanır.
        _myObject.velocity = CalculateVelocity();
    }

    // Gerekli kuvvet hesaplanır.
    // Eğik atış formülü.
    private Vector3 CalculateVelocity()
    {
        float displacementY = _targetPoint.position.y - _myObject.position.y;
        Vector3 displacementXZ = new Vector3(_targetPoint.position.x - _myObject.position.x, 0, _targetPoint.position.z - _myObject.position.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * _gravity * _h);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * _h / _gravity) + Mathf.Sqrt(2 * (displacementY - _h) / _gravity));

        return velocityXZ + velocityY;
    }

    #endregion
}
