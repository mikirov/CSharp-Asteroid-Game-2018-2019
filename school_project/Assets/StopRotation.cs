﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRotation : MonoBehaviour {


	void Update () {
        transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
	}
}
