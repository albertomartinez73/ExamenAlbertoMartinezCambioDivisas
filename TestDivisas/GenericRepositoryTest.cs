using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenAlbertoMartinezCambioDivisas.Models;
using ExamenAlbertoMartinezCambioDivisas.Services.Repository.RatesRepository;

namespace TestDivisas
{
    [TestClass]
    public class GenericRepositoryTest
    {
        [TestMethod]
        public async Task InsertCorrecto()
        {
            var rate = new Rates{From = "EUR", To = "USD", Rate = 1.359m};
            var repositorio =  new RatesRepository();

            repositorio.Insert(rate);
            await repositorio.Save();

            var rateGuardado = await repositorio.GetById(rate.Id);
            Assert.IsNotNull(rateGuardado);
            Assert.AreEqual(rate, rateGuardado);
            await repositorio.Delete(rate.Id);
            await repositorio.Save();

        }

        [TestMethod]
        public async Task DeleteCorrecto()
        {
            var rate = new Rates { From = "EUR", To = "USD", Rate = 1.359m };
            var repositorio = new RatesRepository();

            repositorio.Insert(rate);
            await repositorio.Delete(rate.Id);
            await repositorio.Save();


            var rateGuardado = await repositorio.GetById(rate.Id);
            Assert.IsNull(rateGuardado);

        }
    }
}
