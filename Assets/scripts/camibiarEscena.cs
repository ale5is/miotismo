using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiarEscena : MonoBehaviour
{
    public string escenaPorTrigger; 
    public string escenaPorTecla;

    public KeyCode tecla = KeyCode.E;

    private bool dentro = false;

    void Update()
    {
        if (Input.GetKeyDown(tecla))
        {
            SceneManager.LoadScene(escenaPorTecla);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            dentro = true;

            
            SceneManager.LoadScene(escenaPorTrigger);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            dentro = false;
        }
    }
}