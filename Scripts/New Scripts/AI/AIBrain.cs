using UnityEngine;

public class AIBrain : MonoBehaviour
{
    #region Variables

    // AI'ın zorluk derecesi 
    [SerializeField] [Range(1, 100)] private int _AIHardness;

    // Örnek olarak seçilmiş iki nokta.
    private Transform _truePoint;
    private Transform _wrongPoint;

    #endregion

    #region Other Methods

    // Bu fonksiyon her çagırıldığında AI'ın zekasına göre doğru veya yanlış değer döndürür.
    // Bu doğru ve yanlış çıktılarına göre AI'ın senaryosun yönetilebilir.
    // Örneğin "true" çıktısı ile basket atabilir, "false" çıktısı ile dışarıya atması sağlanır.
    private bool GetRate()
    {
        bool _isSuccess = false;
        int _randomNumber = Random.Range(1, 101);

        // Örnek olarak AI %90 zeki bir bot olsun.
        // Matematiksel olarak 1 ve 100 dahil olmak üzere arasından bir sayı seçersek.
        // Bu rastgele sayının 90 dan küçük olma olasılığı %90'dır. Dolayısıyla AI %90 doğru sonuç verir.
        if (_AIHardness >= _randomNumber)
            _isSuccess = true;

        return _isSuccess;
    }

    private void Move()
    {
        Vector3 _movePosition;
        // Eğer fonksiyon AI'ın yüzdesine göre "true" çıktısını verirse. AI doğru yere gider.
        if (GetRate())
            _movePosition = _truePoint.position;
        // "false" çıktısı gelirse AI yanlış yere gider.
        else
            _movePosition = _wrongPoint.position;

        transform.position = _movePosition;
    }

    #endregion
}
