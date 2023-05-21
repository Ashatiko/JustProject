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

            TimeSkills = new List<Question>
            {
                new Question()
                {
                    Choices = new List<string>{
                        "Я не планирую свой день, просто начинаю делать то, что мне нужно.",
                        "Я планирую свой день в начале рабочей недели.",
                        "Я планирую свой день каждый день.",
                        "Я не планирую свой день, я делаю то, что требуется в данный момент." },
                    CorrectChoiceIndex = 2,
                    Text = "Как вы обычно планируете свой рабочий день?",
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
                    Choices = new List<string>{
                        "Я делаю то, что мне нравится в первую очередь.",
                        "Я делаю то, что необходимо сделать в данный момент.",
                        "Я делаю задачи в порядке убывания их важности.",
                        "Я делаю задачи в порядке, который мне кажется наиболее эффективным."
                    },
                    CorrectChoiceIndex = 7,
                    Text = "Как вы обычно расставляете приоритеты задач?",
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
                    Choices = new List<string>{
                        "Я не обращаю внимания на прерывания, продолжая работать.",
                        "Я позволяю прерыванию отвлечь меня от задачи и переключиться на другую работу.",
                        "Я откладываю прерывание до тех пор, пока не завершу текущую задачу.",
                        "Я стараюсь быстро решить прерывающую задачу и вернуться к основной."
                    },
                    CorrectChoiceIndex = 11,
                    Text = "Как вы обычно реагируете на прерывания во время работы?",
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
                    Choices = new List<string>{
                        "Я работаю, пока не закончу все задачи.",
                        "Я работаю, пока не закончу все задачи.",
                        "Я заканчиваю свой рабочий день, когда наступает определенный момент времени.",
                        "Я заканчиваю свой рабочий день, когда заканчивается рабочее время."
                    },
                    CorrectChoiceIndex = 14,
                    Text = "Как вы обычно завершаете свой рабочий день?",
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

            CreationSkills = new List<Question>
            {
                new Question()
                {
                    Choices = new List<string>{
                        "Следую привычным шаблонам мышления.",
                        "Следую привычным шаблонам мышления.",
                        "Пытаюсь рассмотреть проблему с разных точек зрения и найти нестандартные решения.",
                        "Пытаюсь рассмотреть проблему с разных точек зрения и найти нестандартные решения." },
                    CorrectChoiceIndex = 3,
                    Text = "Как вы обычно решаете проблемы?",
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
                    Choices = new List<string>{
                        "Рассматриваю известные идеи и пытаюсь адаптировать их под свои нужды.",
                        "Обращаюсь к своему опыту и знаниям, чтобы сформулировать новую идею.",
                        "Провожу мозговой штурм с коллегами или друзьями.",
                        "Пытаюсь увидеть свою задачу в новом свете и подойти к решению с необычной стороны." },
                    CorrectChoiceIndex = 8,
                    Text = "Пытаюсь рассмотреть проблему с разных точек зрения и найти нестандартные решения.",
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
                    Choices = new List<string>{
                        "Отвергаю идеи, которые не соответствуют моим требованиям.",
                        "Сравниваю идеи с конкурирующими решениями и выбираю лучшее.",
                        "Сравниваю идеи с конкурирующими решениями и выбираю лучшее.",
                        "Пытаюсь дать себе время на размышление и анализирую идеи в долгосрочной перспективе." },
                    CorrectChoiceIndex = 11,
                    Text = "Как вы обычно оцениваете свои идеи?",
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
                    Choices = new List<string>{
                        "Как вы обычно преодолеваете творческий кризис?",
                        "Ищу вдохновение в работах других людей.",
                        "Меняю место работы или окружение, чтобы восстановить свою творческую энергию.",
                        "Меняю место работы или окружение, чтобы восстановить свою творческую энергию." },
                    CorrectChoiceIndex = 15,
                    Text = "Как вы обычно преодолеваете творческий кризис?",
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
