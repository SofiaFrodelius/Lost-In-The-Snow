public class Timer  {
    float time;


    public float Time
    {
        get
        {
            return time;
        }
        set
        {
            time = value;
        }
    }
    public void addTime(float dt)
    {
        time += dt;
    }
    public void subtractTime(float dt)
    {
        time -= dt;
    }
    public void resetTimer()
    {
        time = 0;
    }

}
