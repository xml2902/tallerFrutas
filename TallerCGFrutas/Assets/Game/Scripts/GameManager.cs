using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private float globalTime;

    // Contadores para puntacion de frutas
    private int totalApple;
    private int totalOrange;
    private int totalBanana;
    private int totalKiwi;
    private int totalCherries;
    private int totalMelon;
    private int totalPineapple;
    private int totalStrawberry;

    // Contadores para cantidad de frutas
    private int countApple;
    private int countOrange;
    private int countBanana;
    private int countKiwi;
    private int countCherries;
    private int countMelon;
    private int countPineapple;
    private int countStrawberry;


    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
            
            Instance = this;
            DontDestroyOnLoad(gameObject); 
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globalTime = 0;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ReiniciarContadores();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TotalTime(float timeScene)
    {
        globalTime += timeScene;
    }

    public void AddItem(ItemData item)
    {
        //switch(item.itemType)
        //{
        //    //case ItemType.Apple:
        //    //    totalApples += item.itemValue;
        //    //    break;
        //    //case ItemType.Orange:
        //    //    totalOranges += item.itemValue;
        //    //    break;
        //}
    }

    public void ReiniciarContadores()
    {
        totalApple = 0;
        totalOrange = 0;
        totalBanana = 0;
        totalKiwi = 0;
        totalCherries = 0;
        countApple = countOrange = countBanana = countKiwi = countCherries = countMelon = countPineapple = countStrawberry = 0;
        Debug.Log("Todos los contadores y conteos reiniciados para nuevo nivel.");
    }

    public void SumarItem (string itemName, int itemValue)
    {
        switch(itemName.ToLower())
        {
            case "apple":
                totalApple += itemValue;
                countApple++;
                break;
            case "orange":
                totalOrange += itemValue;
                countOrange++;
                break;
            case "bananas":
                totalBanana += itemValue;
                countBanana++;
                break;
            case "kiwi":
                totalKiwi += itemValue;
                countKiwi++;
                break;
            case "cherries":
                totalCherries += itemValue;
                countCherries++;
                break;
            case "melon":
                totalMelon += itemValue;
                countMelon++;
                break;
            case "pineapple":
                totalPineapple += itemValue;
                countPineapple++;
                break;
            case "strawberry":
                totalStrawberry += itemValue;
                countStrawberry++;
                break;
        }
    }

    public int CountApple => countApple;
    public int CountBanana => countBanana;
    public int CountOrange => countOrange;
    public int CountKiwi => countKiwi;
    public int CountCherries => countCherries;

    public float GlobalTime { get => globalTime; set => globalTime = value; }
    public int TotalApple { get => totalApple; set => totalApple = value; }
    public int TotalOrange { get => totalOrange; set => totalOrange = value; }
    public int TotalBanana { get => totalBanana; set => totalBanana = value; }
    public int TotalKiwi { get => totalKiwi; set => totalKiwi = value; }
    public int TotalCherries { get => totalCherries; set => totalCherries = value; }
    public int TotalMelon { get => totalMelon; set => totalMelon = value; }
    public int TotalPineapple { get => totalPineapple; set => totalPineapple = value; }
    public int TotalStrawberry { get => totalStrawberry; set => totalStrawberry = value; }
}
