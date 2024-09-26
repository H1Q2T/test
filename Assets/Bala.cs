using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private float _vel;
    private Boolean BulletMoving = false;
    private Vector2 maxPantalla;
    // Start is called before the first frame update
    void Start()
    {
     _vel = 20;
     maxPantalla = Camera.main.ViewportToWorldPoint(new UnityEngine.Vector2(1,1));
    }

    // Update is called once per frame
    void Update()
    {
        //Boolean Espacio = Input.GetKey(KeyCode.Space);
        //if (Espacio) {
            //BulletMoving = true;
        //}

        //if (BulletMoving) {
            UnityEngine.Vector2 PosActual = transform.position;
            PosActual += new UnityEngine.Vector2(0,1) * _vel * Time.deltaTime;
            transform.position = PosActual;  
        //}
        //Debug.Log(Espacio +" , "+BulletMoving + " , ");

        if (transform.position.y > maxPantalla.y) {
            Destroy(gameObject);
        }
    }
}
