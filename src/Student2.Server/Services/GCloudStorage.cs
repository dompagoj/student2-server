using System;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Student2.Server.Models;

namespace Student2.Server.Services
{
    public class GCloudStorage : IDisposable
    {
        readonly string _projectId;
        IWebHostEnvironment _env;
        StorageClient _client;

        public GCloudStorage(IOptions<GCloudSettings> options, IWebHostEnvironment env)
        {
            _projectId = options.Value.ProjectId;
            _client = env.IsDevelopment()
                ? StorageClient.Create(GoogleCredential.FromFile(options.Value.ApplicationCredentials))
                : StorageClient.Create();
            _env = env;
        }
        // public async Task UploadToBucket()
        // {
        //
        // }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
