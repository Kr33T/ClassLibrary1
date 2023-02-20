using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //низкая сложность
        [TestMethod]
        public void CheckVIN_correctLength_false()
        {
            string vin = "1";
            Assert.IsFalse(Class1.CheckVIN(vin));
        }
        
        [TestMethod]
        public void CheckVIN_correctLength_true()
        {
            string vin = "12345678912345678";
            Assert.IsFalse(Class1.CheckVIN(vin));
        }

        [TestMethod]
        public void CheckVIN_correctLetters_true()
        {
            string vin = "ASVKLDWLETJKDBCRT";
            Assert.IsTrue(Class1.CheckVIN(vin));
        }

        [TestMethod]
        public void CheckVIN_correctLetters_false()
        {
            string vin = "ASVKLDWIOQavbmfgd";
            Assert.IsFalse(Class1.CheckVIN(vin));
        }

        [TestMethod]
        public void GetVINCountry_correctCountry_true()
        {
            string vin = "A2V8L2W2OQ1KD5CRT";
            string except = "Африка";
            string actual = Class1.GetVINCountry(vin);
            Assert.AreEqual(except, actual);
        }

        [TestMethod]
        public void GetVINCountry_returnedBoolVar_true()
        {
            string vin = "A2V8L2W2OQ1KD5CRT";
            Assert.IsInstanceOfType(Class1.CheckVIN(vin), typeof(bool));
        }

        [TestMethod]
        public void GetVINCountry_correctCountry_false()
        {
            string vin = "Z2V8L2W2OQ1KD5CRT";
            string except = "Северная Америка";
            string actual = Class1.GetVINCountry(vin);
            Assert.AreNotEqual(except, actual);
        }

        [TestMethod]
        public void GetVINCountry_returnedStringVar_true()
        {
            string vin = "Z2V8L2W2OQ1KD5CRT";
            Assert.IsInstanceOfType(Class1.GetVINCountry(vin), typeof(string));
        }

        [TestMethod]
        public void GetVINCountry_returnedNullVar_true()
        {
            string vin = "-2V8L2W2OQ1KD5CRT";
            Assert.IsNull(Class1.GetVINCountry(vin));
        }

        [TestMethod]
        public void GetVINCountry_returnedStringVar_false()
        {
            string vin = null;
            Assert.IsNotInstanceOfType(Class1.GetVINCountry(vin), typeof(string));
        }

        //высокая сложность
        
        [TestMethod]
        public void CheckVIN_nullValue()
        {
            string vin = null;
            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<SystemException>(() => Class1.CheckVIN(vin)));
        }

        [TestMethod]
        public void GetVINCountry_nullValue()
        {
            string vin = null;
            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<SystemException>(() => Class1.GetVINCountry(vin)));
        }

        [TestMethod]
        public void CheckVIN_incorrectSymbols()
        {
            string vin = "-2V8L2W2OQ1KD5CRT";
            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<SystemException>(() => Class1.CheckVIN(vin)));
        }

        [TestMethod]
        public void GetVINCountry_incorrectSymbols()
        {
            string vin = "-2V8L2W2OQ1K/5CRT";
            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<SystemException>(() => Class1.GetVINCountry(vin)));
        }

        [TestMethod]
        public void GetVINCountry_incorrectSymbol()
        {
            string vin = "-";
            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<SystemException>(() => Class1.GetVINCountry(vin)));
        }
    }
}