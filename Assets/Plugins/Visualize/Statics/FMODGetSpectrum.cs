using UnityEngine;
using FMOD;
using FMODUnity;
using System.Runtime.InteropServices;


// This won't be axplained
public static class FMODGetSpectrum {
	
	public static RESULT CreateFFTDSP(DSP_FFT_WINDOW type, int fftWindowSize, out DSP fft) {
		RESULT res = RESULT.OK;
		res = RuntimeManager.LowlevelSystem.createDSPByType(DSP_TYPE.FFT, out fft);
		if (res != RESULT.OK) return res;
		res = fft.setParameterInt((int)DSP_FFT.WINDOWTYPE, (int)type);
		if (res != RESULT.OK) return res;
		res = fft.setParameterInt((int)DSP_FFT.WINDOWSIZE, fftWindowSize);
		return res;
	}
	
	public static System.Collections.IEnumerator CheckMasterInstantiated(Pointer<bool> ptr) {
		ChannelGroup channelGroup;
		while (RuntimeManager.LowlevelSystem.getMasterChannelGroup(out channelGroup) != RESULT.OK) {
			yield return null;
			ptr.data = false;
		}
		ptr.data = true;
	}
	
	public static RESULT StartVisualizeMaster(DSP dsp) {
		ChannelGroup channelGroup;
		RESULT res;
		res = RuntimeManager.LowlevelSystem.getMasterChannelGroup(out channelGroup);
		if (res != RESULT.OK) return res;
		return channelGroup.addDSP(CHANNELCONTROL_DSP_INDEX.HEAD, dsp);
	}
	
	public static System.Collections.IEnumerator WaitAndVisualizeMaster(DSP dsp) {
		ChannelGroup channelGroup;
		while (RuntimeManager.LowlevelSystem.getMasterChannelGroup(out channelGroup) != RESULT.OK)
			yield return null;
		channelGroup.addDSP(CHANNELCONTROL_DSP_INDEX.HEAD, dsp);
	}
	
	public static System.Collections.IEnumerator CheckEventInstantiated(FMOD.Studio.EventInstance eventInstance, Pointer<bool> ptr) {
		ChannelGroup channelGroup;
		while (eventInstance.getChannelGroup(out channelGroup) != RESULT.OK) {
			ptr.data = false;
			yield return null;
		}
		ptr.data = true;
		yield return null;
	}
	
	public static RESULT StartVisualizeEvent(FMOD.Studio.EventInstance eventInstance, DSP dsp) {
		ChannelGroup channelGroup;
		RESULT res;
		res = eventInstance.getChannelGroup(out channelGroup);
		if (res != RESULT.OK) return res;
		return channelGroup.addDSP(CHANNELCONTROL_DSP_INDEX.HEAD, dsp);
	}
	
	public static System.Collections.IEnumerator WaitAndVisualize(FMOD.Studio.EventInstance eventInstance, DSP fft) {
		ChannelGroup channelGroup;
		while (eventInstance.getChannelGroup(out channelGroup) != RESULT.OK)
			yield return null;
		channelGroup.addDSP(CHANNELCONTROL_DSP_INDEX.HEAD, fft);
	}
	
	public static RESULT GetParameterData (this DSP dsp, out float[][] spectrum) {
		spectrum = new float[0][];
		System.IntPtr intPtr;
		uint length;
		RESULT res = dsp.getParameterData((int)DSP_FFT.SPECTRUMDATA, out intPtr, out length);
		if (res != RESULT.OK) return res;
		DSP_PARAMETER_FFT fftData = (DSP_PARAMETER_FFT)Marshal.PtrToStructure(intPtr, typeof(DSP_PARAMETER_FFT));
		if (fftData.numchannels == 0) return RESULT.ERR_DSP_SILENCE;
		spectrum = fftData.spectrum;
		return res;
	}
	
	public static float LinearToDecibels(this float linear) {
		return linear = Mathf.Clamp(Mathf.Log10(linear) * 20.0f, -80.0f, 0.0f);
	}
}
