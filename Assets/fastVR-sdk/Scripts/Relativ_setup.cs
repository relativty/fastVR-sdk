using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relativ_setup {

	public string portName;

	public int baudRate;

	public int ReadTimeout;

	public string getPort() {
		return "COM3";
	}

	public int getBaudRate() {
		return 1;
	}

	public int getTimeout() {
		return 20;
	}

	void Start () {

	}

}
