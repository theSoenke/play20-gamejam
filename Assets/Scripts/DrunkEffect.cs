using System.Collections;
using UnityEngine;

public class DrunkEffect : MonoBehaviour
{
	private float _startWarp;
	private float _startBlur;
	private float _startBlurMin;

	public Material material;
	public float Warp = 0.02F;
	public float Blur = 0.004F;
	public float TimeScale = 1f;
	public float BlurMin = 0f;

	public AnimationCurve DrunkLevelWeight;
	public float DrunkLevelScale = 60;

    void Awake()
    {
        _startWarp = Warp;
		_startBlur = Blur;
		_startBlurMin = BlurMin;

		Warp = 0;
		Blur = 0;
		BlurMin = 0;
    }

    void Update()
    {
        if(GameStateManager.Instance != null)
        {
			var time = GameStateManager.Instance.State.Drunk / DrunkLevelScale;
			var weight = DrunkLevelWeight.Evaluate(time);
			Warp = _startWarp * weight;
			Blur = _startBlur * weight;
			BlurMin = _startBlurMin * weight;
        }
    }


    void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		material.SetFloat("_Warp", Warp);
		material.SetFloat("_Blur", Blur);
		material.SetFloat("_TimeScale", TimeScale);
		material.SetFloat("_BlurMin", BlurMin);
		Graphics.Blit(source, destination, material);
	}
}
