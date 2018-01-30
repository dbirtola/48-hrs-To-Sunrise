using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class NavmeshRebuiltEvent : UnityEvent
{

}

public class TerrainMorpher : MonoBehaviour {

    public NavmeshRebuiltEvent navmeshRebuiltEvent;

    Terrain terrain;
    TerrainData terrainData;
    float[,] originalHeights;



	// Use this for initialization
	void Awake () {
        navmeshRebuiltEvent = new NavmeshRebuiltEvent();
        terrain = GetComponent<Terrain>();
        terrainData = terrain.terrainData;
        originalHeights = terrainData.GetHeights(0, 0, terrainData.heightmapWidth, terrainData.heightmapHeight);
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnMouseDrag()
    {
        Vector3 clickedPos = Vector3.zero;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (terrain.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
        {
            clickedPos = hit.point;
        }

        SetHeight(clickedPos, -0.03f);
    }

    void OnMouseUp()
    {
        NavMeshSurface surf = GetComponent<NavMeshSurface>();
        surf.BuildNavMesh();

        /*
        List<NavMeshBuildSource> sources = new List<NavMeshBuildSource>();
        List<NavMeshBuildMarkup> markups = new List<NavMeshBuildMarkup>();
        NavMeshBuilder.CollectSources(surf.navMeshData.sourceBounds, LayerMask.GetMask("Default"), surf.useGeometry, surf.defaultArea, markups, sources);
        NavMeshBuilder.UpdateNavMeshData(surf.navMeshData, surf.GetBuildSettings(), sources, surf.navMeshData.sourceBounds);
        */
        navmeshRebuiltEvent.Invoke();
    }

    void SetHeight(Vector3 location, float height)
    {
        int radius = 4;
        float[,] t = new float[2*radius, 2*radius];
        for(int i = 0; i < 2*radius; i++)
        {
            for(int j = 0; j < 2*radius; j++)
            {
                t[i, j] = height;
            }
        }
        terrainData.SetHeights((int)location.x, (int)location.z, t);

    }

    void OnMouseDown()
    {


        Debug.Log("Clicked!");



        /*
        for(int f = 0; f < temp.Length; f++)
        {
            for(int j = 0; j < temp.Length; j++)
            {
                Debug.Log(temp[f,j]);
            }
        }*/
    }

    void OnDestroy()
    {

        terrainData.SetHeights(0, 0, originalHeights);
    }
}
