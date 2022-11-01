using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    DuckController duck;
    [SerializeField] GameObject egg;
    private void Start()
    {
        egg.SetActive(true);
        duck = GameObject.Find("Mama Duck").GetComponent<DuckController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Vector3 randomPosition = new Vector3(Random.Range(-8, 8), 0.7f, Random.Range(-8, 8));
        if (other.CompareTag("Player"))
        {
            duck.CollectBaby();
            FindObjectOfType<AudioManager>().Play("Baby Pick Up");
            Instantiate(egg, randomPosition, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
