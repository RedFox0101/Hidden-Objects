using System.Threading.Tasks;

public interface IServiceStarter
{
    Task StartService();
    void StopService();
}
