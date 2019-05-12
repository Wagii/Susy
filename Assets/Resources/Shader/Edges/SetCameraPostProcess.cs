using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class SetCameraPostProcess : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        this.GetComponent<Camera>().depthTextureMode = DepthTextureMode.DepthNormals;
    }
    
 
	public Material material;

    void OnRenderImage(RenderTexture src, RenderTexture dest) {
	    Graphics.Blit(src, dest, material);
    }

}
