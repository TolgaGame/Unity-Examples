using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    #region Veriables

    // Nesne havuzunda depolanacak obje.
    [SerializeField] private GameObject _prefab;
    // Havuz kapasitesi.
    [SerializeField] private int _poolSize;

    // Havuz.
    private List<GameObject> _objectPool;

    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        InitPool();
    }

    #endregion

    #region Private Methods

    // Havuz boyutu kadar obje oluşturulur ve depoya aktarılır.
    private void InitPool()
    {
        _objectPool = new List<GameObject>();
        for (int i = 0; i < _poolSize; i++)
        {
            // Depoya eklenir.
            _objectPool.Add(Instantiate(_prefab, transform));
            _objectPool[i].SetActive(false);
        }
    }

    // "Instantiate" metodu kullanmak yerine depodan tekrar tekrar objeler çekilir.
    public GameObject GetObjFromPool(Vector3 pos, Quaternion rot)
    {
        // Listenin sonundan eleman tutulur.
        GameObject newObject = _objectPool[_objectPool.Count - 1];
        newObject.SetActive(true);
        // Parametre olarak verilen değerlere göre pozisyon ve açı eşitlenir.
        newObject.transform.position = pos;
        newObject.transform.rotation = rot;
        // Obje kullanılmak üzere listeden çıkarılır ki nesne sahnedeyken tekrar çağırılmasın.
        _objectPool.RemoveAt(_objectPool.Count - 1);
        return newObject;
    }

    // "Destroy" kullanmak yerine obje kullanıldıktan sonra depoya atılır.
    public void ReturnObjToPool(GameObject go)
    {
        go.SetActive(false);
        go.transform.position = transform.position;
        go.transform.rotation = transform.rotation;
        // Tekrar kullanılmak üzere depoya geri eklenir.
        _objectPool.Add(go);
    }

    #endregion
}
