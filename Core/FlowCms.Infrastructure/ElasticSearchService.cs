using Elastic.Clients.Elasticsearch;

namespace FlowCms.Infrastructure
{
    public class ElasticSearchService
    {
        private ElasticsearchClient _elasticClient;

        public ElasticSearchService(ElasticsearchClient settings)
        {
            _elasticClient = settings;
        }

        public ElasticsearchClient GetClient()
        {
            return _elasticClient;
        }
    }
}