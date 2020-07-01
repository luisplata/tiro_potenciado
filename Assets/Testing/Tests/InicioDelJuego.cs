using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class InicioDelJuego
    {
        GameObject IniciadorDelJuego;
        Iniciar inicio;
        [SetUp]
        public void Setup()
        {
            IniciadorDelJuego = new GameObject();
            IniciadorDelJuego.AddComponent(typeof(Iniciar));
            inicio = IniciadorDelJuego.GetComponent<Iniciar>();
        }
        // A Test behaves as an ordinary method
        [Test]
        public void CuandoNoSePresionaLosDosBotones()
        {
            // Use the Assert class to test conditions
            //Assert.IsFalse(IniciadorDelJuego.PresionaronIzquierdaDerechaAlTiempo(false, true),"Esto debe de fallar");
            Assert.That(inicio.PresionaronIzquierdaDerechaAlTiempo(false, true), Is.False);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator InicioDelJuegoWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(inicio.PresionaronIzquierdaDerechaAlTiempo(true, true));
        }

        [TearDown]
        public void Teardown()
        {
            GameObject.Destroy(IniciadorDelJuego);
        }
    }
}
