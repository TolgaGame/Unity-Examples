using UnityEngine;

public class Raycasting : MonoBehaviour {
    // Algılamak istediğimiz katmanı tanımlıyoruz.
    // Bu layer dışında diğer nesneleri algılamaz ve daha performanslı bir kullanım olur.
    [SerializeField] private LayerMask _mask;

    // Işın referansımız.
    private Ray _ray;
    // Işın çarpışmasının verilerini tutan değişken.
    private RaycastHit _hit;
    private Camera _myCamera;

    private void Awake() {
        _myCamera = Camera.main;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0))
            DetectObject();
    }

    private void DetectObject() {
        // Pixel ekrandan 3D ortama ışın yollar.
        // Mouse ile seçilen pixelden ortama ray atar.
        _ray = _myCamera.ScreenPointToRay(Input.mousePosition);

        // Eğer ışın katmanındaki bir objeye çarpıyorsa koşul sağlanır.
        if (Physics.Raycast(_ray, out _hit, 100, _mask))
            Debug.Log(_hit.transform.name);
    }
}