using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Numero : MonoBehaviour
{
    public Sprite[] spritesNumeros = new Sprite[10];
    private float _vel;
    private Vector2 minPantalla;
    private int valorNum;
    [SerializeField]
    private GameObject prefabexplo;
    // Start is called before the first frame update
    void Start()
    {
        _vel = 15;
        System.Random aleatorio = new System.Random();
        valorNum = aleatorio.Next(0,10);
        GetComponent<SpriteRenderer>().sprite = spritesNumeros[valorNum];
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));
    }

    private void OnTriggerEnter2D(Collider2D objetoTocado) {
        Debug.Log(objetoTocado.tag);
        if (objetoTocado.tag == "BalaJugador" || objetoTocado.tag == "NaveJugador")
        {
            GameObject explosion = Instantiate(prefabexplo);
            explosion.transform.position = transform.position;
            Destroy(gameObject);
        }
    }   
    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position;
        newPos += new Vector2 (0,-1) * _vel * Time.deltaTime;
        transform.position = newPos;
        if (transform.position.y < minPantalla.y)
        {
            Destroy(gameObject);
        }
    }
}
