﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {


	void Start () {
		
	}
	

	void Update ()
    {
        print (CrossPlatformInputManager.GetAxis("Horizontal"));
        print (CrossPlatformInputManager.GetAxis("Vertical"));
    }
}
