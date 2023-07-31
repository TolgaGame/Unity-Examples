using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    #region Variables

    // Singleton
    public static RankManager Instance;

    // Oyuncuların mesafeye göre sıralanmış hali.
    public List<Racer> rankedPlayers;
    // Bitiş çizgisi.
    public Transform finishPoint;

    // Oyuncular.
    [SerializeField] private Racer[] _racers;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        Instance = this;
        rankedPlayers = _racers.ToList();
    }

    private void Update()
    {
        CalculateRanking();
    }

    #endregion

    #region Other Methods

    private void CalculateRanking()
    {
        for (int i = 0; i < _racers.Length; i++)
            _racers[i].CalculateDistance();

        // "distance" değerine göre oyuncuların sıralanması.
        // Örneğin: "Racer" scriptinde "healh" diye bir değişken olsaydı.
        // "x=> x.health" yazarak can değerleri azdan çoğa doğru sıralanırdı.
        // "OrderByDescending" metodu ile çoktan aza doğru sıralanır.
        rankedPlayers = rankedPlayers.OrderBy(x => x.distance).ToList();
    }

    #endregion
}
