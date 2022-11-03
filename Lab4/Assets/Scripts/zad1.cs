using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class zad1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public List<int> positionsX;
    public List<int> positionsZ;
    public List<Material> materials = new List<Material>();
    int objectCounter = 0;
    public float delay = 1.0f;
    public int objectAmount;
    public GameObject cube;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        int boundX = Mathf.CeilToInt(rend.bounds.extents.x);
        int boundZ = Mathf.CeilToInt(rend.bounds.extents.z);
        int boundNegativeX = Mathf.CeilToInt(rend.bounds.center.x - rend.bounds.extents.x);
        int boundNegativeZ = Mathf.CeilToInt(rend.bounds.center.z - rend.bounds.extents.z);

        positionsX = new List<int>(Enumerable.Range(boundNegativeX, boundX * 2).OrderBy(x => System.Guid.NewGuid()).Take(10));
        positionsZ = new List<int>(Enumerable.Range(boundNegativeZ, boundZ * 2).OrderBy(x => System.Guid.NewGuid()).Take(10));

        for (int i = 0; i < objectAmount; i++)
        {
            this.positions.Add(new Vector3(positionsX[i], 5, positionsZ[i]));
        }

        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }

        StartCoroutine(GenerujObiekt());

        Debug.Log(materials);
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywo³ano coroutine");
        foreach (Vector3 pos in positions)
        {
            if (this.objectCounter != objectAmount)
            {
                GameObject clone = Instantiate(this.cube, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
                //przydzielenie losowego materia³u z listy materia³ów
                clone.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Count() - 1)];
                yield return new WaitForSeconds(this.delay);
            }
        }
            
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}