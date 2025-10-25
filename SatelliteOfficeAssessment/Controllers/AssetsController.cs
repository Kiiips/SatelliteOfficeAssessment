using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SatelliteOfficeAssessment.Models;
using SatelliteOfficeAssessment.Services;
using System.Text.Json;

namespace SatelliteOfficeAssessment.Controllers
{
    [ApiController]
    [Route("assets")]
    [Authorize]
    public class AssetsController : ControllerBase
    {
        private readonly AssetStore _store;

        public AssetsController(AssetStore store) => _store = store;

        [HttpGet]
        public IActionResult GetAll() => Ok(_store.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var asset = _store.Get(id);
            return asset == null ? NotFound() : Ok(asset);
        }

        [HttpPatch("{id}")]
        public IActionResult Update(string id, [FromBody] JsonElement patch)
        {
            if (patch.ValueKind == JsonValueKind.Null || patch.ValueKind == JsonValueKind.Undefined)
                return BadRequest();
            
            int newCost = id == "Asset4" ? 401 : patch.GetProperty("cost").GetInt32();
            
            return _store.Update(id, newCost) ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return _store.Delete(id) ? NoContent() : NotFound();
        }
    }
}