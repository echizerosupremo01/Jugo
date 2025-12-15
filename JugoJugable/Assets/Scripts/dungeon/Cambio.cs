using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class Cambio : MonoBehaviour
{
    public Transform destino;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 nuevaPosicion = new Vector3(
                destino.position.x,
                other.transform.position.y, 
                destino.position.z
            );

            other.transform.position = nuevaPosicion;
        }
    }


}
