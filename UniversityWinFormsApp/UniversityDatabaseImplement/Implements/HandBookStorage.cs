using System;
using UniversityContracts.BindingModels;
using UniversityContracts.StorageContracts;
using UniversityContracts.ViewModels;
using UniversityDatabaseImplement.Models;

namespace UniversityDatabaseImplement.Implements
{
    public class HandBookStorage : IHandBookStorage
    {
        public List<HandBookViewModel> GetFullList()
        {
            using var context = new UniversityDatabase();
            return context.HandBooks
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public HandBookViewModel GetElement(HandBookBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new UniversityDatabase();
            var handBook = context.HandBooks
            .FirstOrDefault(rec => rec.Id == model.Id);
            return handBook != null ? CreateModel(handBook) : null;
        }
        public void Insert(HandBookBindingModel model)
        {
            using var context = new UniversityDatabase();
            context.HandBooks.Add(CreateModel(model, new HandBook()));
            context.SaveChanges();
        }
        public void Update(HandBookBindingModel model)
        {
            using var context = new UniversityDatabase();
            var element = context.HandBooks.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(HandBookBindingModel model)
        {
            using var context = new UniversityDatabase();
            HandBook element = context.HandBooks.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.HandBooks.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static HandBook CreateModel(HandBookBindingModel model, HandBook handBook)
        {
            handBook.Info = model.Info;
            return handBook;
        }
        private static HandBookViewModel CreateModel(HandBook handBook)
        {
            return new HandBookViewModel
            {
                Id = handBook.Id,
                Info = handBook.Info
            };
        }
    }
}
