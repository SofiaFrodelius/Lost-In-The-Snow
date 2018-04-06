using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestController : MonoBehaviour
{
    TerrainData td;
    List<TreeInstance> treeInstances;
    List<TreeInstance> SavedTrees;
    List<TreeController> treeControllers;
    [SerializeField] private bool[] choppeble;
    
    
    // Use this for initialization
    void Start () {
        td = GetComponent<Terrain>().terrainData;
        

        treeInstances = new List<TreeInstance>(td.treeInstances);
        SavedTrees = new List<TreeInstance>(td.treeInstances);
        treeControllers = new List<TreeController>();
        spawnForestColliders();

    }
    

    void spawnForestColliders()
    {
        for(int i = 0; i < td.treeInstances.Length; i++)
        {
            TreeInstance ti = td.treeInstances[i];
            TreePrototype tp = td.treePrototypes[ti.prototypeIndex];
            Vector3 treePos = new Vector3(td.treeInstances[i].position.x * td.size.x + transform.position.x, td.treeInstances[i].position.y * td.size.y + transform.position.y, td.treeInstances[i].position.z * td.size.z + transform.position.z);
            GameObject gO = new GameObject();
            TreeController tc = gO.AddComponent<TreeController>();
            gO.transform.position = treePos;
            copyCapsuleCollider(gO.AddComponent<CapsuleCollider>(), tp.prefab.GetComponent<CapsuleCollider>());

            gO.transform.parent = gameObject.transform;
            tc.Index = i;
            tc.IsChoppeble = choppeble[td.treeInstances[i].prototypeIndex];
            tc.TreeInstance = ti;
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


    //Swappar index med sissta ellementet innan elementet tas bort, 
    //Detta för att bibehålla korrekt index hos alla andra träd
    public void RemoveOnIndex(int index)
    {
        TreeInstance tmp = treeInstances[treeInstances.Count - 1];
        TreeController tmpWC = treeControllers[treeControllers.Count - 1];
        tmpWC.Index = index;

        treeInstances[treeInstances.Count - 1] = treeInstances[index];
        treeControllers[treeControllers.Count - 1] = treeControllers[index];

        treeInstances[index] = tmp;
        treeControllers[index] = tmpWC;

        treeInstances.RemoveAt(treeInstances.Count - 1);
        treeControllers.RemoveAt(treeControllers.Count - 1);
        td.treeInstances = treeInstances.ToArray();
        
    }
    private void OnDestroy()
    {
        td.treeInstances = SavedTrees.ToArray();
    }

}
