using UnityEngine;

public class Trajectory : MonoBehaviour
{
    #region Variables

	// Noktaların oluştuğu obje
    [SerializeField] private Transform dotsParent;	
	// Nokta objesi.
	[SerializeField] private Transform dotPrefab;	
	// Nişangah.
	[SerializeField] private Transform target;	
	// Nokta sayısı.
	[SerializeField] private int dotsNumber;
	// Nokta aralığı.
	[SerializeField] private float dotSpacing;		
	// Minimum nokta büyüklüğü.
	[SerializeField] [Range(0.01f, 0.5f)] private float dotMinScale;
	// Maximum nokta büyüklüğü.
	[SerializeField] [Range(0.50f, 1.0f)] private float dotMaxScale;

	// Noktalar listesi.
	private Transform[] _dotsList;
	private Camera _myCamera;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
		_myCamera = Camera.main;
	}

    private void Start()
	{
		PrepareDots();
	}

    #endregion

    #region Other Methods

	// Noktaları oluşturma.
    private void PrepareDots() 
	{
		SetDotsVisible(false);
		_dotsList = new Transform[dotsNumber];
		dotPrefab.localScale = Vector3.one * dotMaxScale;

		float scale = dotMaxScale;
		float scaleFactor = scale / dotsNumber;

		for (int i = 0; i < dotsNumber; i++) {
			_dotsList[i] = Instantiate(dotPrefab, null);
			_dotsList[i].parent = dotsParent.transform;
			_dotsList[i].gameObject.SetActive(true);

			_dotsList[i].localScale = Vector3.one * scale;
			if (scale > dotMinScale)
				scale -= scaleFactor;
		}
	}

	// Nokta pozisyonlarını güncelleme.
	public void UpdateDots(Vector3 ballPos, Vector3 forceApplied) 
	{
		float timeStamp = dotSpacing;
		bool hideDot = false;
		foreach (Transform dot in _dotsList) {
			Vector3 dotPos;
			dotPos.x = (ballPos.x + forceApplied.x * timeStamp);
			dotPos.y = (ballPos.y + forceApplied.y * timeStamp) - (Physics.gravity.magnitude * timeStamp * timeStamp) / 2f;
			dotPos.z = (ballPos.z + forceApplied.z * timeStamp);
			
			dot.position = dotPos;
			dot.LookAt(_myCamera.transform);
			if (!hideDot && CheckGround(dotPos)) {
				hideDot = true;
			}
			dot.gameObject.SetActive(!hideDot);
			
			timeStamp += dotSpacing;
		}
		target.gameObject.SetActive(hideDot);
	}

	// Zemin Teması.
	private bool CheckGround(Vector3 sphereCenter) 
	{
		Collider[] coll = Physics.OverlapSphere(sphereCenter, 1f);
		if (coll.Length > 0 && coll[0].transform.tag == "Ground") {
			Vector3 pos = sphereCenter;
			pos.y = coll[0].transform.position.y + coll[0].bounds.size.y / 2 + 0.01f;
			target.position = pos;
			return true;
		}
		return false;
	}

	public void SetDotsVisible(bool _show)
    {
		dotsParent.gameObject.SetActive(_show);
	}

    #endregion
}