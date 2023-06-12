using Interview.Models.RequestModels;
using Interview.Models.ResponseModels;

namespace Interview.Services.Interfaces
{
    public interface IApiServices
    {
        Task<int> InsertDataStudent(StudentInsertReq req);

        Task<IEnumerable<Scoreboard>> GetScoreboardList(string? Lop, int NamHoc);
    }
}