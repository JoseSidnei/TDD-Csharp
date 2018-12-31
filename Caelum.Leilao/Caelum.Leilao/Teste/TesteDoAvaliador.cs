using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    public class TesteDoAvaliador
    {
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            // 1a parte: cenario
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 4 Novo");

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            //2a parte: acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // 3a parte: validacao
            double maiorEsperado = 400;
            double menorEsperado = 250;

            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance);
        }

        [Test]
        public void DeveEntenderLeilaoCOmApenasUmLance()
        {
            Usuario joao = new Usuario("Joao");
            Leilao leilao = new Leilao("Playstation 4 novo");

            leilao.Propoe(new Lance(joao, 1000.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(1000, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(1000, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 4 novo");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(maria, 400.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(400, maiores[0].Valor, 0.0001);
            Assert.AreEqual(300, maiores[1].Valor, 0.0001);
            Assert.AreEqual(200, maiores[2].Valor, 0.0001);
        }

        [Test]
        public void DeveEntenderLeilaoComApenasUmLance()
        {
            Usuario joao = new Usuario("Joao");
            Leilao leilao = new Leilao("Playstation 4 Novo");

            leilao.Propoe(new Lance(joao, 200.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(200, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(200, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void DeveEntenderLeilaoEmOrdemRandomica()
        {
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 4 Novo");

            leilao.Propoe(new Lance(joao, 200.0));
            leilao.Propoe(new Lance(maria, 450));
            leilao.Propoe(new Lance(joao, 120.0));
            leilao.Propoe(new Lance(maria, 700.0));
            leilao.Propoe(new Lance(joao, 630.0));
            leilao.Propoe(new Lance(maria, 230));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(700.0, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(120.0, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void DeveEmtemderLeilaoEmOrdemDecrescente()
        {
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 4 Novo");

            leilao.Propoe(new Lance(joao, 400.0));
            leilao.Propoe(new Lance(maria, 300.0));
            leilao.Propoe(new Lance(joao, 200.0));
            leilao.Propoe(new Lance(maria, 100.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(400.0, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(100.0, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void DeveEntenderOsTresMaioresLances()
        {
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Xbox X Novo");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(maria, 400.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(400.0, maiores[0].Valor, 0.00001);
            Assert.AreEqual(300.0, maiores[1].Valor, 0.00001);
            Assert.AreEqual(200.0, maiores[2].Valor, 0.00001);
        }
        
        [Test]
        public void DeveDevolverTodosLancesCasoNaoHajaNoMinimo3()
        {
            Usuario joao = new Usuario("Joao");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Xbox X Novo");

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(maria, 200.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(2, maiores.Count);
            Assert.AreEqual(200, maiores[0].Valor, 0.00001);
            Assert.AreEqual(100, maiores[1].Valor, 0.00001);
        }

        [Test]
        public void DeveDevolverListaVaziaCasoNaoHajaLances()
        {
            Leilao leilao = new Leilao("Xbox X Novo");

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(0, maiores.Count);
        }        
    }
}
