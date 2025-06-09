using NUnit.Framework;
using Cooperativa.Retiros;
using System;

namespace Cooperativa.Tests.Retiros
{
    public class CuentaAhorrosServiceTest
    {
        private CuentaAhorrosService _cuentaService;

        [SetUp]
        public void Setup()
        {
            _cuentaService = new CuentaAhorrosService();
        }

        [Test]
        public void TC1()
        {
            var cuenta = _cuentaService.ValidarRetiro(true, 1000, 3000, false, 500);
            Assert.IsTrue(cuenta);
        }

        [TestCase(false, 1000, 3000, false, 500)]
        [TestCase(true, 1000, 3000, false, 5000)]
        [TestCase(true, 1000, 800, false, 900)]
        [TestCase(true, 1000, 3000, true, 500)]
        [TestCase(true, 1000, 3000, false, 504)]
        public void CasosInvalidos_RetornanFalse(bool activa, decimal saldo, decimal limiteDiario, bool bloqueada, decimal monto)
        {
            var resultado = _cuentaService.ValidarRetiro(activa, saldo, limiteDiario, bloqueada, monto);
            Assert.IsFalse(resultado);
        }
    }
}