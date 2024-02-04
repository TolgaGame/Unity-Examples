using UnityEngine;

public class Racer : MonoBehaviour {
    // Bitiş çizgisine olan uzaklık.
    [HideInInspector] public float distance;

    // Mesafe hesaplanması.
    public void CalculateDistance() {
        distance = Vector3.Distance(transform.position, RankManager.Instance.finishPoint.position);
    }

}