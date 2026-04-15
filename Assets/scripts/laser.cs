using UnityEngine;

public class laser : MonoBehaviour
{
    public float distancia = 10f;
    public LineRenderer line;

    public Transform origen; // 👈 hijo desde donde sale el láser

    public activable ultimo;

    void Update()
    {
        // 🔥 Usar el hijo como origen y dirección
        Vector3 start = origen.position;
        Vector3 dir = origen.right; // 👉 la dirección del hijo

        Vector3 end = start + dir * distancia;

        RaycastHit2D hit = Physics2D.Raycast(start, dir, distancia);

        if (hit.collider != null)
        {
            end = hit.point;

            if (hit.collider.CompareTag("activable"))
            {
                activable obj = hit.collider.GetComponent<activable>();

                if (obj != null)
                {
                    obj.Activar();

                    if (ultimo != null && ultimo != obj)
                        ultimo.Desactivar();

                    ultimo = obj;
                }
            }
            else
            {
                if (ultimo != null)
                {
                    ultimo.Desactivar();
                    ultimo = null;
                }
            }
        }
        else
        {
            if (ultimo != null)
            {
                ultimo.Desactivar();
                ultimo = null;
            }
        }

        // Dibujar láser
        line.SetPosition(0, start);
        line.SetPosition(1, end);
    }
}