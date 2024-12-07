using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour
{
    [SerializeField] public float velocidad;
    [SerializeField] Vector2 posicionInicial;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime * Input.GetAxis("Horizontal"));
        rb.velocity = Vector2.zero;
    }

    public void Reiniciar()
    {
        transform.position = posicionInicial;   
    }
}
