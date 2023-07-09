using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class s_AsyncTest : MonoBehaviour
{
    public int size = 1000;
    [Header("KeyInput")]
    public KeyCode Execute = KeyCode.H;
    public KeyCode ExecuteAsync = KeyCode.G;

    bool calculationOver = true;
    CancellationTokenSource tokenSource;
    
    void Start()
    {
        tokenSource = new CancellationTokenSource();
    }

    private void Update()
    {
        if (Input.GetKeyDown(Execute) && calculationOver)
            PerformCalculations();
        if (Input.GetKeyDown(ExecuteAsync) && calculationOver)
            PerformCalculationsAsync();
    }

    void PerformCalculations()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        calculationOver = false;
        float[,] mapValues = new float[size, size];
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                mapValues[x, y] = Mathf.PerlinNoise(x * 0.01f, y * 0.01f);
            }
        }

        watch.Stop();
        var elapsedTime = watch.ElapsedMilliseconds;
        Debug.Log("Operation took: " + elapsedTime + " ms ");
        calculationOver = true;
    }

    async void PerformCalculationsAsync()
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();

        calculationOver = false;
        var result = await Task.Run(() =>
        {
            float[,] mapValues = new float[size, size];
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    mapValues[x, y] = Mathf.PerlinNoise(x * 0.01f, y * 0.01f);
                    if(tokenSource.IsCancellationRequested)
                    {
                        return mapValues;
                    }
                }
            }
            return mapValues;
        }, tokenSource.Token);
        if (tokenSource.IsCancellationRequested)
        {
            Debug.Log("Task stopped");
            return;
        }
        //only when the await Task finishes will we continue with the code
        Debug.Log($"Size of 2D array {result.GetLength(0)} {result.GetLength(1)}");

        watch.Stop();
        var elapsedTime = watch.ElapsedMilliseconds;
        Debug.Log("Operation took: " + elapsedTime + " ms ");
        calculationOver = true;
    }

    private void OnDisable()
    {
        tokenSource.Cancel();
    }


}
