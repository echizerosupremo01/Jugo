using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class botonInteractivo : MonoBehaviour
{
    public GameObject puerta;
    public GameObject[] casillasBloqueadas;
    public GameObject iconoInteractivo;
    public KeyCode tecla = KeyCode.E;
    public float ejeZ = -0.1f;

    private bool jugadorCerca = false;
    private bool activado = false;
    private Vector3 posicionInicial;
    private AudioSource audioSource;

    public AudioClip sonidoBoton;
    public AudioClip sonidoPuerta;


    void Start()
    {
        posicionInicial = transform.localPosition;
        audioSource = GetComponent<AudioSource>();

        if (iconoInteractivo != null)
            iconoInteractivo.SetActive(false);

        foreach (var casilla in casillasBloqueadas)
            casilla.SetActive(false);


    }

    void Update()
    {
        if (jugadorCerca && !activado)
        {
            if (iconoInteractivo != null)
            {
                iconoInteractivo.SetActive(true);
            }
            if (Input.GetKeyDown(tecla))
            {
                ActivarBoton();
            }
        }
        else
        {
            if (iconoInteractivo != null)
                iconoInteractivo.SetActive(false);
        }
    }

    public void ActivarBoton()
    {
        if (activado) return;
        {
            activado = true;
        }
        transform.localPosition += new Vector3(0, 0, ejeZ);
        if (audioSource != null && sonidoBoton != null)
        {
            audioSource.PlayOneShot(sonidoBoton);
        }
        if (sonidoPuerta != null && puerta != null)
        {
            AudioSource.PlayClipAtPoint(sonidoPuerta, puerta.transform.position);
        }
        if (puerta != null)
        {
            puerta.SetActive(false);
        }
        foreach (var casilla in casillasBloqueadas)
        {
            casilla.SetActive(true);
        }
        if (iconoInteractivo != null)
        {
            iconoInteractivo.SetActive(false);


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !activado)
        {
            jugadorCerca = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") && !activado)
        {
            jugadorCerca = false;
            if(iconoInteractivo != null)
            {
                iconoInteractivo.SetActive(false);
            }
        }
    }
}
