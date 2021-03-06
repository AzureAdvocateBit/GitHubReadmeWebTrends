﻿using Newtonsoft.Json;

namespace GitHubReadmeWebTrends.Common
{
    public class RepositoryConnectionResponse
    {
        public RepositoryConnectionResponse(User_RepositoryConnectionResponse user) => Repository = user.Repository;

        [JsonProperty("repository")]
        public Repository? Repository { get; }
    }

    public class User_RepositoryConnectionResponse
    {
        public User_RepositoryConnectionResponse(string login, Repository_RepositoryConnectionResponse? repository)
        {
            if (repository?.DefaultBranch != null)
                Repository = new Repository(repository.Id, login, repository.Name, repository.DefaultBranch, repository.IsFork);
        }

        [JsonProperty("repository")]
        public Repository? Repository { get; }
    }

    public class Repository_RepositoryConnectionResponse
    {
        public Repository_RepositoryConnectionResponse(string id, string name, bool isFork, DefaultBranchModel defaultBranchRef) =>
            (Id, Name, IsFork, DefaultBranch) = (id, name, isFork, defaultBranchRef);

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isFork")]
        public bool IsFork { get; set; }

        [JsonProperty("defaultBranchRef")]
        public DefaultBranchModel DefaultBranch { get; set; }
    }
}