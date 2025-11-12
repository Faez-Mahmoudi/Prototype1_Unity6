using UnityEngine;


public class MainManager : MonoBehaviour
{
    public static MainManager Instance{ get; private set;}

    public int playerOneWins;
    public int playerTwoWins;
    
    void Awake()
    {
       if(Instance != null)
       {
            Destroy(gameObject);
            return;
       }

       Instance = this;
       DontDestroyOnLoad(gameObject); 
    }
}
