using UnityEngine;

// Trajectroy sürükleme.
public class Swipe : MonoBehaviour 
{
    #region Variables

    [SerializeField] private Ball ballPrefab;		
	[SerializeField] private Trajectory trajectory;
	[SerializeField] private float pushForce;			
	[SerializeField] private float maxForce;			
	[SerializeField] [Range(0f, 10f)] private float zMultiplier;																	
	
	private Vector2 _startPos, _endPos;
	private Vector3 _forcevector;		
	private Ball _ball;
	private Camera _myCamera;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
		_myCamera = Camera.main;
    }

    private void Start() {

		Spawn();
	}

	private void Update() {

		ControlSwipe();
	}

    #endregion

    #region Other Methods

    private void ControlSwipe()
	{
		if (Input.GetMouseButtonDown(0))
		{
			trajectory.SetDotsVisible(true);	
			_startPos = _myCamera.ScreenToViewportPoint(Input.mousePosition);
		}

        if (Input.GetMouseButton(0))
		{
			_endPos = _myCamera.ScreenToViewportPoint(Input.mousePosition);	
			Vector3 direction = (_startPos - _endPos).normalized;
			float distance = Vector2.Distance(_startPos, _endPos);
			_forcevector = direction * distance * pushForce;
			_forcevector.z = _forcevector.y * zMultiplier;
			_forcevector = Vector3.ClampMagnitude(_forcevector, maxForce);
			trajectory.UpdateDots(transform.position, _forcevector);
		}

		if (Input.GetMouseButtonUp(0)) {

			if (_ball) {
				_ball.Push(_forcevector);
				_ball = null;

				Invoke("Spawn", 1);
			}
			trajectory.SetDotsVisible(false);
		}
	}

	public void Spawn()
	{
		_ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
	}

    #endregion
}
