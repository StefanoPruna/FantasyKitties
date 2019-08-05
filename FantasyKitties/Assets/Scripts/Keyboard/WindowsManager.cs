using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    public GenericWindow[] windows;
    public int currentWindowID;
    public int defaultWindowID;

    public GenericWindow GetWindow(int value)
    {
        return windows[value];
    }

    private void ToggleVisability(int value)
    {
        var total = windows.Length;
        for (var i = 0; i<total; i++)
        {
            var window = windows[i];
            if (i == value)
                window.Open();
            else 
            {
                window.Close();
            }
        }
    }

    public GenericWindow Open(int value)
    {
        if (value < 0 || value >= windows.Length)
            return null;

        currentWindowID = value;

        ToggleVisability(currentWindowID);

        return GetWindow(currentWindowID);
    }

    private void Start()
    {        
        Open (defaultWindowID);
    }

    public class GenericWindow
    {
        internal object gameObject;

        internal void Close()
        {
            throw new NotImplementedException();
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }
    }
}
