using UnityEngine;

public class Ball : MonoBehaviour {
    private Rigidbody _rigidbody;

    private void Start() {

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }
    // Topu fırlatma.
    public void Push(Vector3 force) {

        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(_rigidbody.mass * force, ForceMode.Impulse);
    }


}