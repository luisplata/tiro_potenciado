using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTest
    {
        GameObject player;
        MovimientoPlayer movimientoPlayer;

        [SetUp]
        public void Setup()
        {
            player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Jugador"));
            movimientoPlayer = player.GetComponent<MovimientoPlayer>();
        }
        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator ElPlayerSePuedeMoverConLasFlechas()
        {
            movimientoPlayer.speed = 1;
            yield return new WaitForSeconds(0.1f);
            // Use the Assert class to test conditions
            Assert.That(movimientoPlayer.ParaMoverElJugador(1,1),Is.EqualTo(Vector2.right),"Debe retornar 1");
        }

        [UnityTest]
        public IEnumerator VerificarQueColisionoConAlgunObjeto()
        {
            movimientoPlayer.estaEnContactoConAlgo = false;
            yield return new WaitForSeconds(0.1f);
            movimientoPlayer.ColisionConCosas("CualquierCosa");
            Assert.That(movimientoPlayer.estaEnContactoConAlgo, Is.True, "no implementado");
        }

        [UnityTest]
        public IEnumerator VerificarQueColisionoConAlgunObjetoPeroEsElLimite()
        {
            movimientoPlayer.estaEnContactoConAlgo = false;
            yield return new WaitForSeconds(0.1f);
            movimientoPlayer.ColisionConCosas("limites");
            Assert.That(movimientoPlayer.estaEnContactoConAlgo, Is.False, "no implementado");
        }


        [UnityTest]
        public IEnumerator VerificarQueSalgaDeLaColisionoConAlgunObjeto()
        {
            movimientoPlayer.estaEnContactoConAlgo = true;
            movimientoPlayer.SalioDeLaColisionConCosas("limites");
            yield return new WaitForSeconds(0.1f);
            Assert.That(movimientoPlayer.estaEnContactoConAlgo, Is.True, "no implementado");
        }

        [UnityTest]
        public IEnumerator VerificarQueSalgaDeLaSiColisionaConLosLimitesNoPaseNada()
        {
            movimientoPlayer.estaEnContactoConAlgo = true;
            movimientoPlayer.SalioDeLaColisionConCosas("CualquierCosa");
            yield return new WaitForSeconds(0.1f);
            Assert.That(movimientoPlayer.estaEnContactoConAlgo, Is.False, "no implementado");
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
    }
}
