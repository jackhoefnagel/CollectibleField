using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	void Awake()
	{
		instance = this;
	}

	public float currentPlayerResources = 0.0f;
	public float maxPlayerResources = 50.0f;
	public float resourcesGatherSpeed = 1.0f;

	public float stashResources = 0.0f;

	public bool playerCanGatherResources = true;

	public GameObject playerObject;
	public float playerDrag = 0.0f;
	public float playerCurrentSpeed = 0.0f;

	public SmoothFollow cameraFollowScript;
	public float minCamDistance = 10.0f;
	public float maxCamDistance = 30.0f;

	private MeshRenderer playerMeshRenderer;

	public Image ResourcesIndicator;
	public Image StashIndicator;



	void Start()
	{
		playerMeshRenderer = playerObject.GetComponent<MeshRenderer>();
	}

	public void AddResources()
	{
		if(currentPlayerResources < maxPlayerResources)
		{
			currentPlayerResources += resourcesGatherSpeed;
		}
		else
		{
			playerCanGatherResources = false;
		}
	}

	public void PutResourcesInStash()
	{
		stashResources += currentPlayerResources;
		currentPlayerResources = 0.0f;
		playerCanGatherResources = true;

		StashIndicator.fillAmount += 0.1f; // ?
	}

	void Update()
	{
		ResourcesIndicator.fillAmount = currentPlayerResources / maxPlayerResources;

		if(playerDrag > 0.0f)
		{
			playerDrag -= Time.deltaTime * 5.0f;
		}
	}

	public void ChangePlayerSpeed(float newPlayerSpeed)
	{
		Debug.Log(playerCurrentSpeed);
		playerCurrentSpeed = newPlayerSpeed;
		cameraFollowScript.distance = cameraFollowScript.height = Mathf.Lerp(cameraFollowScript.distance, Mathf.Clamp(playerCurrentSpeed, minCamDistance, maxCamDistance), Time.deltaTime);
	}

	public void ChangePlayerDrag(float newDragValue)
	{
		if(newDragValue > playerDrag)
		{
			playerDrag = newDragValue;
		}
	}
}
