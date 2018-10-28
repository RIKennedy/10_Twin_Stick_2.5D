using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {


    private const int bufferFrames = 100;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidBody;

    private GameManager gameManager;


	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
	}
	

	void Update ()
    {
        if (gameManager.recording)
        {
            Record();
        }
        else
        {
            Playback();
        }

    }

    void Playback()
    {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        transform.position = keyFrames[frame].savePosition;
        transform.rotation = keyFrames[frame].saveRotation;
    }

    private void Record()
    {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;

        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}


public struct MyKeyFrame
{
    public float gameTime;
    public Vector3 savePosition;
    public Quaternion saveRotation;

    public MyKeyFrame (float aTime, Vector3 aPosition, Quaternion aRotation)
    {
        gameTime = aTime;
        savePosition = aPosition;
        saveRotation = aRotation;
    }

}