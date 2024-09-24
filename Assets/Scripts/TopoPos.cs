using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopoPos : MonoBehaviour
{
    public Transform[] puntosIniciales; // Array de puntos iniciales (uno para cada repisa)
    public GameObject prefabTopoGood;
    public GameObject prefabTopoBad;
    public GameObject prefabTopoCate; // Prefab para TopoCate
    public GameObject prefabSilverTopo; // Prefab para SilverTopo
    public GameObject prefabGoldTopo; // Prefab para GoldTopo
    public float intervaloAparicion = 1f; // Intervalo entre la aparición de topos
    public float velocidadTopo = 2f; // Velocidad del topo
    public float distanciaRecorrido = 10f; // Distancia que recorrerán antes de desaparecer

    void Start()
    {
        // Inicia el ciclo de aparición de los topos
        InvokeRepeating("AparecerTopo", 0, intervaloAparicion);
    }

    void AparecerTopo()
    {
        // Seleccionar aleatoriamente un punto inicial (una repisa)
        int indiceAleatorio = Random.Range(0, puntosIniciales.Length);
        Transform puntoInicialSeleccionado = puntosIniciales[indiceAleatorio];

        GameObject prefabSeleccionado;

        if (indiceAleatorio == 1) // Segunda repisa (repisa del medio)
        {
            // Probabilidad de aparición en la segunda repisa
            float randomValue = Random.value;
            if (randomValue < 0.45f)
            {
                prefabSeleccionado = prefabTopoGood; // 45% de aparecer un topo bueno normal
            }
            else if (randomValue < 0.8f)
            {
                prefabSeleccionado = prefabTopoBad; // 35% de aparecer un topo malo normal
            }
            else if (randomValue < 0.95f)
            {
                prefabSeleccionado = prefabSilverTopo; // 15% de aparecer SilverTopo (250pts)
            }
            else
            {
                prefabSeleccionado = prefabTopoCate; // 5% de aparecer TopoCate
            }
        }
        else if (indiceAleatorio == 2) // Repisa superior (la última repisa)
        {
            // Probabilidad de aparición en la repisa superior
            float randomValue = Random.value;
            if (randomValue < 0.65f)
            {
                prefabSeleccionado = prefabTopoGood; // 65% de aparecer un topo bueno normal
            }
            else if (randomValue < 0.9f)
            {
                prefabSeleccionado = prefabTopoBad; // 25% de aparecer un topo malo normal
            }
            else
            {
                prefabSeleccionado = prefabGoldTopo; // 10% de aparecer GoldTopo (500pts)
            }
        }
        else // Repisas inferiores
        {
            // Probabilidad de aparición en las repisas inferiores
            float randomValue = Random.value;
            if (randomValue < 0.5f)
            {
                prefabSeleccionado = prefabTopoGood; // 50% de aparecer un topo bueno normal
            }
            else if (randomValue < 0.85f)
            {
                prefabSeleccionado = prefabTopoBad; // 35% de aparecer un topo malo normal
            }
            else
            {
                prefabSeleccionado = prefabTopoCate; // 15% de aparecer TopoCate
            }
        }

        // Instanciar el topo en el punto inicial seleccionado
        GameObject topo = Instantiate(prefabSeleccionado, puntoInicialSeleccionado.position, Quaternion.identity);

        // Asignar movimiento al topo
        TopoController controlador = topo.GetComponent<TopoController>();
        controlador.IniciarMovimiento(velocidadTopo, distanciaRecorrido);
    }
}
