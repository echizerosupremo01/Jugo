using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUnit : MonoBehaviour
{
    public string nombre;
    public int vida, vidaMaxima, ataque, defensa;
    public bool defendiendo = false;

    public void RecibirDano(int cantidad)
    {
        if (defendiendo)
        {
         cantidad = Math.Max(cantidad / 2,1;
         defendiendo = false;
        }
        vida = Mathf.Max(vida - cantidad, 0);
    }

    public void Curar(int cantidad)
    {
        vida = Mathf.Min(vida + cantidad, vidaMaxima);
    }
}
