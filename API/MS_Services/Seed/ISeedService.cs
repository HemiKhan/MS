using MS_Models.Common;

namespace MS_Services.Seed
{
    public interface ISeedService
    {
        Task<Response<string>> SeederAsync();
    }
}
