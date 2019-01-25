using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpawn : MonoBehaviour
{

    //New Addition (Random Spawner), Anhar's OOP

    public Terrain terrain;

    private int TerrainWidth; //terrian size (X)
    private int TerrainLength; //terrain size (Z)

    private int terrainPosX;
    private int terrainPosZ;
    public GameObject ObjectToPlace;

    

    

    public int numberSpawned;

    public int maxSpawn = 10;
   
    // Start is called before the first frame update
    void Start()
    {
       TerrainWidth = (int)terrain.terrainData.size.x;
       TerrainLength = (int)terrain.terrainData.size.z;

       terrainPosX = (int)terrain.transform.position.x;
       terrainPosZ = (int)terrain.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

        
       //if the number of spawned objects is less than the max spawned...
        if (numberSpawned < maxSpawn) {
                int posx = Random.Range(terrainPosX, terrainPosX + TerrainWidth);
                int posz = Random.Range(terrainPosZ, terrainPosZ + TerrainLength);

                float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));

                GameObject newZombie = Instantiate(ObjectToPlace, new Vector3(posx, posy, posz), Quaternion.identity);
                if(newZombie.GetComponent<Health>())
                {
                newZombie.GetComponent<Health>().randomSpawnScript = this;
                }
                print("spawn");
                

                numberSpawned++;

               
        }
    }
}
