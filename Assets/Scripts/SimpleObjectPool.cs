using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectPool : MonoBehaviour{
	public GameObject prefab;
	private Stack<GameObject> inActiveInstances = new Stack<GameObject> ();

	public GameObject GetObject()
	{
		GameObject spawnedObject;
		if (inActiveInstances.Count > 0)
		{
			spawnedObject = inActiveInstances.Pop ();
		}
		else
		{
			spawnedObject = (GameObject)GameObject.Instantiate (prefab);
			PooledObject pooledObject = spawnedObject.AddComponent<PooledObject> ();
			pooledObject.pool = this;
		}
		spawnedObject.SetActive (true);
		return spawnedObject;
	}
	public void ReturnObject(GameObject toReturn)
	{
		PooledObject pooledObject = toReturn.GetComponent<PooledObject> ();
		if (pooledObject != null && pooledObject.pool == this) {
			toReturn.SetActive (false);
			inActiveInstances.Push (toReturn);
		} else {
			Debug.LogWarning (toReturn.name + "was returned as it was not spawned from the original pool");
			Destroy (toReturn);
		}

	}

}
		public class PooledObject :MonoBehaviour
		{
			public SimpleObjectPool pool;
		}