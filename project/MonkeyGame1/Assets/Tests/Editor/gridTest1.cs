using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    
    public class gridTest1
    {
        public GameObject grid;
        

        [Test]
        public void GridExists()
        {
            grid = GameObject.FindGameObjectWithTag("Grid");
            Assert.IsTrue(grid.activeInHierarchy);
        }



        [Test]
        public void GridAt0()
        {
            grid = GameObject.FindGameObjectWithTag("Grid");
            bool gridOn = grid.GetComponent<gridScript>().gridActive;
            if (gridOn == true)
            { 
                Assert.AreEqual(grid.transform.position, (0, 0, 0));
            }
            else
            {
                Assert.AreNotEqual(grid.transform.position, (0, 0, 0));
            }
        }
     
    }
}
