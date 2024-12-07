using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;
    public int vidas = 3;
    public int puntos;
    [SerializeField] GameObject gameOver, ganar;
    [SerializeField] GameObject[] bloques;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerderVida()
    {
        vidas--;
        if (vidas <= 0)
        {
            FindFirstObjectByType<Pelota>().DetenerMovimiento();
            FindFirstObjectByType<Barra>().velocidad = 0;
            gameOver.SetActive(true);
        }
        else
        {
            FindFirstObjectByType<Barra>().Reiniciar();
            FindFirstObjectByType<Pelota>().Reiniciar();
        }
    }

    public void SumarPuntos()
    {
        puntos++;
        bloques = GameObject.FindGameObjectsWithTag("Bloque");
        if(bloques.Length <= 1)
        {
            FindFirstObjectByType<Pelota>().DetenerMovimiento();
            FindFirstObjectByType<Barra>().velocidad = 0;
            ganar.SetActive(true);
        }
    }
}
