using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{

    [SerializeField]
    private int baseValue;

    private List<int> currentStats = new List<int>();

    public int GetFinalValue()
    {
        int finalValue = baseValue;
        currentStats.ForEach(x => finalValue += x);
        return finalValue;
    }


    public void AddCurrentStat(int number)
    {
        if (number != 0)
        {
            currentStats.Add(number);
        }
    }

    public void RemoveCurrentStat(int number)
    {
        if (number != 0)
        {
            currentStats.Remove(number);
        }
    }
}
