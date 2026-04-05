using UnityEngine;

[System.Serializable]
public class MisionData
{
    public int id;
    public string titulo;
    public string descripcion;
    public ObjetivoMision[] objetivos;
    public int recompensaPuntos;

}
[System.Serializable]
public class ObjetivoMision
{
    public string fruta;
    public int cantidad;
}
