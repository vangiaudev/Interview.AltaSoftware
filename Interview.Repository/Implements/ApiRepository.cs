using Interview.Infrastructure;
using Interview.Models.RequestModels;
using Interview.Models.ResponseModels;
using Interview.Repository.Interfaces;

namespace Interview.Repository.Implements
{
    public class ApiRepository : AbstractRepository<object, string>, IApiRepository
    {
        public async Task<int> InsertDataStudent(StudentInsertReq req)
        {
            try
            {
                var result = await base.Execute("SPA_Insert_Data_Student", new
                {
                    @TenHV = req.TenHV,
                    @Lop = req.Lop,
                    @TenMH = req.TenMH,
                    @Diem = req.Diem,
                    @HeSo = req.HeSo,
                    @NamHoc = req.NamHoc,
                });
                return result;
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<Scoreboard>> GetScoreboardList(string? Lop, int NamHoc)
        {
            try
            {
                var result = await base.Query<Scoreboard>("SPA_Get_Average_Scores_By_Class_And_Year", new
                {
                    @Lop = Lop,
                    @NamHoc = NamHoc
                });
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}