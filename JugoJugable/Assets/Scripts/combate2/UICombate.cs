using UnityEngine;
using UnityEngine.UI;

public class UICombate : MonoBehaviour
{
    public CombatUnit jugador1;
    public CombatUnit jugador2;
    public CombatUnit jefe;

    public Slider sliderVidaJugador1;
    public Text textoVidaJugador1;

    public Slider sliderVidaJugador2;
    public Text textoVidaJugador2;

    public Slider sliderVidaJefe;
    public Text textoVidaJefe;

    void Update()
    {
        ActualizarBarra(jugador1, sliderVidaJugador1, textoVidaJugador1);
        ActualizarBarra(jugador2, sliderVidaJugador2, textoVidaJugador2);
        ActualizarBarra(jefe, sliderVidaJefe, textoVidaJefe);
    }

    void ActualizarBarra(CombatUnit unidad, Slider barra, Text texto)
    {
        if (unidad == null || barra == null || texto == null) return;
        barra.maxValue = unidad.vidaMaxima;
        barra.value = unidad.vida;
        texto.text = unidad.vida + " / " + unidad.vidaMaxima;
    }
}