using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CadeMeuTroco.Core;
using CadeMeuTroco.Core.DataContracts;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CadeMeuTrocoTeste.CadeMeuTroco.Core {

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CadeMeuTrocoManagerTest {

        [TestMethod]
        public void CalculateEntities_GetChangeWithCoinsOnly_Test() {

            CadeMeuTrocoManager manager = new CadeMeuTrocoManager();

            IEnumerable<ChangeData> result = manager.CalculateEntities(170);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 1);

            ChangeData changeData = result.ElementAt(0);

            Assert.IsTrue("Coin".Equals(changeData.Name, StringComparison.InvariantCultureIgnoreCase) == true);

            Assert.IsTrue(changeData.ChangeDictionary.Count == 3);

            Assert.IsTrue(changeData.ChangeDictionary.ContainsKey(100) == true);
            Assert.IsTrue(changeData.ChangeDictionary.ContainsKey(50) == true);
            Assert.IsTrue(changeData.ChangeDictionary.ContainsKey(10) == true);

            Assert.AreEqual(1, changeData.ChangeDictionary[100]);
            Assert.AreEqual(1, changeData.ChangeDictionary[50]);
            Assert.AreEqual(2, changeData.ChangeDictionary[10]);
        }

        [TestMethod]
        public void CalculateEntities_GetEmptyChangeDataCollection_Test() {
   
            CadeMeuTrocoManager manager = new CadeMeuTrocoManager();
            IEnumerable<ChangeData> result = manager.CalculateEntities(0);
            
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 0);
        }
    }
}
