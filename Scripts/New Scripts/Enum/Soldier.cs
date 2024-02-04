using UnityEngine;

public class Soldier : MonoBehaviour {
    // Askerimizin uzmanlık alanını belirledik.
    public SoldierTypes soldierType;

    // Saldırı.
    public void Attack() {
        Debug.Log(soldierType + " is attacking.");
    }
}