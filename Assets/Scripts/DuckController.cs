using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : MonoBehaviour
{
    [SerializeField] GameObject babyPrefab;
    [SerializeField] int gap = 10;
    [SerializeField] float babySpeed = 5;
    List<GameObject> Babies = new List<GameObject>();
    //List<Vector3> PositionHistory = new List<Vector3>();
    [SerializeField] DuckMovement duckMovement;
    int babyCount = 0;
    [SerializeField] int maxBabies;
    [SerializeField] GameObject winPanel;

    private void Start()
    {
        duckMovement = GetComponent<DuckMovement>();
        winPanel.SetActive(false);
    }
    private void Update()
    {
        //Move Babies
        int index = 0;
        foreach (var baby in Babies)
        {
            Vector3 point = duckMovement.PositionHistory[Mathf.Min(index * gap, duckMovement.PositionHistory.Count - 1)]; //Gap is to adjust spacing 
            
            if (duckMovement.isMoving == true)
            {
                Vector3 moveDirection = point - baby.transform.position;
                baby.transform.position += moveDirection * babySpeed * Time.deltaTime;
                baby.transform.LookAt(point); //Rotate de baby
            }
            index++;
        }
        
    }
    
    public void CollectBaby()
    {
        babyCount++;
        GameObject baby = Instantiate(babyPrefab);
        if (babyCount >= maxBabies)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0;
        }
        Babies.Add(baby);
    }
}
