﻿using Storage.Blob;
using Storage.Interactor;

namespace Storage.Factory
{
    public class InteractorFactory
    {
        public static ContainerInteractor MakeContainerInteractor(string connectionString)
        {
            return new ContainerHelper(connectionString);
        }

        public static BlobInteractor MakeBlobInteractor(string connectionString)
        {
            return new BlobHelper(connectionString);
        }

        public static DirectoryInteractor MakeDirectoryInteractor(string connectionString)
        {
            return new DirectoryHelper(connectionString);
        }
    }
}
