using BookingSystem.Data;
using BookingSystem.Model;

namespace BookingSystem.Services
{
    public class ResourceService : IResourceService
    {
        readonly AuthDbContext dbContext = new();
        public List<Resource> GetAllResources()
        {
            var result = from resources in dbContext.Resources
                         select resources;
            return result.ToList();
        }
        public Resource GetResourceById(int id)
        {
            var result = dbContext.Resources.SingleOrDefault(x => x.Id == id);

            return result;
        }
    }
}
