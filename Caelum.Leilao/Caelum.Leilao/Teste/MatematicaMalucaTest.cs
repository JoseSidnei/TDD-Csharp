using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    public class MatematicaMalucaTest
    {
        [Test]
        public void DeveMultiplicarNumerosMaioresQue30()
        {
            MatematicaMaluca matematica = new MatematicaMaluca();
            Assert.AreEqual(50 * 4, matematica.ContaMaluca(50));
        }

        [Test]
        public void DeveMultiplicarNumerosMaioresQue10EMenoresQue30()
        {
            MatematicaMaluca matematica = new MatematicaMaluca();
            Assert.AreEqual(20 * 3, matematica.ContaMaluca(20));
        }

        [Test]
        public void DeveMultiplicarNumerosMenoresQue10()
        {
            MatematicaMaluca matematica = new MatematicaMaluca();
            Assert.AreEqual(5 * 2, matematica.ContaMaluca(5));
        }
    }
}
