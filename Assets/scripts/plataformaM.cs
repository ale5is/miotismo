using UnityEngine;

public class plataformaM : MonoBehaviour
{
    public Vector3 offset;
    public float velocidad = 2f;

    public bool activa = false;

    private Vector3 puntoA;
    private Vector3 puntoB;
    private Vector3 objetivo;

    void Start()
    {
        puntoA = transform.position;
        puntoB = puntoA + offset;

        objetivo = puntoB;
    }

    void Update()
    {
        // 🔥 SOLO se mueve si está activa
        if (!activa) return;

        transform.position = Vector3.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, objetivo) < 0.1f)
        {
            if (Vector3.Distance(objetivo, puntoA) < 0.1f)
                objetivo = puntoB;
            else
                objetivo = puntoA;
        }
    }


    public void Activar()
    {
        activa = true;
    }

    public void Desactivar()
    {
        activa = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}