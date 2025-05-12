using UnityEngine;

public class FogataLuz : MonoBehaviour
{
    public Light luz;

    public float intensidadMin = 1.5f;
    public float intensidadMax = 2.5f;
    public float velocidadCambio = 2f;

    public float velocidadReduccion = 1.2f; // Velocidad con la que min y max bajan
    public float incrementoPorRecogida = 0.5f;

    private float intensidadObjetivo;
    private bool estaApagada = false;

    void Start()
    {
        if (luz == null)
            luz = GetComponent<Light>();

        NuevaIntensidadObjetivo();
    }

    void Update()
    {
        if (estaApagada)
            return;

        // Reducimos los límites con el tiempo
        intensidadMin = Mathf.Max(0f, intensidadMin - velocidadReduccion * Time.deltaTime);
        intensidadMax = Mathf.Max(0f, intensidadMax - velocidadReduccion * Time.deltaTime);

        // Si ya están en 0, apagamos la luz
        if (intensidadMax <= 0f && intensidadMin <= 0f)
        {
            luz.intensity = 0f;
            estaApagada = true;
            return;
        }

        // Oscila hacia la intensidad objetivo
        luz.intensity = Mathf.Lerp(luz.intensity, intensidadObjetivo, Time.deltaTime * velocidadCambio);

        // Cuando se acerca al objetivo, generamos uno nuevo
        if (Mathf.Abs(luz.intensity - intensidadObjetivo) < 0.1f)
        {
            NuevaIntensidadObjetivo();
        }
    }

    void NuevaIntensidadObjetivo()
    {
        intensidadObjetivo = Random.Range(intensidadMin, intensidadMax);
    }

    // 🔥 Este método lo llamará la esfera cuando sea recogida
    public void IncrementarIntensidad()
    {
        if (estaApagada) return;

        intensidadMin += incrementoPorRecogida;
        intensidadMax += incrementoPorRecogida;

        // Evitamos que min > max por error
        if (intensidadMin > intensidadMax)
            intensidadMax = intensidadMin + 0.1f;
    }
}
