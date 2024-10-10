using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class NuevoJugador : MonoBehaviour
{
    private float _vel;
    private int vidas;
    private UnityEngine.Vector2 minPantalla;
    private UnityEngine.Vector2 maxPantalla;

    [SerializeField]
    private GameObject prefabprojectile;
    [SerializeField]
    private GameObject prefabexplo;
    [SerializeField]
    private TMPro.TextMeshProUGUI TextoVidas;

    // Start is called before the first frame update
    void Start()
    { 
       _vel = 30;
       vidas = 3;
       minPantalla = Camera.main.ViewportToWorldPoint(new UnityEngine.Vector2(0,0));
       maxPantalla = Camera.main.ViewportToWorldPoint(new UnityEngine.Vector2(1,1));

        float MidaMitadImagenX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float MidaMitadImagenY = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.x / 2;

       minPantalla.x += MidaMitadImagenX;
       minPantalla.y += MidaMitadImagenY;
       maxPantalla.x += - MidaMitadImagenX;
       maxPantalla.y += - MidaMitadImagenY;
    }

    // Update is called once per frame
    void Update()
    {
        Movjugador();
        DisBala();
    }

    private void Movjugador(){
        
        float DirX = Input.GetAxisRaw("Horizontal");
        float DirY = Input.GetAxisRaw("Vertical");

        UnityEngine.Vector2 Movimiento = new UnityEngine.Vector2(DirX,DirY).normalized;
        UnityEngine.Vector2 NewPos = transform.position;
        NewPos = NewPos + _vel * Time.deltaTime * Movimiento;
        NewPos.x = Mathf.Clamp(NewPos.x, minPantalla.x,maxPantalla.x);
        NewPos.y = Mathf.Clamp(NewPos.y, minPantalla.y,maxPantalla.y);
        transform.position = NewPos;
        //Debug.Log(DirX+" x , "+DirY+" y. Vel = "+_vel);
    }
    private void OnTriggerEnter2D(Collider2D objetoTocado) {
        Debug.Log(objetoTocado.tag);
        if (objetoTocado.tag == "Obstaculo")
        {
            vidas--;
            if (vidas != 0) {
                TextoVidas.text = "Vidas: "+vidas;
            }else {
                TextoVidas.text = "¡Has perdido!";
            }
            if (vidas <= 0) {
                GameObject explosion = Instantiate(prefabexplo);
                explosion.transform.position = transform.position;
                Destroy(gameObject);
                SceneManager.LoadScene("PantallaMuerte");
            }
        }
    }
    
    private void DisBala() {
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject Bala = Instantiate(prefabprojectile);
            Bala.transform.position = transform.position;
        }
    }
}
