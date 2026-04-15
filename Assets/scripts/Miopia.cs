using UnityEngine;

public class Miopia : MonoBehaviour
{
    public GameObject objeto, canvas;
    public KeyCode tecla = KeyCode.E;

    void Update()
    {
        if (Input.GetKeyDown(tecla))
        {
            objeto.SetActive(!objeto.activeSelf);
            canvas.SetActive(!canvas.activeSelf);
        }
    }
}