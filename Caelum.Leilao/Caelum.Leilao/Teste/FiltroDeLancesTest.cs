using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Caelum.Leilao.Teste
{
    [TestFixture]
    public class FiltroDeLancesTest
    {
        [Test]
        public void DeveSelecionarLancesMaioresQue5000()
        {
            Usuario joao = new Usuario("Joao");

            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
        new Lance(joao,10000), 
        new Lance(joao, 800)});

            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(10000, resultado[0].Valor, 0.00001);
        }

        [Test]
        public void DeveEliminarMenoresQue500()
        {
            Usuario joao = new Usuario("Joao");

            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
        new Lance(joao,400), 
        new Lance(joao, 300)});

            Assert.AreEqual(0, resultado.Count);
        }

        [Test]
        public void DeveEliminarEntre3000E5000()
        {
            Usuario joao = new Usuario("Joao");

            FiltroDeLances filtro = new FiltroDeLances();
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
        new Lance(joao,4000), 
        new Lance(joao, 3500)});

            Assert.AreEqual(0, resultado.Count);
        }
    }
}
