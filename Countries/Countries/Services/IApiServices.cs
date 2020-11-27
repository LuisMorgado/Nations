namespace Countries.Services
{
    using Countries.Models;
    using System.Threading.Tasks;


    public interface IApiServices
    {
        /// <summary>
        /// Get list of objects from API 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="urlBase"></param>
        /// <param name="controller"></param>
        /// <returns></returns>
        Task<Response> GetListAsync<T>(string urlBase, string controller);
    }
}
