using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Textos : MonoBehaviour
{
    [SerializeField] TMP_Text puntos, vida;
    // Start is called before the first frame update
    void Start()
    {
        puntos.text = GameManager.Instancia.puntos.ToString();
        vida.text = GameManager.Instancia.vidas.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        puntos.text = GameManager.Instancia.puntos.ToString();
        vida.text = GameManager.Instancia.vidas.ToString();
    }
}
