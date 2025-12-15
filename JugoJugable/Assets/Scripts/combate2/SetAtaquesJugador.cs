using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAtaquesJugador : MonoBehaviour
{
    public CombatUnit unidad;

    public IEnumerator AtaqueFisico(CombatUnit objetivo)
    {
        CombatManager.Instance.MostrarTexto(unidad.nombre + " ataca a " + objetivo.nombre);
        yield return new WaitForSeconds(0.5f);
        int dano = Mathf.Max(unidad.ataque - objetivo.defensa, 1);
        objetivo.RecibirDano(dano);
    }

    public IEnumerator Defensa()
    {
        unidad.defendiendo = true;
        CombatManager.Instance.MostrarTexto(unidad.nombre + " se defiende.");
        yield return new WaitForSeconds(0.5f);
    }
}
