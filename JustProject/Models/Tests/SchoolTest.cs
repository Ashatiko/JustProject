namespace JustProject.Models.Tests
{
    public class SchoolTest
    {
        public static TestsViewModel TestsViewModel { get; set; } = new TestsViewModel()
        {
            AnalyticSkills = new List<Question>
            {
                new Question()
                {
                    Choices = new List<string>{ 
                        "Все буквы \"А\" - это буквы \"С\"",
                        "Все C - это B",
                        "Некоторые \"А\" - это \"С\"",
                        "Никакие \"А\" не являются \"С\"" },
                    CorrectChoiceIndex = 1,
                    Text = "Если все A - это B, а все B - это C, то какое из следующих утверждений должно быть истинным?",
                    NumberQuestion = "first",
                    IdQuestion = new List<string>
                    {
                        "1",
                        "2",
                        "3",
                        "4",
                    },
                    
                },
                new Question()
                {
                    Choices = new List<string>{ "30", "36", "49", "64" },
                    CorrectChoiceIndex = 6,
                    Text = "Какое следующее число в следующей последовательности: 1, 4, 9, 16, 25, ...?",
                    NumberQuestion = "second",
                    IdQuestion = new List<string>
                    {
                        "5",
                        "6",
                        "7",
                        "8",
                    }
                },
                new Question()
                {
                    Choices = new List<string>{ "Яблоко", "Оранжевый", "Виноград", "Банан" },
                    CorrectChoiceIndex = 10,
                    Text = "Какое из следующих слов не относится к остальным?",
                    NumberQuestion = "third",
                    IdQuestion = new List<string>
                    {
                        "9",
                        "10",
                        "11",
                        "12",
                    }
                },
                new Question()
                {
                    Choices = new List<string>{ "Рыцарь", "Ладья", "Епископ", "Королева" },
                    CorrectChoiceIndex = 14,
                    Text = "В игре в шахматы какая фигура может двигаться только по диагонали?",
                    NumberQuestion = "fourth",
                    IdQuestion = new List<string>
                    {
                        "13",
                        "14",
                        "15",
                        "16",
                    }
                }
            },

            VerbalSkills = new List<Question>
            {
                new Question()
                {
                    Choices = new List<string>{
                        "Незнакомое, необычное",
                        "Давно забытое, устаревшее",
                        "Необходимое, обязательное",
                        "Неоднозначное, двусмысленное" },
                    CorrectChoiceIndex = 1,
                    Text = "Что означает слово \"экзотика\"?",
                    NumberQuestion = "first",
                    IdQuestion = new List<string>
                    {
                        "1",
                        "2",
                        "3",
                        "4",
                    },

                },
                new Question()
                {
                    Choices = new List<string>{ "Многогранный", "Примитивный", "Комплексный", "Узкоспециализированный" },
                    CorrectChoiceIndex = 7,
                    Text = "Какое слово является синонимом слова \"универсальный\"?",
                    NumberQuestion = "second",
                    IdQuestion = new List<string>
                    {
                        "5",
                        "6",
                        "7",
                        "8",
                    }
                },
                new Question()
                {
                    Choices = new List<string>{ "Порядок", "Жестокость", "Волна", "Безумие" },
                    CorrectChoiceIndex = 9,
                    Text = "Какое слово является антонимом слова \"хаос\"?",
                    NumberQuestion = "third",
                    IdQuestion = new List<string>
                    {
                        "9",
                        "10",
                        "11",
                        "12",
                    }
                },
                new Question()
                {
                    Choices = new List<string>{ "Слушать внимательно", "Изображать, что слушаешь", "Рассказывать о своих проблемах", "Прятать что-то" },
                    CorrectChoiceIndex = 13,
                    Text = "Что означает идиома \"держать ухо востро\"?",
                    NumberQuestion = "fourth",
                    IdQuestion = new List<string>
                    {
                        "13",
                        "14",
                        "15",
                        "16",
                    }
                }
            },
        };
    }
}
