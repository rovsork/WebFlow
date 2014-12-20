using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Storage.Factory;
using Microsoft.WindowsAzure.StorageClient;
using Storage.Models;
using Storage.API.ControllerHelpers;
using Storage.Interactor;

namespace Storage.API.Controllers
{
    public class ContainerController : ApiController
    {
        private readonly BlobInteractor blobInteractor;
        private readonly ContainerInteractor containerInteractor;

        public ContainerController()
        {
            blobInteractor =
                InteractorFactory.MakeBlobInteractor(ConfigurationManager.ConnectionStrings["AzureStorage"].ConnectionString);

            containerInteractor =
                InteractorFactory.MakeContainerInteractor(
                    ConfigurationManager.ConnectionStrings["AzureStorage"].ConnectionString);
        }

        //api/directory
        public IEnumerable<ContainerDetails> GetAllContainerDetails()
        {
            var containers = containerInteractor.GetAllContainerDetails();

            foreach (CloudBlobContainer cloudBlobContainer in containers)
                yield return new ContainerDetails()
                    {
                        Name = cloudBlobContainer.Name,
                        Uri = cloudBlobContainer.Uri
                    };
        }
    }
}