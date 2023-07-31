using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Variables

    private Rigidbody _rb;

    #endregion

    #region MonoBehaviour Callbacks

    private void Start() {

        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
    }

    #endregion

    #region Other Methods

    // Topu fırlatma.
    public void Push(Vector3 force) {

		_rb.isKinematic = false;
		_rb.AddForce(_rb.mass * force, ForceMode.Impulse);
	}

    #endregion
}