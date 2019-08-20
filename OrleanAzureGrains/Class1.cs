using System;
using System.Threading.Tasks;
using OrleanAzureInterfaces;
using Orleans;

namespace OrleanAzureGrains
{
    public class MyGrain : Grain, IUserGrain
    {
        public Task<int> GetSomething()
        {
            return Task.FromResult(new Random().Next());
        }
    }

    public class MyGrain2 : Grain, IPlayerGrain
    {
        public Task<int> GetSomething()
        {
            return Task.FromResult(1);
        }
    }

}
