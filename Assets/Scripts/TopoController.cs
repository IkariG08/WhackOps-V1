using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class TopoController : MonoBehaviour
{
    private float velocidad;
    private float distanciaRecorrido;
    private Vector3 posicionInicial;

    public void IniciarMovimiento(float velocidadTopo, float distanciaMaxima)
    {
        velocidad = velocidadTopo;
        distanciaRecorrido = distanciaMaxima;
        posicionInicial = transform.position; // Guardar la posición inicial
    }

    void Update()
    {
        // Mover el topo hacia la derecha
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

        // Si ha recorrido la distancia máxima, destruir el topo
        if (Vector3.Distance(posicionInicial, transform.position) >= distanciaRecorrido)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            if (gameObject.tag == "Good")
            {
                GameController.instance.IncrementarPuntos(100);
            }
            else if (gameObject.tag == "Bad")
            {
                GameController.instance.DisminuirPuntos(100);
            }
            else if (gameObject.tag == "SilverTopo")
            {
                GameController.instance.IncrementarPuntos(250);
            }
            else if (gameObject.tag == "GoldTopo")
            {
                GameController.instance.IncrementarPuntos(500);
            }
            else if (gameObject.tag == "TopoCate")
            {
                GameController.instance.IncrementarPuntos(0);
            }

            // Destruir la esfera y el topo
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }
}
