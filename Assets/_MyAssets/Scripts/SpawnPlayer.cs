using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [Header("Player Object")]
    public GameObject playerOne;
    public GameObject playerTwo;

    [Header("Spawn Transform")]
    public Transform playerOneSpawn;
    public Transform playerTwoSpawn;

    // spawn player at game start
    public void Spawn()
    {
        Instantiate(playerOne, playerOneSpawn.position, Quaternion.identity);
        Instantiate(playerTwo, playerTwoSpawn.position, Quaternion.identity);
    }
}
