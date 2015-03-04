using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CadeMeuTroco.Core;
using CadeMeuTroco.Core.DataContracts;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CadeMeuTroco.Core.Util;
using CadeMeuTrocoTeste.CadeMeuTroco.Core.Mocks;

namespace CadeMeuTrocoTeste.CadeMeuTroco.Core {

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CadeMeuTrocoManagerTest {

        [TestMethod]
        public void CalculateEntities_GetChangeWithCoinsOnly_Test() {
            
            CadeMeuTrocoManager manager = new CadeMeuTrocoManager();

            PrivateObject privateObject = new PrivateObject(manager);
            object objResult = privateObject.Invoke("CalculateEntities", Convert.ToInt64(170));

            IEnumerable<ChangeData> result = (IEnumerable<ChangeData>)objResult;

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

            PrivateObject privateObject = new PrivateObject(manager);
            object objResult = privateObject.Invoke("CalculateEntities", Convert.ToInt64(0));

            IEnumerable<ChangeData> result = (IEnumerable<ChangeData>)objResult;
            
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 0);
        }

        [TestMethod]
        public void Calculate_GetChangeDataWithCoinsOnly_Test() {

            ConfigurationUtilityMock configurationUtility = new ConfigurationUtilityMock();
            configurationUtility.LogPath = @"C:\Logs\Test";

            CadeMeuTrocoManager manager = new CadeMeuTrocoManager(configurationUtility);

            CalculateRequest request = new CalculateRequest();

            request.ProductAmountInCents = 100;
            request.PaidAmountInCents = 140;

            CalculateResponse response = manager.Calculate(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Success == true);
            Assert.IsTrue(response.ChangeAmount == 40);
            Assert.IsTrue(response.ChangeCollection.Count() == 1);

            ChangeData changeData = response.ChangeCollection.First();

            Assert.IsTrue(changeData.Name == "Coin");
            Assert.IsTrue(changeData.ChangeDictionary.Count() == 3);
            Assert.IsTrue(changeData.ChangeDictionary.ContainsKey(25) == true);
            Assert.IsTrue(changeData.ChangeDictionary.ContainsKey(10) == true);
            Assert.IsTrue(changeData.ChangeDictionary.ContainsKey(5) == true);
            Assert.AreEqual(1, changeData.ChangeDictionary[25]);
            Assert.AreEqual(1, changeData.ChangeDictionary[10]);
            Assert.AreEqual(1, changeData.ChangeDictionary[5]);


        }

    }
}
