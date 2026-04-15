using UnityEngine;

public class activador : MonoBehaviour
{
    public string tagObjetivo = "Player";
    public plataformaM plataforma;

    public bool requiereEstarDentro = true; 
    // true = solo activo mientras esté dentro
    // false = se activa una vez y queda activo

    public bool activo = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagObjetivo))
        {
            activo = true;
            plataforma.Activar();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(tagObjetivo))
        {
            if (requiereEstarDentro)
            {
                activo = false;
                plataforma.Desactivar();
            }
        }
    }
}