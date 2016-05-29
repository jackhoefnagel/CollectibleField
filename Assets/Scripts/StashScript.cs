using UnityEngine;
using System.Collections;

public class StashScript : MonoBehaviour {

	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			GameManager.instance.PutResourcesInStash();
		}
	}
}
