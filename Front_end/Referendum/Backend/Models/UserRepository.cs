using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WebServer.Models
{
    public interface IUserRepository
    {
        void Create(User user);
        void Delete(int id);
        User Get(int id);
        List<GetReferendums> GetReferendumsDb();
        List<ReceiveAllReferendums> ReceiveAllReferendumsDb();
        void Vote(AllAnswer answer);
        void AddReferendum(Referendum referendum);
        void SaveNewAnswer(AddAnswer answer);
        void Update(User user);
    }
    public class UserRepository : IUserRepository
    {
        string connectionString = null;
        public UserRepository(string conn)
        {
            connectionString = conn;
        }
        
        public List<GetReferendums> GetReferendumsDb()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<GetReferendums>("SELECT Referendum.Id, Referendum.Proposition, Answer.Appellation, Answer.id as IdAnswer, COUNT(*) - 1 as Amount FROM Referendum, Answer, AllAnswers WHERE Answer.Referendum = Referendum.id AND AllAnswers.idAnswer = Answer.id GROUP BY Answer.id, Answer.Appellation, Referendum.Proposition, Referendum.Id").ToList();
            }
        }

        public void Vote(AllAnswer answer)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO AllAnswers VALUES(@IdAnswer, @IdUser)";
                db.Execute(sqlQuery, answer);
            }
        }

        public void AddReferendum(Referendum referendum)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Referendum VALUES(@Proposition, @Autor, @Active, @Published, @MaxOwnAnswers, @MaxAmountAnswers, @DeadLine, @PublishDate)";
                db.Execute(sqlQuery, referendum);
            }
        }

        public List<ReceiveAllReferendums> ReceiveAllReferendumsDb()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<ReceiveAllReferendums>("SELECT Referendum.Id, Referendum.Proposition FROM Referendum").ToList();
            }
        }

        public void SaveNewAnswer(AddAnswer answer)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Answer VALUES(@Referendum, @Appellation, @AnswerAutor); SELECT CAST(SCOPE_IDENTITY() as int)";
                int? answerId = db.Query<int>(sqlQuery, answer).FirstOrDefault();
                answer.Id = answerId.Value;
                var sqlQuery2 = "INSERT INTO AllAnswers VALUES(@Id, 1)";
                db.Execute(sqlQuery2, answer);
            }
        }

        public User Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Users (userName) VALUES(@UserName)";
                db.Execute(sqlQuery, user);
            }
        }

        public void Update(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id";
                db.Execute(sqlQuery, user);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Users WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}