using System.Collections.Generic;
using UnityEngine;

// AI Path sistemi.
public class Follower : MonoBehaviour
{
    #region Variables

    // Noktalar dizisi.
    [SerializeField] private List<Transform> _path;
    // Karakter hızı.
    [SerializeField] private float _playerSpeed;

    // Takip edilen nokta.
    private Vector3 _currentPoint;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        NextPoint();
    }

    private void Update()
    {
        Run();
        RotationControll();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Hedef noktaya ulaştığımızda, bir sonraki noktayı hedef gösteririz.
        if (other.CompareTag("Point"))
        {
            Destroy(other.gameObject);
            _path.RemoveAt(0);
            // Sonraki nokta.
            NextPoint();
        }
    }

    #endregion

    #region Other Methods

    private void Run()
    {
        transform.Translate(transform.forward * _playerSpeed * Time.deltaTime, Space.World);
    }

    // Sürekli hedefe doğru yönelmek için açı işlemleri yapılır.
    private void RotationControll()
    {
        var lookPos = _currentPoint - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 3f);
    }

    private void NextPoint()
    {
        if (_path.Count > 0)
            _currentPoint = _path[0].position;
    }

    #endregion
}
