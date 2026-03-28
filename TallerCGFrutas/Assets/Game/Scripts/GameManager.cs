using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private float globalTime;

    private int totalApple;
    private int totalOrange;
    private int totalBanana;
    private int totalKiwi;
    private int totalCherries;
    private int totalMelon;
    private int totalPineapple;
    private int totalStrawberry;


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
        switch(item.itemType)
        {
            //case ItemType.Apple:
            //    totalApples += item.itemValue;
            //    break;
            //case ItemType.Orange:
            //    totalOranges += item.itemValue;
            //    break;
        }
    }

    public void SumarItem (string itemName, int itemValue)
    {
        switch(itemName)
        {
            case "Apple":
                totalApple += itemValue;
                break;
            case "Orange":
                totalOrange += itemValue;
                break;
            case "Banana":
                totalBanana += itemValue;
                break;
            case "Kiwi":
                totalKiwi += itemValue;
                break;
            case "Cherries":
                totalCherries += itemValue;
                break;
            case "Melon":
                totalMelon += itemValue;
                break;
            case "Pineapple":
                totalPineapple += itemValue;
                break;
            case "Strawberry":
                totalStrawberry += itemValue;
                break;
        }
    }

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
