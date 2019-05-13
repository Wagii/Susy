using UnityEngine;

/// <summary>
/// This script serves to get the wave Data (volume per frequence)
/// Logic is :
/// Start by validating the existence of your sound source
/// Create the WaveData reader
/// Each frame, read the sound data and set it in 'data'
/// data is located in DataGetter
/// </summary>

public class GetMasterWaveDataSimple : DataGetter {
	private bool canStartVisualize = false;
	private FMOD.DSP fft;

	private Coroutine visualizeUpdate = null;

	protected void Awake() {
		if ((FFTWindowSize != 0) && ((FFTWindowSize & (FFTWindowSize - 1)) != 0)) {
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
			yield return null;
		}
	}
}
