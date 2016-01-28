using UnityEngine;
using System.Collections;

public class CubeRotate : MonoBehaviour {

    public float speed = 90;

	void Update () {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
	}

    public void ChangeSpeed(float currentSpeed)
    {
        this.speed = currentSpeed;
    }
}
