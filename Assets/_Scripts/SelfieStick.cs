using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfieStick : MonoBehaviour {


    public float panSpeed = 5f;

    private Vector3 armRotation;
    private GameObject player;


    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        armRotation = transform.rotation.eulerAngles;
    }
	

	void Update ()
    {
        armRotation.y += Input.GetAxis("RHoriz") * panSpeed;
        armRotation.x += Input.GetAxis("RVert") * panSpeed;

        transform.rotation = Quaternion.Euler(armRotation);
        transform.position = player.transform.position;
	}
}
