using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderScenes : MonoBehaviour
{
   
    public GameObject panelInfo;

    
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    
    public void SalirJuego()
    {
        Debug.Log("Cerrando aplicación...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

   
    public void MostrarInfo()
    {
        if (panelInfo != null)
        {
            panelInfo.SetActive(true);
        }
    }

   
    public void OcultarInfo()
    {
        if (panelInfo != null)
        {
            panelInfo.SetActive(false);
        }
    }
}