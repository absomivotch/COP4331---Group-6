using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridScript : MonoBehaviour
{
    public GameObject hexPrefab;
    public GameObject hexGrid;

    int width = 130;
    int height = 50;
    int x;
    int y;

    float xOffset = 0.855f * 2.0f;
    float zOffset = 1.523f;

    float xPosition;

    public bool gridActive;

    void Start()
    {
       for(x=0; x<width; x++)
        {
            for (y = 0; y < height; y++)
            {
                xPosition = x * xOffset;

                if (y % 2 == 1)
                {
                    xPosition += xOffset / 2.0f;

                }
                hexGrid = (GameObject)Instantiate(
                    hexPrefab,
                    new Vector3(xPosition, 0.2f, y * zOffset),
                    Quaternion.identity
                    );
                hexGrid.name = "Tile_" + x + "_" + y;
                hexGrid.transform.SetParent(this.transform);
                hexGrid.isStatic = true;
            }
        }
        gridActive = true;
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.G)) { 
            if (gridActive == true)
            {
                gameObject.transform.position = new Vector3(0,100,0);
                gridActive = false;
            }
            else
            {
                gameObject.transform.position = new Vector3(0,0,0);
                gridActive = true;
            }
        }
    
        
    }
}
