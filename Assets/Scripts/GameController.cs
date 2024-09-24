using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance; // Singleton para acceder fácilmente al contador
    public TMP_Text scoreText;
    private int puntos;

    void Awake()
    {
        // Configurar el singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Asegura que no se destruya al cargar nuevas escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncrementarPuntos(int cantidad)
    {
        puntos+=cantidad;
        scoreText.text = "Score: " + puntos.ToString();
    }

    public void DisminuirPuntos(int cantidad)
    {
        puntos-=cantidad;
        scoreText.text = "Score: " + puntos.ToString();
    }
}
