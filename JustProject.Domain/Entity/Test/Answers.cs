using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Domain.Entity.Test
{
    public class Answers
    {
        public int AnswersId { get; set; }
        public string AnswersText { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionsId { get; set; }
    }
}
