namespace NetFabric;

public interface IAction<in T>
{
    void Invoke(T arg);
}
