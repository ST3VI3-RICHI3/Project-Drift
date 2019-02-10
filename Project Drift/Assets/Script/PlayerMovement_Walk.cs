using UnityEngine;

public class PlayerMovement_Walk : MonoBehaviour {

    public float WalkSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * WalkSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * WalkSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.TransformDirection(Vector3.back) * Time.deltaTime * WalkSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.TransformDirection(Vector3.right) * Time.deltaTime * WalkSpeed;
        }
        transform.Rotate(Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"), 0);

	}
}
