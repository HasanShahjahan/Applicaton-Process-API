using Hahn.ApplicatonProcess.May2020.Api;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Xunit;

namespace Hahn.ApplicatonProcess.May2020.Domain.UnitTest
{
    public class ApplicantManagerUnitTest
    {
        private DependencyResolverHelpercs _serviceProvider;
        public ApplicantManagerUnitTest()
        {
            var webHost = WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            _serviceProvider = new DependencyResolverHelpercs(webHost);
        }
        [Fact]
        public void CreateApplicantAsync()
        {
            var applicantManager = _serviceProvider.GetService<IApplicantManager>();
        }
    }
}
