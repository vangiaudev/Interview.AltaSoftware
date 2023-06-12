using Interview.Models.RequestModels;
using Interview.Models.ResponseModels;
using Interview.Repository.Interfaces;
using Interview.Services.Interfaces;

namespace Interview.Services.Implements
{
    public class ApiServices : IApiServices
    {
        private readonly IApiRepository _repo;
        public ApiServices(IApiRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Scoreboard>> GetScoreboardList(string? Lop, int NamHoc)
        {
            try
            {
                var result = await _repo.GetScoreboardList(Lop, NamHoc);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> InsertDataStudent(StudentInsertReq req)
        {
            try
            {
                var result = await _repo.InsertDataStudent(req);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}