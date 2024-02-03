// class for managing time across the scenes
public class TimeTillScene
    {
        private static float timeStamp = 0;
        
       public static void SetTime(float time)
       {
           timeStamp = time;
       }
       
       public static float GetTime()
       {
           return timeStamp;
       }
    }
