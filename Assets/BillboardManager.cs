using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Terrain))]
public class BillboardManager : MonoBehaviour
{
    TreeInstance[] trees;
    // Start is called before the first frame update
    void Start()
    {
        var terrain = GetComponent<Terrain>();
        trees = GetComponent<Terrain>().terrainData.treeInstances;
        Debug.Log(trees.Length);
        for (int i = 0; i < trees.Length; i++)
        {
            var tempInstance = trees[i];
            terrain.terrainData.SetTreeInstance(i, tempInstance);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
