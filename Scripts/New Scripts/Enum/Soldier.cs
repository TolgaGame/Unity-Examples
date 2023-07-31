using UnityEngine;

public class Soldier : MonoBehaviour
{
    #region Variables

    // Askerimizin uzmanlık alanını belirledik.
    public SoldierTypes soldierType;

    #endregion

    #region Other Methods

    // Saldırı.
    public void Attack()
    {
        Debug.Log(soldierType + " is attacking.");
    }

    #endregion
}
