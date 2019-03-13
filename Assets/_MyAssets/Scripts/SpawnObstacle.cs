using UnityEngine;
using System.Collections;

public class SpawnObstacle : MonoBehaviour
{
    [Header("Obstacle Pos")]
    public Transform obs1;
    public Transform obs2;
    public Transform obs3;
    public Transform obs4;

    [Header("Obstacle")]
    public GameObject obstacle;

    string[] randomPattern;
    float spawnDiff = 0.0f;


    void Start()
    {
        // init random pattern method names
        randomPattern = new string[4];
        randomPattern[0] = "PatternOne";
        randomPattern[1] = "PatternTwo";
        randomPattern[2] = "PatternThree";
        randomPattern[3] = "PatternFour";
    }

    // stop all coroutines when player loses
    public void StopSpawn()
    {
        StopAllCoroutines();
    }

    // start spawning obstacles
    public void StartSpawn()
    {
        spawnDiff = 0.0f;

        //StartCoroutine("SpawnPattern");
        StartCoroutine("SpawnRandomPattern");
    }

    // spawn obstacles by certain pattern
    IEnumerator SpawnPattern()
    {
        while(true)
        {
            StartCoroutine("PatternOne");
            yield return new WaitForSeconds(2.0f);

            StartCoroutine("PatternTwo");
            yield return new WaitForSeconds(2.0f);

            StartCoroutine("PatternOne");
            yield return new WaitForSeconds(2.0f);

            StartCoroutine("PatternTwo");
            yield return new WaitForSeconds(2.0f);

            StartCoroutine("PatternThree");
            yield return new WaitForSeconds(2.0f);

            StartCoroutine("PatternTwo");
            yield return new WaitForSeconds(2.0f);
        }
    }

    // spawn obstacles by random pattern
    IEnumerator SpawnRandomPattern()
    {
        while(true)
        {
            // spawn random pattern and wait
            StartCoroutine(randomPattern[Random.Range(0, randomPattern.Length)]);
            yield return new WaitForSeconds(2.0f - spawnDiff * 2);

            // increase spawndiff after every pattern
            spawnDiff += .015f;
        }
    }

    IEnumerator PatternOne()
    {
        Instantiate(obstacle, obs2.position, Quaternion.identity);
        Instantiate(obstacle, obs3.position, Quaternion.identity);
        yield return new WaitForSeconds(1.0f - spawnDiff);
        Instantiate(obstacle, obs1.position, Quaternion.identity);
        Instantiate(obstacle, obs4.position, Quaternion.identity);
    }

    IEnumerator PatternTwo()
    {
        Instantiate(obstacle, obs1.position, Quaternion.identity);
        Instantiate(obstacle, obs3.position, Quaternion.identity);
        yield return new WaitForSeconds(1.0f - spawnDiff);
        Instantiate(obstacle, obs2.position, Quaternion.identity);
        Instantiate(obstacle, obs4.position, Quaternion.identity);

    }

    IEnumerator PatternThree()
    {
        Instantiate(obstacle, obs2.position, Quaternion.identity);
        Instantiate(obstacle, obs4.position, Quaternion.identity);
        yield return new WaitForSeconds(1.0f - spawnDiff);
        Instantiate(obstacle, obs2.position, Quaternion.identity);
        Instantiate(obstacle, obs3.position, Quaternion.identity);
    }

    IEnumerator PatternFour()
    {
        Instantiate(obstacle, obs1.position, Quaternion.identity);
        Instantiate(obstacle, obs3.position, Quaternion.identity);
        yield return new WaitForSeconds(1.0f - spawnDiff);
        Instantiate(obstacle, obs2.position, Quaternion.identity);
        Instantiate(obstacle, obs3.position, Quaternion.identity);
    }
}
