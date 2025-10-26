using SecondPartSolution.PersonEntities.Entities;
using SecondPartSolution.StudentBusinessLogic.Services;
using SecondPartSolution.PersonEntites.Enums;

namespace SecondPartSolution.StudentPresentation.Menus
{
    public class MainMenu
    {
        private readonly StudentService _studentService;

        public MainMenu(StudentService studentService)
        {
            _studentService = studentService;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Система управління студентами ===");
                Console.WriteLine("1. Переглянути статистику");
                Console.WriteLine("2. Додати студента");
                Console.WriteLine("3. Знайти студента");
                Console.WriteLine("4. Видалити студента");
                Console.WriteLine("5. Всі студенти");
                Console.WriteLine("6. Зберегти дані");
                Console.WriteLine("7. Завантажити дані");
                Console.WriteLine("8. Вихід");
                Console.Write("Оберіть опцію: ");

                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1": ShowStatistics(); break;
                        case "2": AddStudent(); break;
                        case "3": FindStudent(); break;
                        case "4": RemoveStudent(); break;
                        case "5": ShowAllStudents(); break;
                        case "6": SaveData(); break;
                        case "7": LoadData(); break;
                        case "8": return;
                        default: Console.WriteLine("Невірний вибір!"); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                }

                Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
            }
        }

        private void ShowStatistics()
        {
            var (percentage, students) = _studentService.GetFirstCourseFromOtherCitiesStats();

            Console.WriteLine($"\n=== Статистика студентів 1-го курсу ===");
            Console.WriteLine($"Відсоток студентів з інших міст: {percentage:F1}%");
            Console.WriteLine($"\nСтуденти 1-го курсу з інших міст:");
            foreach (var student in students)
            {
                Console.WriteLine($"- {student.FirstName} {student.LastName} з {student.City}");
            }
        }

        private void AddStudent()
        {
            Console.WriteLine("\n=== Додавання нового студента ===");

            var student = new Student();
            Console.Write("Прізвище: "); student.LastName = Console.ReadLine();
            Console.Write("Ім'я: "); student.FirstName = Console.ReadLine();
            Console.Write("Вік: "); student.Age = int.Parse(Console.ReadLine());
            Console.Write("Курс: "); student.Course = int.Parse(Console.ReadLine());
            Console.Write("Місто: "); student.City = Console.ReadLine();
            Console.Write("Студентський квиток (формат: AB123456): "); student.StudentId = Console.ReadLine();
            Console.Write("Паспорт (формат: KK654321): "); student.PassportId = Console.ReadLine();
            Console.Write("Додатковий навик: "); student.ExtraSkill = Console.ReadLine();

            student.ObjectType = "Student";
            student.ObjectName = "Студент";

            if (_studentService.AddStudent(student))
                Console.WriteLine("Студента успішно додано!");
            else
                Console.WriteLine("Помилка валідації даних!");
        }

        private void FindStudent()
        {
            Console.WriteLine("\n=== Пошук студента ===");
            Console.Write("Введіть номер студентського квитка: ");
            var studentId = Console.ReadLine();

            var student = _studentService.FindStudent(studentId);
            if (student != null)
            {
                Console.WriteLine($"\nЗнайдено студента:");
                Console.WriteLine($"Ім'я: {student.FirstName} {student.LastName}");
                Console.WriteLine($"Курс: {student.Course}");
                Console.WriteLine($"Місто: {student.City}");
                Console.WriteLine($"Студентський квиток: {student.StudentId}");
            }
            else
            {
                Console.WriteLine("Студент не знайдений!");
            }
        }

        private void RemoveStudent()
        {
            Console.WriteLine("\n=== Видалення студента ===");
            Console.Write("Введіть номер студентського квитка для видалення: ");
            var studentId = Console.ReadLine();

            if (_studentService.RemoveStudent(studentId))
                Console.WriteLine("Студента успішно видалено!");
            else
                Console.WriteLine("Студент не знайдений!");
        }

        private void ShowAllStudents()
        {
            Console.WriteLine("\n=== Всі студенти ===");

            var students = _studentService.GetAllStudents();

            if (!students.Any())
            {
                Console.WriteLine("Студентів немає!");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"- {student.FirstName} {student.LastName}, {student.Course} курс, {student.City}, квиток: {student.StudentId}");
            }
        }

        private void SaveData()
        {
            Console.WriteLine("\n=== Збереження даних ===");
            Console.WriteLine("Оберіть тип серіалізації:");
            Console.WriteLine("1. JSON");
            Console.WriteLine("2. XML");
            Console.WriteLine("3. Бінарна");
            Console.WriteLine("4. Користувацька");

            var typeChoice = Console.ReadLine();
            var type = typeChoice switch
            {
                "1" => SerializationType.Json,
                "2" => SerializationType.Xml,
                "3" => SerializationType.Binary,
                "4" => SerializationType.Custom,
                _ => SerializationType.Json
            };

            Console.Write("Введіть ім'я файлу: ");
            var fileName = Console.ReadLine();

            _studentService.SaveStudents(fileName, type);
            Console.WriteLine("Дані успішно збережено!");
        }

        private void LoadData()
        {
            Console.WriteLine("\n=== Завантаження даних ===");
            Console.WriteLine("Оберіть тип серіалізації:");
            Console.WriteLine("1. JSON");
            Console.WriteLine("2. XML");
            Console.WriteLine("3. Бінарна");
            Console.WriteLine("4. Користувацька");

            var typeChoice = Console.ReadLine();
            var type = typeChoice switch
            {
                "1" => SerializationType.Json,
                "2" => SerializationType.Xml,
                "3" => SerializationType.Binary,
                "4" => SerializationType.Custom,
                _ => SerializationType.Json
            };

            Console.Write("Введіть ім'я файлу: ");
            var fileName = Console.ReadLine();

            _studentService.LoadStudents(fileName, type);
            Console.WriteLine("Дані успішно завантажено!");
        }
    }
}