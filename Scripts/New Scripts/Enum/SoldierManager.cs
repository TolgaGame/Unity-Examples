using UnityEngine;

public class SoldierManager : MonoBehaviour
{
    #region Variables

    // Saldırı için seçilmiş olan asker tipi.
    private SoldierTypes _selectedSoldiersType;
    // Tüm askerlerin bulunduğu dizi.
    private Soldier[] _soldiers;

    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        // FindObjectsOfType<Soldier>() -> Sahnedeki tüm "Soldier" scriptlerine ulaşır.
        // Ulaştıktan sonra dizimize eşitledik.
        _soldiers = FindObjectsOfType<Soldier>();
    }

    #endregion

    #region Other Methods

    // Seçtiğimiz asker tiplerine saldırı emri verdik.
    public void AttackOrder()
    {
        for (int i = 0; i < _soldiers.Length; i++)
        {
            if (_soldiers[i].soldierType == _selectedSoldiersType)
                _soldiers[i].Attack();
        }
    }

    // Duruma göre saldırıya sokacağımız asker tiplerini bu fonksiyonla değiştirebiliriz.
    public void SetSelectedType(SoldierTypes _type)
    {
        _selectedSoldiersType = _type;
    }

    #endregion
}
