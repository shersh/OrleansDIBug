using System;
using System.Threading.Tasks;
using Orleans;

namespace OrleanAzureInterfaces
{
 
    public interface IUserGrain : IGrainWithIntegerKey
    {
        Task<int> GetSomething();
    }

    public interface IPlayerGrain : IGrainWithIntegerKey
    {
        Task<int> GetSomething();
    }
}
