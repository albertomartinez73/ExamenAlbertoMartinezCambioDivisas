using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ExamenAlbertoMartinezCambioDivisas.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDivisas
{
    [TestClass]
    public class TransactionControllerTest
    {
        TransactionsController Controller = new TransactionsController();

        [TestMethod]
        public async Task PruebaIndexTransaction()
        {
            var resultado = await this.Controller.Index();
            Assert.IsNotNull(resultado);
            Assert.IsTrue(resultado is ActionResult);
        }
    }
}
