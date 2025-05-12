using UnityEngine;

public class Recogible : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entró al trigger tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Busca el objeto con tag "Fogata"
            GameObject fogataObj = GameObject.FindGameObjectWithTag("Fogata");

            if (fogataObj != null)
            {
                // Obtiene el componente FogataLuz y aumenta la intensidad
                FogataLuz fogata = fogataObj.GetComponent<FogataLuz>();
                if (fogata != null)
                {
                    fogata.IncrementarIntensidad();
                }
            }

            // Destruye este objeto (la esfera)
            Destroy(gameObject);
        }
    }
}
