public class Singleton
{
    private static Singleton instance;
    protected Singleton() { }
    public static Singleton Instance
    {
        get
        {
            if (instance == null)
                instance = new();
            return instance;
        }
    }
}
