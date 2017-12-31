// Copyright 2017 Relativty. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relativ_player : MonoBehaviour {

	wrmhl Relativ_headset = new wrmhl(); // wrmhl is the bridge beetwen your computer and hardware.

	[Tooltip("SerialPort of Relativ.")]
	public string portName = "COM8";

	[Tooltip("Baudrate")]
	public int baudRate = 250000;


	[Tooltip("Timeout")]
	public int ReadTimeout = 20;

	string[] sep = new string[] {","};

	string data;

	void Start () {
		Relativ_headset.set (portName, baudRate, ReadTimeout, 1); // This method set the communication with the following vars;
		//                              Serial Port, Baud Rates and Read Timeout.
		Relativ_headset.connect (); // This method open the Serial communication with the vars previously given.
	}

	// Update is called once per frame
	void Update () {
		data = Relativ_headset.readQueue (); // myDevice.read() return the data coming from the device using thread.

		string[] values = data.Split (sep, System.StringSplitOptions.RemoveEmptyEntries);

		float w = float.Parse (values[3]);
		float x = float.Parse (values[0]);
		float y = float.Parse (values[1]);
		float z = float.Parse (values[2]);
		float[] EulerAngles = Relativ_math_transform.getEuler(w, x, y, z);

		transform.localEulerAngles = new Vector3 (EulerAngles[0],EulerAngles[1],EulerAngles[2]);

	}

	void OnApplicationQuit() { // close the Thread and Serial Port
		Relativ_headset.close();
	}
}
