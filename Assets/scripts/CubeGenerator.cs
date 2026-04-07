using UnityEngine;

public class NewMonoBehaviourScript2 : MonoBehaviour
{
    public GameObject cubePrefab;
    public int totalCubes = 10;
    public float cubeSpacing = 10;
    void Start()
    {
        Gencube();
    }

    public void Gencube()
    {
        Vector3 myposition = transform.position;
        GameObject firstCube = Instantiate(cubePrefab, myposition, Quaternion.identity);
        for (int i = 1; i < totalCubes; i++)
        {
            Vector3 position = new Vector3(myposition.x, myposition.y, myposition.z + (i* cubeSpacing));
            Instantiate(cubePrefab, position, Quaternion.identity);
        }
    }
}
