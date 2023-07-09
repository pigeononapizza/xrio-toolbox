using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq; //Enables conversion from array to list and vice versa
using System;

public class LeetCode_Refs : MonoBehaviour
{
    int val = 0;
    int[] arr = new int[3]; //or {0,1,2};
    int[,] jagArr_Unity = new int[2, 2]; //or {{1,2},{3,4}}
    int[][] jagArr_NonUnity = new int[2][]; //need to leave second empty and populate with for loop
    List<int> list = new List<int>();
    HashSet<int> hash = new HashSet<int>();
    Dictionary<int, int> dict = new Dictionary<int, int>();
    Stack<char> stack = new Stack<char>(); //Last in First out
    Queue<string> queue = new Queue<string>(); //First in First out

    //Array
    #region ARRAY
    void Array_Access(int[] arr)
    {
        foreach(var itm in arr.Distinct())
        {
            if (arr.Count(x => x == itm) == 1)
            {
                int index = Array.FindIndex(arr, x=>x==val);
            }
        }
        int maxValue = arr.Max();
        int maxValue_alt = Mathf.Max(arr);
        arr = list.ToArray(); //*using System.Linq;
    }
    #endregion ARRAY


    //Jagged Array 
    #region JAGGED ARRAY 
    void JagArray_Access_UNITY(int[,] jagArr)
    {
        int row = jagArr.GetLength(0);

        int column = jagArr.GetLength(1);
    }    
    void JagArray_Access_CS(int[][] jagArr, int row, int col)
    {
        int x_arr = jagArr.Length;
        int y_arr = jagArr[0].Length;

        int[][] newArr = new int[row][];
        for (int i = 0; i < row; i++)
        {
            newArr[i] = new int[col];
        }
    }
    #endregion JAGGED ARRAY

    //LIST 
    #region LIST
    void List_Usage()
    {
        list = arr.ToList();
        list.Sort(); //small to big
        list.Reverse();//big to small
        if (list.Contains(val))
        {
            int index = list.FindIndex(i => i == val);
        }
    }
    #endregion LIST

    //HASH SET
    #region HASH SET
    void HashSet_Usage(int num)
    {
        if (!hash.Add(num)) //if num can't be added to hash
        {
            print("hash already contains " + num);
        }
    }
    #endregion HASH SET


    //DICTIONARY
    #region DICTIONARY
    void DictionaryMethods(int key, int val, int[] nums)
    {
        if (!dict.ContainsKey(key)) //if dict doesn't contain key
        {
            dict.Add(key, 0); //add key
        }

        if(dict.TryGetValue(val, out int index)) //does the dictionary contain the desired val? 
        {
            print(index); //if so, output it's index
        }
    }
    #endregion DICTIONARY

    //STACK https://docs.microsoft.com/en-us/dotnet/api/system.collections.stack.push?view=net-5.0
    #region STACK
    void StackMethods()
    {
        stack.Count();
        stack.Peek(); //look at the last in
        stack.Pop(); //remove the last
        stack.Push('c'); //add to the top 
    }
    #endregion STACK

    //QUEUE https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1.dequeue?view=net-5.0
    void QueueMethods()
    {
        queue.Count();
        queue.Enqueue("one");
        queue.Peek();
        queue.Dequeue();
    }
}
