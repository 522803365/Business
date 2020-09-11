
using Business.BackgroundJobs.jobs.Data;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ControlCenterServices.BackgroundJobs
{
   public static class BusinessBackgroundJobsExtensions
    {
        public static void UseDataSynchronizationjob(this IServiceProvider service)
        {
            var job = service.GetService<DataSynchronizationjob>();

            BackgroundJob.Enqueue(() => job.ExecuteAsync());
        }
    }
}
