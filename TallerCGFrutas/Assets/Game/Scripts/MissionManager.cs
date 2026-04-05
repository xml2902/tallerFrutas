using UnityEngine;

public class MissionManager : MonoBehaviour
{
    private MisionData misionActiva;
    private bool misionCumplida = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AsignarMision(MisionData mision)
    {
        misionActiva = mision;
        misionCumplida = false;
        Debug.Log("Misión asignada: " + mision.titulo + " / " + mision.descripcion);
    }

    public bool VerificarMision()
    {
        if (misionActiva == null || misionActiva.objetivos == null) return false;
        if (misionCumplida) return true;

        bool todasCompletadas = true;

        foreach (var obj in misionActiva.objetivos)
        {
            int actual = ConsultarProgreso(obj.fruta);

            if (actual < obj.cantidad)
            {
                todasCompletadas = false;
                break;
            }
        }

        if (todasCompletadas)
        {
            misionCumplida = true;
            Debug.Log("¡Misión cumplida!");
        }

        return misionCumplida;
    }

    public string ObtenerTextoProgreso()
    {
        if (misionActiva == null || misionActiva.objetivos == null) return "Sin misión";

        string textoProgreso = "";

        foreach (var obj in misionActiva.objetivos)
        {
            int actual = ConsultarProgreso(obj.fruta);
            textoProgreso += $"{obj.fruta}: {actual}/{obj.cantidad}  ";
        }

        return textoProgreso;
    }

    public MisionData GetMisionActiva()
    {
        return misionActiva;
    }

    private int ConsultarProgreso(string fruta)
    {
        if (GameManager.Instance == null || string.IsNullOrEmpty(fruta)) return 0;

        string f = fruta.ToLower().Trim();

        if (f == "any")
        {
            return GameManager.Instance.CountApple +
                   GameManager.Instance.CountBanana +
                   GameManager.Instance.CountOrange +
                   GameManager.Instance.CountCherries +
                   GameManager.Instance.CountKiwi;
        }

        if (f == "Raras")
        {
            return GameManager.Instance.CountCherries + GameManager.Instance.CountKiwi;
        }

        switch (f)
        {
            case "apple": return GameManager.Instance.CountApple;
            case "bananas": return GameManager.Instance.CountBanana;
            case "orange": return GameManager.Instance.CountOrange;
            case "cherries": return GameManager.Instance.CountCherries;
            case "kiwi": return GameManager.Instance.CountKiwi;
            default: return 0;
        }
    }
}
