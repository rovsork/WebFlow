using System.Collections.Generic;
using Microsoft.WindowsAzure.StorageClient;
using Storage.Models;

namespace Storage.Interactor
{
    public interface ContainerInteractor
    {
        CloudBlobContainer CreateNewContainer(string containerName);
        CloudBlobContainer GetContainerByName(string containerName);
        IEnumerable<CloudBlobContainer> GetAllContainerDetails();
    }
}
