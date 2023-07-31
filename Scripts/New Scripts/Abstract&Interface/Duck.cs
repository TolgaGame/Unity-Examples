using UnityEngine;

public class Duck : Animal, IFlyable
{
    #region MonoBehaviour Callbacks

    private void Awake()
    {
        animalName = "Duck Mike";
    }

    #endregion

    #region IFlyable

    // Uçma özelliğini sonradan ekledik.
    public void Fly()
    {
        Debug.Log(animalName + " is flying");
    }

    #endregion

    #region Animal

    // Farklı tipdeki özellikleri asıl sınıfında doldururuz.
    public override void Talking()
    {
        Debug.Log("Vak Vak");
    }

    #endregion
}
