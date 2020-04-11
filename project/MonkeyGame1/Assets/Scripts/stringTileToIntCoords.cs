using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class stringTileToIntCoords : MonoBehaviour
{
    public int getXposition(string currentHex)
    {
        string stringOfNumbers, strX;
        int x;

        stringOfNumbers = currentHex.Substring(5);
        List<string> myList = stringOfNumbers.Split('_').ToList();
        strX = myList[0];
        x = int.Parse(strX);

        return x;
    }

    public int getYposition(string currentHex)
    {
        string stringOfNumbers, strY;
        int y;

        stringOfNumbers = currentHex.Substring(5);
        List<string> myList = stringOfNumbers.Split('_').ToList();
        strY = myList[1];
        y = int.Parse(strY);

        return y;
    }
}
