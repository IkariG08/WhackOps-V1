using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject esferaPrefab; // Prefab de la esfera
    public float velocidadDisparo = 20f; // Velocidad de la esfera
    public float tiempoDestruccionEsfera = 1f; // Tiempo antes de destruir la esfera

    void Update()
    {
        // Detectar clic del mouse
        if (Input.GetMouseButtonDown(0)) // 0 es el botón izquierdo del mouse
        {
            DispararEsfera();
        }
    }

    void DispararEsfera()
    {
        // Crear una instancia de la esfera en la posición de la cámara o un punto de disparo
        GameObject esfera = Instantiate(esferaPrefab, transform.position, Quaternion.identity);

        // Obtener la dirección desde la cámara hacia el punto del mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 direccion = ray.direction.normalized;

        // Aplicar velocidad a la esfera en la dirección del ray
        Rigidbody rb = esfera.GetComponent<Rigidbody>();
        rb.velocity = direccion * velocidadDisparo;

        // Destruir la esfera después de un segundo
        Destroy(esfera, tiempoDestruccionEsfera);
    }
}
