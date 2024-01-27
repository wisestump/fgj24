using UnityEngine;

class PlayerSpawner : MonoBehaviour
{
    public GameObject[] Skins;

    private void Start()
    {
        Instantiate(Skins[Random.Range(0, Skins.Length)]);
    }
}
