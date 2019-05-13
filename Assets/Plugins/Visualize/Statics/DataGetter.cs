using UnityEngine;

public abstract class DataGetter : MonoBehaviour {	
	// Number of slices. In this parameter, you will slice the 20 000 audible frequences in 512 floats
	public int FFTWindowSize = 512;

	// Check this out if you want to understand : https://en.wikipedia.org/wiki/Window_function
	public FMOD.DSP_FFT_WINDOW dataType = FMOD.DSP_FFT_WINDOW.RECT;

	// This is the main output of this script
	public float[][] data = new float[0][];
}
