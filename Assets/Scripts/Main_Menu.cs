using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaLvl01 : MonoBehaviour
{
    public void LoadNormalScene()
    {
        SceneManager.LoadScene("normal_lvl01"); // Asegúrate de que "normal" sea exactamente el nombre de la escena
    }
}
