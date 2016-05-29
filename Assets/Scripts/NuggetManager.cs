using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NuggetManager : MonoBehaviour {

	public static NuggetManager instance;

	void Awake()
	{
		instance = this;
	}

	public GameObject nuggetPrefab;
	public Gradient nuggetColorValueGradient;
	public float totalNuggetValue = 5.0f;
	public float valueDecreaseSpeed = 2.0f;

	public int nuggetsToSpawn = 50;

	public List<GameObject> nuggetsList;

	void Start()
	{
		SpawnNuggets();
	}

	public void SpawnNuggets()
	{
		nuggetsList = new List<GameObject>();

		for (int i = 0; i < nuggetsToSpawn/2; i++) {
			for (int j = 0; j < nuggetsToSpawn/2; j++) {
				GameObject newNugget = (GameObject)Instantiate(nuggetPrefab);

				float posX = (float)(i / 0.5f) + Random.Range(-0.15f,0.15f);
				float posY = (float)(j / 0.5f) + Random.Range(-0.15f,0.15f);

				newNugget.transform.position = new Vector3(posX,0,posY);

				float perlinX = (float)i/(nuggetsToSpawn/8);
				float perlinY = (float)j/(nuggetsToSpawn/8);

				float valueToAssign = Mathf.PerlinNoise(perlinX,perlinY) * (totalNuggetValue*2);
				NuggetScript newNuggetScript = newNugget.GetComponent<NuggetScript>();
				newNuggetScript.AssignValue(valueToAssign);
				//Debug.Log(valueToAssign);
				newNuggetScript.CheckNuggetValue();

				nuggetsList.Add(newNugget);
			}
		}
	}

	public void DisableNugget(GameObject nuggetToDisable)
	{
		if(nuggetsList.Contains(nuggetToDisable))
		{
			nuggetToDisable.SetActive(false);
		}
	}

}
