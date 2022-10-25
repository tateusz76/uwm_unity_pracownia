using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad5 : MonoBehaviour
{

  public GameObject cube;
  public List<Vector3> vectorsOfCubes;
  private Vector3 positionOfCube;

  void Start()
  {
    for (int i = 1; i <= 10; i++)
    {
      int x = Random.Range(-10, 11);
      int z = Random.Range(-10, 11);
      positionOfCube = new Vector3(x, transform.position.y, z);

      while (vectorsOfCubes.Contains(new Vector3(x, transform.position.y, z)))
      {
        x = Random.Range(1, 11);
        z = Random.Range(1, 11);
        positionOfCube = new Vector3(x, transform.position.y, z);
      }

      vectorsOfCubes.Add(positionOfCube);
      Instantiate(cube, positionOfCube, Quaternion.identity);
    }
  }
}