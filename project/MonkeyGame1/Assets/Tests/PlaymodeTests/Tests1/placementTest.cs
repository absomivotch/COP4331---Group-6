using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class placementTest
    {
        private GameObject test_Level0Map, test_Teams, test_player1Team, testMonkey;
        private GameObject test_GridMap, test_tile1, test_tile2;
        private gridPlacement gridPlace;

        [Test]
        public void placementTestSimplePasses()
        {
            test_Level0Map = test_Teams = test_player1Team = testMonkey = GameObject.Instantiate(new GameObject());
            test_GridMap = test_tile1 = test_tile2 = GameObject.Instantiate(new GameObject());

            test_Level0Map.name = "Level0Map";
            test_Teams.name = "Teams";
            test_player1Team.name = "player1Team";
            testMonkey.name = "player1SlotA";
            test_GridMap.name = "GridMap";
            test_tile1.name = "Tile_0_0";
            test_tile2.name = "Tile_5_9";

            testMonkey.transform.parent = test_player1Team.transform;
            test_player1Team.transform.parent = test_Teams.transform;
            test_Teams.transform.parent = test_Level0Map.transform;

            test_tile1.transform.parent = test_GridMap.transform;
            test_tile2.transform.parent = test_GridMap.transform;

            gridPlace = test_GridMap.AddComponent<gridPlacement>();
            Assert.AreEqual(testMonkey.transform.position.x, test_tile2.transform.position.x);

        }


    }
}