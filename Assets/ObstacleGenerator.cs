using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {

	public List<GameObject> obstacles;

	private GameObject objectFolder;

	private float previousCamLoc = 0;
	private float currCamLoc = 0;

	public int obstacleTimeUnits = 20;

	// Use this for initialization
	void Start () {
		objectFolder = GameObject.Find("Objects");
	}
	
	public void GenObstacle(float offset)
	{
		int type = UnityEngine.Random.Range(0, obstacles.Count);
		GenObstacle(offset, type);
	}

	public void GenObstacle(float offset, int type)
	{
		Debug.Assert(type > 0 && type <= obstacles.Count);

		GameObject obsObj = Instantiate<GameObject>(obstacles[type]);
		Vector3 obsTrans = obsObj.transform.position;
		obsObj.transform.position = new Vector3(offset + 90, obsTrans.y, obsTrans.z);
		obsObj.transform.SetParent(objectFolder.transform);
	}

	// Update is called once per frame
	void Update () {
		currCamLoc = Camera.main.gameObject.transform.position.x;
		if(currCamLoc - previousCamLoc > obstacleTimeUnits)
		{
			GenObstacle(currCamLoc);

			previousCamLoc = currCamLoc;
		}
	}
}
