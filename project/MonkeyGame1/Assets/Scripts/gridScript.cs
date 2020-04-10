using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class gridScript : MonoBehaviour
{
    public HexType[] hexTypes;
    public GameObject hexPrefab, hexGrid, selectedCharacter, gameCamera, moveButton, gridObject, selectedHex, selectedHexChild;
    int width = 33, height = 13, x, y;
    int[,] tiles;
    float xPosition, xOffset = 0.855f * 8.0f, zOffset = 1.523f * 4.0f;
    public bool gridActive;
    Node[,] graph;
    public changeGridMaterial changeGridMaterial;
    public int numberOfChosenTiles = 0;


    public enum TerrainType
    {
        Impassable = 0,
        Normal = 1,
        Slow = 2
    }

    float CostToEnterTile(int x, int y)
    {
        HexType ht = hexTypes[tiles[x, y]];
        return ht.movementCost;

    }

    void Start()
    {


        CreateMapTerrain();
        CreateMovementGraph();
        Awake(); // Create Physical hexGrid.
        /*
                 Debug.Log("1");
                //selectedCharacter = GameObject.Find("player1SlotA")
                if(selectedCharacter == null){
                    Debug.Log("selected char is null");
                }
                selectedCharacter.GetComponent<characterPosition>().hexTile_X = (int) selectedCharacter.transform.position.x;
                Debug.Log("2");
                selectedCharacter.GetComponent<characterPosition>().hexTile_Y = (int) selectedCharacter.transform.position.y;
                Debug.Log("3");
                selectedCharacter.GetComponent<characterPosition>().map = this;
                Debug.Log("4"); 
        */
    }

    // Determine the terrainType for all the map tiles. Change for different levels.
    void CreateMapTerrain()
    {
        tiles = new int[width, height];

        for (x = 0; x < width; x++)
        {
            for (y = 0; y < height; y++)
            {
                // Set each tile's terrain for level zero. (there is a big rock that's impassable)
                if (x > 10 && x < 22 && y > 4 && y < 8)
                {
                    tiles[x, y] = (int)TerrainType.Impassable;
                }
                else
                {
                    tiles[x, y] = (int)TerrainType.Normal;
                }
            }
        }
    }

    // Create the hexGrid with its proper componenets, naming scheme, and offset coordinates.
    void Awake()
    {
        for (x = 0; x < width; x++)
        {
            for (y = 0; y < height; y++)
            {
                xPosition = x * xOffset;

                if (y % 2 == 1)
                    xPosition += xOffset / 2.0f;


                hexGrid = (GameObject)Instantiate(hexPrefab, new Vector3(xPosition, 0.8f, y * zOffset), Quaternion.identity);
                hexGrid.name = "Tile_" + x + "_" + y;
                hexGrid.transform.SetParent(this.transform);
                hexGrid.isStatic = true;

                hexGrid.AddComponent<PolygonCollider2D>();
                hexGrid.AddComponent<clickTile>();

                // Relay the shifted coordiantes of the created tiles to the clickTile script.
                clickTile tmp = hexGrid.GetComponent<clickTile>();
                tmp.hexTile_X = x;
                tmp.hexTile_Y = y;
                tmp.map = this;
            }
        }
        gridActive = true;
    }

    void CreateMovementGraph()
    {
        // create array
        graph = new Node[width, height];

        // init a node for each cell in the array
        for (x = 0; x < width; x++)
        {
            for (y = 0; y < height; y++)
            {
                graph[x, y] = new Node();
                graph[x, y].x = x;
                graph[x, y].y = y;
            }
        }

        // calculate each node's neighbours.
        for (x = 0; x < width; x++)
        {
            for (y = 0; y < height; y++)
            {
                // If not at the left side of the map, can add left neighbour, and similar logic.
                if (x != 0)
                {
                    graph[x, y].neighbours.Add(graph[x - 1, y]);
                }
                if (x < width - 1)
                {
                    graph[x, y].neighbours.Add(graph[x + 1, y]);
                }
                if (y != 0)
                {
                    graph[x, y].neighbours.Add(graph[x, y - 1]);
                }
                if (y < height - 1)
                {
                    graph[x, y].neighbours.Add(graph[x, y + 1]);
                }
            }
        }
    }


    public void MoveCurrentCharacter(int x, int y)
    {
        // Determine which character is currently selected.
        playerSelect playerSelect = gameCamera.GetComponent<playerSelect>();
        gridObject = GameObject.Find("GridMap");

        if (playerSelect.currentCharacter == "A")
        {
            selectedCharacter = GameObject.Find("player1SlotA");
            Debug.Log("selected A");
        }
        else if (playerSelect.currentCharacter == "B")
        {
            selectedCharacter = GameObject.Find("player1SlotB");
            Debug.Log("selected B");
        }
        else if (playerSelect.currentCharacter == "C")
        {
            selectedCharacter = GameObject.Find("player1SlotC");
            Debug.Log("selected C");
        }
        else
        {
            selectedCharacter = null;
            numberOfChosenTiles = 0;
            Debug.Log("number of chosen tiles = 0");
        }


        // selectedCharacter.GetComponent<characterPosition>().currentPath = null;

        // If in move mode, then move the player.
        if (moveButton.GetComponentInChildren<Text>().text == "Confirm Move")
        {
            // Highlight selected hex (where the user wants to move).
            if (numberOfChosenTiles < 1)
            {
                changeGridMaterial = GameObject.Find("GameManager").GetComponent<changeGridMaterial>();

                switch(playerSelect.currentCharacter){
                    case "A":
                        changeGridMaterial.exemptHexs[0] = "Tile_" + x + "_" + y + "";
                        break;
                    case "B":
                        changeGridMaterial.exemptHexs[1] = "Tile_" + x + "_" + y + "";
                        break;
                    case "C":
                        changeGridMaterial.exemptHexs[2] = "Tile_" + x + "_" + y + "";
                        break;
                    default:
                        Debug.Log("no selected chacter");
                        break;
                }
                changeGridMaterial.changeHexGreen(x, y);
                           
                numberOfChosenTiles++;
                Debug.Log("number of chosen tiles = 1");
            }



            // to warp!!:
            // selectedCharacter.transform.position = gridObject.transform.Find("Tile_" + x + "_" + y).position;
            /*    
                 // Dijkstra's Algorithm for pathfinding!!
                     Dictionary<Node, float> dist = new Dictionary<Node, float>();
                     Dictionary<Node, Node> prev = new Dictionary<Node, Node>();

                     List<Node> unvisited = new List<Node>();

                     Node source = graph[selectedCharacter.GetComponent<characterPosition>().hexTile_X, selectedCharacter.GetComponent<characterPosition>().hexTile_Y];
                     Node target = graph[x,y];

                     dist[source] = 0;
                     prev[source] = null;

                     foreach(Node vertex in graph)
                     {
                         if(vertex != source){
                             dist[vertex] = Mathf.Infinity;
                             prev[vertex] = null;
                         }
                         unvisited.Add(vertex);
                     }
                     while(unvisited.Count > 0){
                         Node u = null;
                         foreach (Node possibleU in unvisited)
                         {
                             if(u == null || dist[possibleU] < dist[u]){
                                 u = possibleU;
                             }
                         }

                         if(u == target){
                             break;
                         }

                         unvisited.Remove(u);

                         foreach(Node vertex in u.neighbours){
                            float alt = dist[u] + CostToEnterTile(vertex.x, vertex.y);
                             if(alt < dist[vertex]){
                                 dist[vertex] = alt;
                                 prev[vertex]  = u;
                             }
                         }
                     }
                     // if here, shortest route, or no route.
                     if(prev[target] == null){
                         return;
                     }
                     List<Node> currentPath = new List<Node>();
                     Node curr = target;

                     while(curr != null){
                         currentPath.Add(curr);
                         curr = prev[curr];
                     }

                     currentPath.Reverse();

                     selectedCharacter.GetComponent<characterPosition>().currentPath = currentPath;
                 */
        }
    }


    public Vector3 TileCoordToWorldCoord(int x, int y)
    {
        return new Vector3(x * xOffset, 0.8f, y * zOffset);
    }



    void Update()
    {


        if (Input.GetKeyDown(KeyCode.G))
        {
            if (gridActive == true)
            {
                gameObject.transform.position = new Vector3(0, 100, 0);
                gridActive = false;
            }
            else
            {
                gameObject.transform.position = new Vector3(0, 0, 0);
                gridActive = true;
            }
        }


    }
}
