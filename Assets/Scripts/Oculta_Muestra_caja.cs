using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlVisibilidad : MonoBehaviour
{
    private Renderer objectRenderer;

    private void Awake()
    {
        // Obtén el componente Renderer del GameObject
        objectRenderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        // Suscribirse al evento de cambio de escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Desuscribirse del evento de cambio de escena
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Comprobar el nombre de la escena actual
        if (scene.name == "normal") // Cambia "normal" por el nombre real de tu escena
        {
            // Ocultar el GameObject
            objectRenderer.enabled = false;
        }
        else
        {
            // Mostrar el GameObject en otras escenas
            objectRenderer.enabled = true;
        }
    }
}
