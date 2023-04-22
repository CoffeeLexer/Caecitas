using UnityEngine;

public static class Global
{
    private static Toolbar _toolbar;
    public static Toolbar Toolbar
    {
        get
        {
            if (!_toolbar)
                Debug.LogError("Toolbar is not initialized!");
            return _toolbar;
        }
        set
        {
            if(!_toolbar)
                _toolbar = value;
            else
                Debug.LogError("Only one Toolbar instance can be created!");
        }
    }

    private static Hand _hand;
    public static Hand Hand
    {
        get
        {
            if (!_hand)
                Debug.LogError("Hand is not initialized!");
            return _hand;
        }
        set
        {
            if (!_hand)
                _hand = value;
            else
                Debug.LogError("Only one Hand instance can be created!");
        }
    }

    private static Crosshair _crosshair;
    public static Crosshair Crosshair
    {
        get
        {
            if (!_crosshair)
                Debug.LogError("Crosshair is not initialized!");
            return _crosshair;
        }
        set
        {
            if (!_crosshair)
                _crosshair = value;
            else
                Debug.LogError("Only one Crosshair instance can be created!");
        } 
    }
    
    private static Notification _notification;
    public static Notification Notification
    {
        get
        {
            if (!_notification)
                Debug.LogError("Notification is not initialized!");
            return _notification;
        }
        set
        {
            if (!_notification)
                _notification = value;
            else
                Debug.LogError("Only one Notification instance can be created!");
        } 
    }
    
    private static NoiseGenerator _noiseGenerator;
    public static NoiseGenerator NoiseGenerator
    {
        get
        {
            if (!_noiseGenerator)
                Debug.LogError("NoiseGenerator is not initialized!");
            return _noiseGenerator;
        }
        set
        {
            if (!_noiseGenerator)
                _noiseGenerator = value;
            else
                Debug.LogError("Only one NoiseGenerator instance can be created!");
        } 
    }
}