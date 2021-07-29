using System;

public class EventBroker
{
    public static event Action OnLoadSceneDone;

    public static void CallOnLoadSceneDone()
    {
        OnLoadSceneDone?.Invoke();
    }
}
