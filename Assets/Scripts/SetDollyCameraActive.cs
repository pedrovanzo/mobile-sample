using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDollyCameraActive : MonoBehaviour
{
    public GameObject cameraASerAtivada;

	public GameObject finalLight;

    // Start is called before the first frame update
    void Start()
    {
        //tentar entender porque essa linha ta dando erro
        cameraASerAtivada = GameObject.Find("CM vcam2").GetComponent<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        cameraASerAtivada.SetActive(true);
		finalLight.SetActive(true);
    }
}
