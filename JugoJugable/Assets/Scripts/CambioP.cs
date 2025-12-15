using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioP : MonoBehaviour
{
    public GameObject hongito, bicho;
    int switchCharaIsOn = 1;
    void Start()
    {
        hongito.gameObject.SetActive(true);
        bicho.gameObject.SetActive(false);
    }

    public void SwitchChara()
    {
        switch (switchCharaIsOn)
        {
            case 1:
                switchCharaIsOn=2;
                hongito.gameObject.SetActive(false);
                bicho.gameObject.SetActive(true);
                break;
            case 2:
                switchCharaIsOn=1;
                hongito.gameObject.SetActive(true);
                bicho.gameObject.SetActive(false);
                break;
        }
    }
}
