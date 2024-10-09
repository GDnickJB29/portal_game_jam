using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void cargar_nivel_02()
    {
        SceneManager.LoadScene("normal_lvl02"); // Asegúrate de que "normal" sea exactamente el nombre de la escena
    }
}

