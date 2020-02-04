using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTubeAnalytics.v2;
using Google.Apis.Http;
using Google.Apis.Services;
using Andromeda.Common.Jobs;

namespace Jobs.Fetcher.YouTube {

    public class YouTubeFetchers : FetcherJobsFactory {

        public override JobScope Scope { get; } = JobScope.YouTube;

        public string CredentialsDir = "./credentials/youtube";
        public string SecretsFile = "./credentials/youtube/client_secret.json";

        public override IEnumerable<AbstractJob> GetJobs(JobType type, JobScope scope, IEnumerable<string> names, JobConfiguration jobConfiguration) {
            if (CheckTypeAndScope(type, scope)) {
                return NoJobs;
            }
            var jobs = new List<AbstractJob>();
            try {
                var credential = GetUserCredential(SecretsFile, CredentialsDir);
                var dataService = GetDataService(credential);
                var analyticsService = GetAnalyticsService(credential);

                jobs = new List<AbstractJob>() {
                    new VideosQuery(dataService),
                    new PlaylistsQuery(dataService),
                    new DailyVideoMetricsQuery(dataService, analyticsService),
                    new ViewerPercentageMetricsQuery(dataService, analyticsService),
                    new StatisticsQuery(dataService),
                    new ReprocessDailyVideoMetricsQuery(dataService, analyticsService),
                };
            }
            catch (Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException)
            {
                string message = String.Format("\nMissing or invalid YouTube credentials!\n{0}", e.Message);
                if (e is DirectoryNotFoundException) {
                    message = String.Format("{0}\nCheck if the path above exists!", message);
                }
                System.Console.WriteLine(message);
                Environment.Exit(1);
            };

            return FilterByName(jobs, names);
        }

        public static UserCredential GetUserCredential(string clientSecretFileName, string dataStoreFolder) {
            var scopes = new string[] {
                YouTubeService.Scope.YoutubeReadonly,
                YouTubeAnalyticsService.Scope.YoutubeReadonly,
                YouTubeAnalyticsService.Scope.YtAnalyticsMonetaryReadonly,
            };

            using (var stream = new FileStream(clientSecretFileName, FileMode.Open, FileAccess.Read)) {
                return GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    scopes,
                    "Credentials.json",
                    CancellationToken.None,
                    new FileDataStore(dataStoreFolder, true)
                    ).Result;
            }
        }

        public static YouTubeService GetDataService(IConfigurableHttpClientInitializer credential) {
            return new YouTubeService(new BaseClientService.Initializer() {
                HttpClientInitializer = credential,
                ApplicationName = "YouTube Daemon"
            });
        }

        public static YouTubeAnalyticsService GetAnalyticsService(IConfigurableHttpClientInitializer credential) {
            return new YouTubeAnalyticsService(new BaseClientService.Initializer() {
                HttpClientInitializer = credential,
                ApplicationName = "YouTube Daemon"
            });
        }
    }
}
