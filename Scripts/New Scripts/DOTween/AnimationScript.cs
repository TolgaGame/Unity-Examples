using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AnimationScript : MonoBehaviour
{
    #region Variables

    [SerializeField] private Material _myMaterial;
    [SerializeField] private Camera _myCamera;
    [SerializeField] private Image _progressBar;

    #endregion

    #region Other Methods

    // Renk değiştirme.
    public void ChangeColor(Color _targetColor)
    {
        _myMaterial.DOColor(_targetColor, .5f);
    }

    // Kamera titreşimi
    public void ShakeCamera()
    {
        _myCamera.transform.DOShakePosition(.4f, .1f , 15, 90, false, true);
    }

    // Hareket animasyonu.
    public void Move(Vector3 _targetPoint)
    {
        transform.DOMove(_targetPoint, 1f);
    }

    // Trajectory animasyonu.
    public void Jump(Vector3 _jumpTargetPoint)
    {
        transform.DOJump(_jumpTargetPoint, 1, 1, 2, false);
    }

    // Hedef noktaya dönme animasyonu.
    public void LookAt(Vector3 _lookPoint)
    {
        transform.DOLookAt(_lookPoint, 2f);
    }

    // Noktalar dizisinden oluşan bir yolu izleme.
    public void FollowPath(Vector3[] _path)
    {
        transform.DOPath(_path, 10f);
    }

    // Nesne boyutunu değiştirme.
    public void ChangeScale(Vector3 _targetScale)
    {
        transform.DOScale(_targetScale, 2f);
    }

    // Yumuşak bir şekilde barı doldurur.
    public void FillBar(float _targetValue)
    {
        _progressBar.DOFillAmount(_targetValue, .35f);
    }

    #endregion
}
