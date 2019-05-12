using UnityEngine;
using System.Collections.Generic;

public class LightScript : MonoBehaviour
{

    private static readonly int fresnelPowerID = Shader.PropertyToID(name: "_FresnelPower");
    private static readonly int lightPowerID = Shader.PropertyToID(name: "_LightPower");

	[SerializeField] private AnimationCurve _light = null, fresnel = null;

	[SerializeField] private float lightValue = 0, fresnelValue = 5;

    protected void Update()
    {
	    this.lightValue = this._light.Evaluate(Manager.player.velocity.magnitude);
	    this.fresnelValue = this.fresnel.Evaluate((this.transform.position - Manager.player.position).magnitude);
	    this.GetComponent<Renderer>().material.SetFloat(lightPowerID, lightValue);
	    this.GetComponent<Renderer>().material.SetFloat(fresnelPowerID, fresnelValue);
    }
}



//private static readonly int mainTextureID = Shader.PropertyToID(name: "_MainTexture");
//private static readonly int shaderColorID = Shader.PropertyToID(name: "_MainTex_Albedo");
//private static readonly int fresnelColorID = Shader.PropertyToID(name:"_FresnelColor");

//[SerializeField] private Texture2D mainTex;
//[ColorUsage(false, true)] [SerializeField] private Color albedoColor, fresnelColor;

//[SerializeField] private Texture2D mainTex;
//[ColorUsage(false, true)] [SerializeField] private Color albedoColor, fresnelColor;
//[SerializeField] private AnimationCurve light, fresnel;
//private float lightValue = 0, fresnelValue = 5;


//protected void OnValidate() {
//	List<Material> mats = new List<Material>();
//	this.GetComponent<Renderer>().GetMaterials(mats);
//	Material mat = mats[0];
//	mat.SetTexture(nameID:mainTextureID, value:mainTex);
//	mat.SetColor(nameID:shaderColorID, value:albedoColor);
//	mat.SetColor(nameID:fresnelColorID, value:fresnelColor);
//	mat.SetFloat(nameID:fresnelPowerID, value:fresnelValue);
//	mat.SetFloat(nameID:lightPowerID, value:lightValue);
//	mat = null;
//	mats = null;
//}