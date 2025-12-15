using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAtaquesJefe : MonoBehaviour {
    public CombatUnit jefe;
    public CombatUnit[] jugadores;

    int curacionesRestantes = 2;
    int turnosDesdeUltimaCura = 99;
    bool seCuroUltimoTurno = false;

    public IEnumerator AtaqueSimple(CombatUnit objetivo) {
        CombatManager.Instance.MostrarTexto(jefe.nombre + " ataca a " + objetivo.nombre);
        yield return new WaitForSeconds(0.5f);
        int dano = Mathf.Max(jefe.ataque - objetivo.defensa, 1);
        objetivo.RecibirDano(dano);
    }

    public IEnumerator Curarse() {
        CombatManager.Instance.MostrarTexto(jefe.nombre + " se cura.");
        yield return new WaitForSeconds(0.5f);
        int cantidad = Mathf.FloorToInt(jefe.vidaMaxima * 0.12f);
        jefe.Curar(cantidad);

        curacionesRestantes--;
        seCuroUltimoTurno = true;
        turnoDesdeUltimaCura = 0;
    }
}
