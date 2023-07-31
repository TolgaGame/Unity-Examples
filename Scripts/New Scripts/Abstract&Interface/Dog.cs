using UnityEngine;

public class Dog : Animal,IRunnable
{
    #region MonoBehaviour Callbacks

    private void Awake()
    {
        animalName = "Dog Jeff";
    }

    #endregion

    #region IRunnable

    // Koşma özelliğini sonradan ekledik.
    public void Run()
    {
        Debug.Log(animalName + " is running");
    }

    #endregion

    #region Animal

    // Farklı tipdeki özellikleri asıl sınıfında doldururuz.
    public override void Talking()
    {
        Debug.Log("Hav Hav");
    }

    #endregion
}
