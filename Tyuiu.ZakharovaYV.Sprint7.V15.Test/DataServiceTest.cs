using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tyuiu.ZakharovaYV.Sprint7.V15.Lib;


namespace Tyuiu.ZakharovaYV.Sprint7.V15.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidSumm()
        {
            DataService ds = new DataService();
            string path = @"C:\Users\USER\Desktop\FileTask7.csv";
            int res = ds.Sum(path);
            int wait = 74000;
            Assert.AreEqual(wait, res);
        }

        [TestMethod]
        public void ValidCount()
        {
            DataService ds = new DataService();
            string path = @"C:\Users\USER\Desktop\FileTask7.csv";
            int res = ds.Count(path);
            int wait = 3;
            Assert.AreEqual(wait, res);
        }

        [TestMethod]
        public void ValidSrednee()
        {
            DataService ds = new DataService();
            string path = @"C:\Users\USER\Desktop\FileTask7.csv";
            double res = ds.Srednee(path);
            double wait = 24666.7;
            Assert.AreEqual(wait, res);
        }

        [TestMethod]
        public void ValidMax()
        {
            DataService ds = new DataService();
            string path = @"C:\Users\USER\Desktop\FileTask7.csv";
            double res = ds.Max(path);
            double wait = 40000;
            Assert.AreEqual(wait, res);
        }

        [TestMethod]
        public void ValidMin()
        {
            DataService ds = new DataService();
            string path = @"C:\Users\USER\Desktop\FileTask7.csv";
            double res = ds.Min(path);
            double wait = 14000;
            Assert.AreEqual(wait, res);
        }
    }
}
