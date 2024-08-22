using FlowCms.Core.Models;
using FlowCms.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FlowCms.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ElasticController : ControllerBase
    {
        private readonly ElasticSearchService _elasticClient;

        public ElasticController(ElasticSearchService elasticClient)
        {
            _elasticClient = elasticClient;
        }

        [HttpGet]
        public async Task<IActionResult> CreateIndex()
        {
            try
            {
                var response = await _elasticClient.GetClient().Indices.CreateAsync("projects1");

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> IndexDocument(Project document)
        {
            try
            {
                var client = _elasticClient.GetClient();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var client = _elasticClient.GetClient();

                var response = await client.SearchAsync<Project>(s => s
                .Index("projects1")
                .Query(q => q.Match(mq => mq
                .Field(f => f.Title))));

                return Ok(response.Documents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            try
            {
                var client = _elasticClient.GetClient();

                var response = await client.SearchAsync<Project>(s => s
                .Index("projects1")
                .Query(q => q.Match(mq => mq
                .Field(f => f.Title)
                .Query(query))));

                return Ok(response.Documents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}