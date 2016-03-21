using System.ServiceModel;
using System.ServiceModel.Description;
namespace Space
{
    [ServiceContract]
    public interface IBlackHole
    {
        [OperationContract]
        Starship PullStarship(Starship ship);
        [OperationContract]
        string UltimateAnswer();
    }
}