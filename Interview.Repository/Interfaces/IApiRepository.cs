using Interview.Models.RequestModels;
using Interview.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Repository.Interfaces
{
    public interface IApiRepository
    {
        Task<int> InsertDataStudent(StudentInsertReq req);
        Task<IEnumerable<Scoreboard>> GetScoreboardList(string? Lop, int NamHoc);
    }
}
