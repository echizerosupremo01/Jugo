using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    public CombatUnit[] jugadores;
    public CombatUnit jefe;
    public GameObject panelAcciones;
    public Text textoAccion;

    private int indiceSeleccion = 0;
    private AccionSeleccionada[] accionesPendientes;

    private void Awake()
    {
        Instance = this;
        accionesPendientes = new AccionSeleccionada[jugadores.Length];
    }

    private void Start()
    {
        IniciarCombate();
    }

    public void IniciarCombate()
    {
        StartCoroutine(FlujoCombate());
    }

    IEnumerator FlujoCombate()
    {
        while (jefe.vida > 0 && HayJugadoresVivos())
        {
            accionesPendientes = new AccionSeleccionada[jugadores.Length];
            indiceSeleccion = 0;
            panelAcciones.SetActive(true);
            MostrarTexto(jugadores[indiceSeleccion].nombre + ", elige tu accion.");

            yield return new WaitUntil(() => accionesPendientes[jugadores.Length - 1] != null);

            foreach (AccionSeleccionada accion in accionesPendientes)
            {
                yield return EjecutarAccionJugador(accion);
            }

            if (jefe.vida <= 0) break;

            yield return EjecutarAccionJefe();
        }

        MostrarTexto(HayJugadoresVivos() ? "�Victoria!" : "Derrota...");
    }

    public void SeleccionarAtaque()
    {
        if (jugadores == null || jugadores.Length == 0 || jefe == null || accionesPendientes == null)
        {
            Debug.LogError("Faltan referencias en SeleccionarAtaque");
            return;
        }

        if (indiceSeleccion >= jugadores.Length)
        {
            Debug.LogError("Índice fuera de rango en jugadores: " + indiceSeleccion);
            return;
        }
        accionesPendientes[indiceSeleccion] = new AccionSeleccionada
        {
            unidad = jugadores[indiceSeleccion],
            objetivo = jefe,
            tipo = TipoAccion.Ataque
        };
        AvanzarSeleccion();
    }

    public void SeleccionarDefensa()
    {
        accionesPendientes[indiceSeleccion] = new AccionSeleccionada
        {
            unidad = jugadores[indiceSeleccion],
            tipo = TipoAccion.Defensa
        };
        AvanzarSeleccion();
    }

    void AvanzarSeleccion()
    {
        indiceSeleccion++;
        if (indiceSeleccion < jugadores.Length)
        {
            MostrarTexto(jugadores[indiceSeleccion].nombre + ", elige tu accion.");
        }
        else
        {
            panelAcciones.SetActive(false);
        }
    }

    IEnumerator EjecutarAccionJugador(AccionSeleccionada accion)
    {
        var set = accion.unidad.GetComponent<SetAtaquesJugador>();
        if (accion.tipo == TipoAccion.Ataque)
            yield return set.AtaqueFisico(accion.objetivo);
        else
            yield return set.Defensa();
    }

    IEnumerator EjecutarAccionJefe()
    {
        var set = jefe.GetComponent<SetAtaquesJefe>();
        CombatUnit objetivo = jugadores[Random.Range(0, jugadores.Length)];
        while (objetivo.vida <= 0)
            objetivo = jugadores[Random.Range(0, jugadores.Length)];

        if (jefe.vida < jefe.vidaMaxima / 2)
            yield return set.Curarse();
        else
            yield return set.AtaqueSimple(objetivo);
    }

    bool HayJugadoresVivos()
    {
        foreach (var j in jugadores)
            if (j.vida > 0) return true;
        return false;
    }

    public void MostrarTexto(string mensaje)
    {
        textoAccion.text = mensaje;
    }
}

public enum TipoAccion { Ataque, Defensa }

public class AccionSeleccionada
{
    public CombatUnit unidad;
    public CombatUnit objetivo;
    public TipoAccion tipo;
}