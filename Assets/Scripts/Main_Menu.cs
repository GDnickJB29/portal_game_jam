using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNormalScene()
    {
        SceneManager.LoadScene("normal"); // Asegúrate de que "normal" sea exactamente el nombre de la escena
    }
}