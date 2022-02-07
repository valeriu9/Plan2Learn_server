using BookingSystem.Model;

namespace BookingSystem.Services
{
    public interface IResourceService
    {
        List<Resource> GetAllResources();

        Resource GetResourceById(int id);
    }
}
