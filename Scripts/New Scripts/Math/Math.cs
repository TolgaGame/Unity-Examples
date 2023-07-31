using UnityEngine;

public class Math : MonoBehaviour
{
    #region Other Methods

    public void ClampExample(float _speed, float _minSpeed, float _maxSpeed)
    {
        // Hız değerini min ve max değer arasında tutar.
        _speed = Mathf.Clamp(_speed, _minSpeed, _maxSpeed);
    }

    public int GiveSignExample(float _value)
    {
        // _value değeri pozitif veya sıfırsa 1 değerinin verir.
        // Negatif ise -1 değerini verir.
        int _sign = (int)Mathf.Sign(_value);

        return _sign;
    }

    public void AbsExample(float _value)
    {
        // Değerin işaretine bakmaksızın pozitif olarak alır.
        // Mutlak değer.
        float _newValue = Mathf.Abs(_value);
        Debug.Log(_newValue);
    }

    public float PowExample(float _value, int _power)
    {
        // Değerin kuvvetini alır.
        // 2^3 = 8 -> Mathf(2,3) işlemine denk gelir.
        float _calculatedValue = Mathf.Pow(_value, _power);

        return _calculatedValue;
    }

    #endregion
}
