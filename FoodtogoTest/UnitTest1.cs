using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;

namespace FoodtogoTest
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            string hello = "Hello";
            string world = "world!";
            //Act
            string result = hello + " " + world;
            //Assert
            Assert.AreEqual("Hello world!", result);
        }
    }
}