using UnityEngine;

public class DrunkEffect : MonoBehaviour
{
	public Material material;
	public float warp = 0.02F;
	public float blur = 0.004F;

	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		material.SetFloat("_Warp", warp);
		material.SetFloat("_Blur", blur);
		Graphics.Blit(source, destination, material);
	}
}
