using UnityEngine;

public class puerta : MonoBehaviour
{
    public bool abierta = false;
    public float velocidad = 2f;

    public enum Eje { X, Y }
    public Eje eje = Eje.Y;

    public float distancia = 3f; // cuánto se mueve

    private Vector3 posicionCerrada;
    private Vector3 posicionAbierta;

    void Start()
    {
        posicionCerrada = transform.position;

        // 🔥 Calcula automáticamente la posición abierta
        if (eje == Eje.X)
        {
            posicionAbierta = posicionCerrada + new Vector3(distancia, 0, 0);
        }
        else if (eje == Eje.Y)
        {
            posicionAbierta = posicionCerrada + new Vector3(0, distancia, 0);
        }
    }

    void Update()
    {
        Vector3 destino = abierta ? posicionAbierta : posicionCerrada;

        transform.position = Vector3.Lerp(transform.position, destino, Time.deltaTime * velocidad);
    }

    public void Abrir()
    {
        abierta = true;
    }

    public void Cerrar()
    {
        abierta = false;
    }
}