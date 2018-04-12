using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forestControllerExperimental : MonoBehaviour {

    TerrainData td;
    List<TreeInstance> treeinstances;
	// Use this for initialization
	void Start () {
        td = GetComponent<Terrain>().terrainData;
        treeinstances = new List<TreeInstance>( td.treeInstances);
        td.treeInstances = new List<TreeInstance>().ToArray();
        SpawnTrees();
	}

    void SpawnTrees()
    {
        for(int i = 0; i < treeinstances.Count; i++)
        {
            GameObject tp = td.treePrototypes[treeinstances[i].prototypeIndex].prefab;
            Vector3 tmpPos =new Vector3(treeinstances[i].position.x * td.size.x, treeinstances[i].position.y * td.size.y, treeinstances[i].position.z * td.size.z);
            tmpPos += transform.position;
            GameObject tmpTree = Instantiate(tp, tmpPos, Quaternion.identity);
            tmpTree.transform.parent = transform;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnDestroy()
    {
        td.treeInstances = treeinstances.ToArray();
    }
}
