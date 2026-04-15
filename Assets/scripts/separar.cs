using UnityEngine;

public class separar : MonoBehaviour
{
    public float distancia = 3f;
    public float velocidad = 5f;

    public bool estaSeparado = false;
    private bool estaMoviendose = false; // 🔥 bloqueo anti spam

    private GameObject clon;

    private Vector3 origen;
    private Vector3 targetOriginal;
    private Vector3 targetClon;

    void Update()
    {
        // 🔥 SOLO permitir si no se está moviendo
        if (Input.GetKeyDown(KeyCode.E) && !estaMoviendose)
        {
            if (!estaSeparado)
            {
                Separar();
            }
            else
            {
                Volver();
            }
        }

        // Movimiento separación
        if (estaSeparado)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetOriginal, velocidad * Time.deltaTime);

            if (clon != null)
                clon.transform.position = Vector3.MoveTowards(clon.transform.position, targetClon, velocidad * Time.deltaTime);

            // 🔥 Cuando termina de separarse
            if (Vector3.Distance(transform.position, targetOriginal) < 0.05f)
            {
                estaMoviendose = false;
            }
        }
        // Movimiento regreso
        else if (clon != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, origen, velocidad * Time.deltaTime);
            clon.transform.position = Vector3.MoveTowards(clon.transform.position, origen, velocidad * Time.deltaTime);

            // 🔥 Cuando llegan al centro
            if (Vector3.Distance(transform.position, origen) ==0 &&
                Vector3.Distance(clon.transform.position, origen) ==0)
            {
                Destroy(clon);
                clon = null;
                estaMoviendose = false;
            }
        }
    }

    void Separar()
    {
        origen = transform.position;

        clon = Instantiate(gameObject, origen, Quaternion.identity);

        clon.GetComponent<separar>().enabled = false;

        targetOriginal = origen + Vector3.right * distancia;
        targetClon = origen + Vector3.left * distancia;

        estaSeparado = true;
        estaMoviendose = true; // 🔥 bloquear input
    }

    void Volver()
    {
        estaSeparado = false;
        estaMoviendose = true; // 🔥 bloquear input
    }
}