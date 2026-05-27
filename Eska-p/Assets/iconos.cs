using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class iconos : MonoBehaviour
{
    public Transform enemigoModelo;
    public float velocidadRotacion = 100f;

    void Update()
    {
        enemigoModelo.Rotate(0f, -velocidadRotacion * Time.deltaTime,0f,Space.Self);
    }
}
