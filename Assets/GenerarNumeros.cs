using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GenerarNumeros : MonoBehaviour
{
    [SerializeField] private GameObject Num_0;
    private Vector2 minPantalla,maxPantalla;
    // Start is called before the first frame update
    void Start()
    {
     InvokeRepeating("GenerarNumero",1f,1f);   
     minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
     maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
    }
    private void GenerarNumero() {
        GameObject numero = Instantiate(Num_0);
        numero.transform.position = new Vector2(UnityEngine.Random.Range(minPantalla.x,maxPantalla.x),maxPantalla.y);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
