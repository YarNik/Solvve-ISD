using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
    public class GetReferendums
    {
        public int Id { get; set; }
        public string Proposition { get; set; }
        public string Appellation { get; set; }
        public int IdAnswer { get; set; }
        public int Amount { get; set; }
    }
    public class AllAnswer
    {
        public int IdAnswer { get; set; }
        public int IdUser { get; set; }
    }
    public class Referendum
    {
        public int Id { get; set; }
        public string Proposition { get; set; }
        public int Autor { get; set; }
        public int Active { get; set; }
        public int Published { get; set; }
        public int MaxOwnAnswers { get; set; }
        public int MaxAmountAnswers { get; set; }
        public string DeadLine { get; set; }
        public string PublishDate { get; set; }
    }
    public class ReceiveAllReferendums
    {
        public int Id { get; set; }
        public string Proposition { get; set; }
    }
    public class AddAnswer
    {
        public int Id { get; set; }
        public int Referendum { get; set; }
        public string Appellation { get; set; }
        public int AnswerAutor { get; set; }
    }

}