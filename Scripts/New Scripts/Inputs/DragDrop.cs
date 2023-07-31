using UnityEngine;

public class DragDrop : MonoBehaviour
{
    #region Variables

    // X'deki hareket limiti.
    [SerializeField] private Vector2 _xLimits;
    // Y'deki hareket limiti.
    [SerializeField] private Vector2 _yLimits;

    private Camera _myCamera;

    private float _zCoord;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        _myCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        // WorldToScreenPoint -> 3D ortamdaki herhangi bir koordinatın, pixel ekrandaki karşılığını verir.
        _zCoord = _myCamera.WorldToScreenPoint(transform.position).z;
    }

    private void OnMouseDrag()
    {
        Vector3 newPos = GetMouseWorldPos();

        // Hareket alanı Mathf.Clamp ile sınırlanır.
        newPos.x = Mathf.Clamp(newPos.x, _xLimits.x, _xLimits.y);
        newPos.y = Mathf.Clamp(newPos.y, _yLimits.x, _yLimits.y);

        transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
    }


    #endregion

    #region Other Methods

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = _zCoord;
        // ScreenToWorldPoint -> Pixel ekrandaki seçilen pixelin 3D ortamda hangi koordinata geldiğini verir.
        Vector3 pos = _myCamera.ScreenToWorldPoint(mousePoint);

        return pos;
    }

    #endregion
}
