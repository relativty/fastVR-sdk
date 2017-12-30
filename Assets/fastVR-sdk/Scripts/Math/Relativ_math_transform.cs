using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Relativ_math_transform {

	public static float[] getEuler(float w,float x,float y,float z) {
		float g1 = (2 * (x * z - w * y));
		float g2 = 2 * (w * x + y * z);
		float g3 = w * w - x * x - y * y + z * z;

		return new float[]{Mathf.Atan (g1 / Mathf.Sqrt (g2 * g2 + g3 * g3))*180.0f/Mathf.PI, Mathf.Atan2 (2 * x * z - 2 * w * z, 2 * w * w + 2 * x * x - 1)*180.0f/Mathf.PI, Mathf.Atan (g2 / Mathf.Sqrt (g1 * g1 + g3 * g3))*180.0f/Mathf.PI} ;
	}

}
