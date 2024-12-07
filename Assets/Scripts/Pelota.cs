using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    [SerializeField] float impulso;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 direccion;
    [SerializeField] Vector2 posicionInicial;
    [SerializeField] Transform barra;
    bool jugando;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posicionInicial = transform.position;
        barra = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !jugando)
        {
            jugando = true;
            transform.SetParent(null);
            float x = Random.Range(0, 2);
            direccion = new Vector2 (0, 1);
            if(x == 0) { direccion.x = 1; }
            else {  direccion.x = -1; }

            rb.velocity = Vector2.zero;
            rb.AddForce (direccion * impulso);
        }
    }

    public void Reiniciar()
    {
        rb.velocity = Vector2.zero;
        transform.SetParent(barra);
        transform.position = posicionInicial;
        jugando = false;
    }

    public void DetenerMovimiento()
    {
        rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Bloque")
        {
            Destroy(collision.gameObject);
            GameManager.Instancia.SumarPuntos();    
        }

        if(collision.transform.tag == "Perder")
        {
            GameManager.Instancia.PerderVida();
        }
    }
}
