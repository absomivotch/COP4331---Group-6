using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class bandanaTest1 : MonoBehaviour
{
	 public GameObject bandana;
        

        [Test]
        public void bandanaExists()
        {
            //bandana = GameObject.FindGameObjectWithTag("Bandana");
            Assert.IsTrue(bandana.activeInHierarchy);
        }

}
