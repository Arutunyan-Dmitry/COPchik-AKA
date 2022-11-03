using UniversityContracts.BindingModels;
using UniversityContracts.StorageContracts;
using UniversityContracts.ViewModels;
using UniversityDatabaseImplement.Models;

namespace UniversityDatabaseImplement.Implements
{
    public class StudentStorage : IStudentStorage
    {
        public List<StudentViewModel> GetFullList()
        {
            using var context = new UniversityDatabase();
            return context.Students
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public List<StudentViewModel> GetFilteredList(StudentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new UniversityDatabase();
            return context.Students
            .Where(rec => (model.Scholatship.HasValue && rec.Scholatship > model.Scholatship) ||
            (model.Grade.Equals(rec.Grade) && rec.Scholatship != null))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public StudentViewModel GetElement(StudentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new UniversityDatabase();
            var student = context.Students
            .FirstOrDefault(rec => rec.Id == model.Id);
            return student != null ? CreateModel(student) : null;
        }
        public void Insert(StudentBindingModel model)
        {
            using var context = new UniversityDatabase();
            context.Students.Add(CreateModel(model, new Student()));
            context.SaveChanges();
        }
        public void Update(StudentBindingModel model)
        {
            using var context = new UniversityDatabase();
            var element = context.Students.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(StudentBindingModel model)
        {
            using var context = new UniversityDatabase();
            Student element = context.Students.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Students.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Student CreateModel(StudentBindingModel model, Student student)
        {
            student.Flm = model.Flm;
            student.ShortCharacteristic = model.ShortCharacteristic;
            student.Grade = model.Grade;
            student.Scholatship = model.Scholatship;
            return student;
        }
        private static StudentViewModel CreateModel(Student student)
        {
            return new StudentViewModel
            {
                Id = student.Id,
                Flm = student.Flm,
                ShortCharacteristic = student.ShortCharacteristic,
                Grade = student.Grade,
                Scholatship = student.Scholatship
            };
        }
    }
}
