using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BotonIniciarJuego : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void IrAlJuego(){
        SceneManager.LoadScene("PantallaJuego");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
