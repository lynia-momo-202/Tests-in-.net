namespace GameLibrary;

public abstract class TimeProvider
{
    public virtual DateTimeOffset GetUtcNow() => DateTimeOffset.UtcNow;
}
