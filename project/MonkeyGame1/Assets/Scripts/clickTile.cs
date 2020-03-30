using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickTile : MonoBehaviour
{
   public int hexTile_X, hexTile_Y;
   public gridScript map;

   void OnMouseUp(){
       map.MoveCurrentCharacter(hexTile_X, hexTile_Y);
       Debug.Log("clicked at " + hexTile_X + ", " + hexTile_Y);
   }
}
