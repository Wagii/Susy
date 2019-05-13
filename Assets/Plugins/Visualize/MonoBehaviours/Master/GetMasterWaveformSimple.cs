using UnityEngine;

/// <summary>
/// This script serves to get the wave form (classic visualisation of the wave)
/// Logic is :
/// Start by validating the existence of your sound source
/// Create the WaveData reader
/// Each frame, read the sound data and set it in 'data'
/// Parse Data from a FFT type to a spectrum type
/// </summary>

public class GetMasterWaveformSimple : DataGetter {

	// Number of slices. In this parameter, you will slice the 20 000 audible frequences in 512 floats
	public new int FFTWindowSize = 512;

	// Check this out if you want to understand : https://en.wikipedia.org/wiki/Window_function
	public new FMOD.DSP_FFT_WINDOW dataType = FMOD.DSP_FFT_WINDOW.RECT;

	// This is the main output of this script
	public new float[][] data = new float[0][];


	private bool canStartVisualize = false;
	private FMOD.DSP fft;

	private Coroutine visualizeUpdate = null;

	protected void Awake() {
		if ((FFTWindowSize != 0) && ((FFTWindowSize & (FFTWindowSize - 1)) == 0)) {
			Debug.LogError("Warning : FFTWindowSize must be a power of Two");
			return;
		}
		WaitForInstanceInitialization();
		this.visualizeUpdate = StartCoroutine(VisualizeUpdate());
	}

	public void ResetInstance() {
		StopCoroutine(visualizeUpdate);
		WaitForInstanceInitialization();
		this.visualizeUpdate = StartCoroutine(VisualizeUpdate());
	}

	private void WaitForInstanceInitialization() {
		FMODGetSpectrum.CreateFFTDSP(this.dataType, FFTWindowSize, out fft);
		StartCoroutine(FMODGetSpectrum.WaitAndVisualizeMaster(fft));
		this.canStartVisualize = true;
	}

	private System.Collections.IEnumerator VisualizeUpdate() {
		while (canStartVisualize != true) yield return null;

		while (true) {
			this.fft.GetParameterData(out data);
			for (int i = 0; i < this.data[0].Length; i++)
				this.data[0][i].LinearToDecibels();
			yield return null;
		}
	}
}
