using UnityEngine;

public class activable : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color colorOriginal;

    public puerta puerta; // 👈 arrastrás la puerta desde Unity

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        colorOriginal = sr.color;
    }

    public void Activar()
    {
        sr.color = Color.green;

        if (puerta != null)
            puerta.Abrir();
    }

    public void Desactivar()
    {
        sr.color = colorOriginal;

        if (puerta != null)
            puerta.Cerrar();
    }
}