using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class playerMovementTest
    {
        [Test]
        public void MovesAlongX_Axis()
        {
            Assert.AreEqual(-1, new Movement(1).Calculate(1, 0, 1).x, 0.1f);
        }

        [Test]
        public void MovesAlongZ_Axis()
        {
            Assert.AreEqual(-1, new Movement(1).Calculate(0, 1, 1).z, 0.1f);
        }
    }
}
