using UnityEngine;

// Kamera takip.
public class CameraController : MonoBehaviour
{
    #region Variables

    // Takip edilecek obje.
    [SerializeField] private Transform _target;
    // Obje ile kamera arasındaki mesafe.
    [SerializeField] private Vector3 _offset;
    // Takip sırasındaki geçiş yumuşaklığı.
    [SerializeField] [Range(0, 1f)] private float _smoothness;

    #endregion

    #region MonoBehaviour Callbacks

    // Genellikle kamera işlemlerinde "LateUpdate" kullanılır.
    // Fiziksel işlemlerin fazla olduğu oyunlar "LateUpdate" kullanmak titremeye yol açabilir.
    // Bu tarz durumlarda "FixedUpdate" kullanılabilir.
    private void LateUpdate()
    {
        // Kamera pozisyonu
        Vector3 targetPosition = new Vector3(_target.position.x + _offset.x, _target.position.y + _offset.y, _target.position.z + _offset.z);
        // Lerp -> a değeri b değerine belli bir hassasiyet değeriyle yakınlaşır.
        // Slerp -> Dairesel yakınsama olarak düşünülebilir. Kamera gibi mekaniklerde kullanılır.
        transform.position = Vector3.Slerp(transform.position, targetPosition, _smoothness);
        // Her durumda hedef objeye odaklanılmak isteniyorsa "LookAt" metodu kullanılır.
        transform.LookAt(_target);
    }

    // Duruma göre aradaki mesafe değiştirilebilir.
    // Örneğin bitiş çizgisine gelindiğinde farklı açılarda bakılabilir.
    public void ChangeOffset(Vector3 newOffset)
    {
        _offset.x = newOffset.x;
        _offset.y = newOffset.y;
        _offset.z = newOffset.z;
    }

    #endregion
}
