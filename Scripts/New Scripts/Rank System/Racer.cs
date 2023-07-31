using UnityEngine;

public class Racer : MonoBehaviour
{
    #region Variables

    // Bitiş çizgisine olan uzaklık.
    [HideInInspector] public float distance;

    #endregion

    #region Other Methods

    // Mesafe hesaplanması.
    public void CalculateDistance()
    {
        distance = Vector3.Distance(transform.position, RankManager.Instance.finishPoint.position);
    }

    #endregion
}
