using UnityEngine;

// Bu sınıf tüm hayvanların ortak özelliklerini barındırır.
public abstract class Animal : MonoBehaviour
{
    #region Variables

    public int old;
    public float mass;
    public float speed;
    public string animalName;

    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        Debug.Log(animalName);
    }

    #endregion

    #region Other Methods

    // Her hayvan beslenir.
    public void Feed()
    {
        Debug.Log(animalName + " Feeded");
    }
    
    // Her hayvan uyur.
    public void Sleep()
    {
        Debug.Log(animalName + " is Sleeping");
    }

    #endregion

    #region Abstract Methods

    // Senaryomuzda her hayvan konuşur. Fakat farklı şekillerde konuştuğunu düşünürsek,
    // bu fonksiyonu burada değil de, kalıtım olarak aldığımız script'de yazmalıyız.
    public abstract void Talking();

    #endregion
}
