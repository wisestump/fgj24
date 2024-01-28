using UnityEngine;

class PlayerSpawner : MonoBehaviour
{
    public Player[] Skins;

    public static PlayerSpawner Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnNewPlayer();
    }

    public Player SpawnNewPlayer()
    {
        return Instantiate(Skins[Random.Range(0, Skins.Length)]);
    }
}
