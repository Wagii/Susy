using UnityEngine;
using UnityEngine.SceneManagement;

namespace Valve.VR {
	public class ResetScene : MonoBehaviour {
		public void Reset(SteamVR_Behaviour_Boolean svrbb, SteamVR_Input_Sources sources, bool b) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
		}
	}
}
