using BulletinsApi.MongoDB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulletinsAPI.Controllers
{
    public class BulletinsController: ControllerBase
    {
        private readonly MongoCollectionRepository _repository;

        public BulletinsController()
        {
            var database = new MongoDatabaseProvider().GetDatabase();
            _repository = new MongoCollectionRepository(database);
        }

        [HttpGet("api/bulletins")]
        public async Task<IEnumerable<BulletinsAPI.Models.Bulletin>> Get()
        {
            var bulletins = await _repository.GetList();
            return bulletins;
        }

        [HttpPost("api/bulletins")]
        public IActionResult Post([FromBody] Models.Bulletin bulletinObject)
        {
            if (bulletinObject == null)
            {
                return BadRequest();
            }

            bulletinObject.Id = Guid.NewGuid();
            _repository.Insert(bulletinObject);

            return Ok();
        }

        [HttpPatch("api/bulletins/{id}")]
        public IActionResult Update(Guid id, [FromBody] Models.Bulletin update)
        {
            _repository.Update(id, update);
            return Ok();
        }

        [HttpDelete("api/bulletins/{id}")]
        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        [HttpGet("api/bulletins/{id}")]
        public async Task<Models.Bulletin> Get(Guid id)
        {
            return await _repository.GetById(id);
        }
    }
}
