using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestController : MonoBehaviour
{
    TerrainData td;
    List<TreeInstance> treeInstances;
    List<TreeController> treeControllers;
    [SerializeField] private bool[] choppeble;

    // Use this for initialization
    void Start () {
        td = GetComponent<Terrain>().terrainData;
        
        treeInstances = new List<TreeInstance>(td.treeInstances);
        treeControllers = new List<TreeController>();
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
            gO.AddComponent<TreeController>().index = i;
            gO.GetComponent<TreeController>().choppeble = choppeble[td.treeInstances[i].prototypeIndex];
            treeControllers.Add(gO.GetComponent<TreeController>());
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
        TreeController tmpWC = treeControllers[treeControllers.Count - 1];
        tmpWC.index = index;

        treeInstances[treeInstances.Count - 1] = treeInstances[index];
        treeControllers[treeControllers.Count - 1] = treeControllers[index];

        treeInstances[index] = tmp;
        treeControllers[index] = tmpWC;

        treeInstances.RemoveAt(treeInstances.Count - 1);
        treeControllers.RemoveAt(treeControllers.Count - 1);
        td.treeInstances = treeInstances.ToArray();
        
    }

}
