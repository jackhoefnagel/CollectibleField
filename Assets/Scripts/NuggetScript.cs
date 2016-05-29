using UnityEngine;
//using System.Collections;

public class NuggetScript : MonoBehaviour {

	public GameObject nuggetGraphicsGO;
	public MeshRenderer nuggetGraphics;

	public float nuggetValue = 5.0f;
	public float totalNuggetValue;
	private float valueDecreaseSpeed = GameManager.instance.resourcesGatherSpeed;

	void Awake()
	{
		totalNuggetValue = NuggetManager.instance.totalNuggetValue;
		CheckNuggetValue();
	}


	void Update()
	{
		nuggetGraphicsGO.transform.LookAt(Camera.main.transform);
	}

	void OnTriggerStay(Collider coll)
	{

		GameManager.instance.ChangePlayerDrag(nuggetValue);

		if(GameManager.instance.playerCanGatherResources)
		{
			if(nuggetValue > 0.1f)
			{
				nuggetValue -= Time.deltaTime * valueDecreaseSpeed;
				GameManager.instance.AddResources();
				//transform.position = Vector3.Lerp(transform.position, coll.gameObject.transform.position, Time.deltaTime);
			}
			else
			{
				//this.gameObject.SetActive(false);
				//NuggetManager.instance.DisableNugget(this.gameObject);
			}

			CheckNuggetValue();
		}
	}

	public void CheckNuggetValue()
	{
		nuggetGraphics.material.SetColor("_TintColor",NuggetManager.instance.nuggetColorValueGradient.Evaluate(nuggetValue/totalNuggetValue));
		gameObject.transform.localScale = Vector3.one * (0.25f + nuggetValue/totalNuggetValue) * 3;
	}


	public void AssignValue(float nuggetValueToAssign)
	{
		nuggetValue = nuggetValueToAssign;
	}
}
