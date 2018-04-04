using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestController : MonoBehaviour
{
    TerrainData td;
    List<TreeInstance> treeInstances;
    List<WoodChopper> woodChoppers;
    [SerializeField] private int[] chopebleIndexes;

    // Use this for initialization
    void Start () {
        td = GetComponent<Terrain>().terrainData;
        
        treeInstances = new List<TreeInstance>(td.treeInstances);
        woodChoppers = new List<WoodChopper>();
        spawnForestColliders();

    }

    void spawnForestColliders()
    {
        for(int i = 0; i < td.treeInstances.Length; i++)
        {
            
            TreePrototype tp = td.treePrototypes[td.treeInstances[i].prototypeIndex];
            Vector3 treePos = new Vector3(td.treeInstances[i].position.x * td.size.x, td.treeInstances[i].position.y * td.size.y, td.treeInstances[i].position.z * td.size.z);
            GameObject gO = new GameObject();
            gO.transform.position = treePos;
            copyCapsuleCollider(gO.AddComponent<CapsuleCollider>(), tp.prefab.GetComponent<CapsuleCollider>());

            gO.transform.parent = gameObject.transform;
            gO.AddComponent<WoodChopper>().index = i;
            woodChoppers.Add(gO.GetComponent<WoodChopper>());
            gO.name = "tree";
        }
    }
    private void copyCapsuleCollider(CapsuleCollider copyTo, CapsuleCollider copyFrom)
    {
        copyTo.radius = copyFrom.radius;
        copyTo.center = copyFrom.center;
        copyTo.height = copyFrom.height;
        copyTo.isTrigger = copyFrom.isTrigger;

    }

    public void RemoveOnIndex(int index)
    {
        TreeInstance tmp = treeInstances[treeInstances.Count - 1];
        WoodChopper tmpWC = woodChoppers[woodChoppers.Count - 1];
        tmpWC.index = index;

        treeInstances[treeInstances.Count - 1] = treeInstances[index];
        woodChoppers[woodChoppers.Count - 1] = woodChoppers[index];

        treeInstances[index] = tmp;
        woodChoppers[index] = tmpWC;

        treeInstances.RemoveAt(treeInstances.Count - 1);
        woodChoppers.RemoveAt(woodChoppers.Count - 1);
        td.treeInstances = treeInstances.ToArray();
        
    }

}
