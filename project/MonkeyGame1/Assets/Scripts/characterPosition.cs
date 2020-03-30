using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterPosition : MonoBehaviour
{
  public int hexTile_X, hexTile_Y;
  public gridScript map;

  public List<Node> currentPath = null;

    void Update(){
        if(currentPath != null){
            int curr = 0;

            while(curr < currentPath.Count - 1){
                Vector3 start = map.TileCoordToWorldCoord(currentPath[curr].x, currentPath[curr].y);
                Vector3 end = map.TileCoordToWorldCoord(currentPath[curr+1].x, currentPath[curr+1].y );
                
                Debug.DrawLine(start, end, Color.yellow);

                curr++;
            }
        }
    }
}
