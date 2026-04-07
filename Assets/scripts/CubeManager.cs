using NUnit.Framework.Internal;
using System.Threading;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public NewMonoBehaviourScript2[] generatedCubes = new NewMonoBehaviourScript2[5];

    public float timer = 0.0f;
    public float interval = 3.0f;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            RanbomizeCubeActivation();
            timer = 0.0f;
        }
    }
    public void RanbomizeCubeActivation()
    {
        for (int i = 0; i < generatedCubes.Length; i++)
        {
            int randomNum = Random.Range(0, 2);
            if (randomNum == 1)
            {
                generatedCubes[i].Gencube();
            }
        }
    }
}
