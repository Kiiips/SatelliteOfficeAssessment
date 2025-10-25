using SatelliteOfficeAssessment.Models;

namespace SatelliteOfficeAssessment.Services
{
    public class AssetStore
    {
        private readonly Dictionary<string, Asset> _assets = new()
        {
            ["Asset1"] = new Asset { Name = "Asset1", Cost = 100 },
            ["Asset2"] = new Asset { Name = "Asset2", Cost = 200 },
            ["Asset3"] = new Asset { Name = "Asset3", Cost = 300 },
            ["Asset4"] = new Asset { Name = "Asset4", Cost = 400 },
            ["Asset5"] = new Asset { Name = "Asset5", Cost = 500 }
        };

        public IEnumerable<Asset> GetAll() => _assets.Values;

        public Asset? Get(string id) => _assets.TryGetValue(id, out var asset) ? asset : null;

        public bool Update(string id, int cost)
        {
            if (!_assets.ContainsKey(id)) return false;
            _assets[id].Cost = cost;
            return true;
        }

        public bool Delete(string id) => _assets.Remove(id);
    }
}