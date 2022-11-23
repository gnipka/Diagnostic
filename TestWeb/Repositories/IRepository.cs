using System.Collections.Generic;
using TestWeb.Models;

namespace TestWeb.Repositories
{
    public interface IRepository<T>
    {

        /// <summary>
        /// Добавление элемента в бд
        /// </summary>
        /// <param name="item">Экземпляр класса</param>
        public void Create(T item);

        /// <summary>
        /// Просмотр элемента по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(int id);

        public List<T> GetAll();


        /// <summary>
        /// Обновление данных
        /// </summary>
        /// <param name="item"></param>
        public void Update(T item);

        /// <summary>
        /// Удаление по экземпляру класса
        /// </summary>
        /// <param name="item"></param>
        public void Delete(T item);

        /// <summary>
        /// Удаление по id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id);
    }
}
