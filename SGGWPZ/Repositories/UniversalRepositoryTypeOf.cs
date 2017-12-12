using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGGWPZ.Models;

namespace SGGWPZ.Repositories
{
    public class UniversalRepositoryTypeOf : IUniversalRepositoryTypeOf
    {
        private PlanContext db;

        public UniversalRepositoryTypeOf(PlanContext planContext)
        {
            db = planContext;
        }

        public Task<T1> CreateTAsync<T1>(T1 newT) where T1 : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTAsync<T1>(int ID, T1 Titem) where T1 : class
        {
            throw new NotImplementedException();
        }

        public List<string> ListOfProperties<T1>(T1 obiektT) where T1 : class
        {
            throw new NotImplementedException();
        }

        //public dynamic Obiekt(string nazwaTabeli)
        //{
        //    throw new NotImplementedException();
        //}

        public dynamic Obiekt(string nazwaTabeli) => Activator.CreateInstance(Type.GetType($"SGGWPZ.Models.{nazwaTabeli}"));

        public List<string> PartsOfAlternativeKey<T1>(T1 obiekt) where T1 : class
        {
            //throw new NotImplementedException();

            List<string> listaKluczy = new List<string>();

            foreach (var item in db.Model.FindEntityType($"SGGWPZ.Models.{obiekt.GetType().Name}").FindPrimaryKey().Properties.ToList())
                listaKluczy.Add(item.Name);

            return listaKluczy;
        }

        public List<string> PartsOfPrimaryKey<T1>(T1 obiekt) where T1 : class
        {
            throw new NotImplementedException();
        }

        public List<dynamic> PobierzTablice(string nazwaTablicy)
        {
            throw new NotImplementedException();
        }

        public string PolecenieStworzeniaPierwszegoElementuWTablicy(string NazwaTabeli)
        {
            throw new NotImplementedException();
        }

        public List<T> ReadAllT<T>(T item) where T : class
        {
            //throw new NotImplementedException();
            return db.Set<T>().ToList();
        }

        public Task<List<T1>> ReadAllTAsync<T1>(T1 item) where T1 : class
        {
            throw new NotImplementedException();
        }

        public async Task<T> ReadTAsync<T>(int ID, T Tiem) where T : class
        {
            return await db.Set<T>().AsNoTracking().FirstOrDefaultAsync(i => (int)i.GetType().GetProperty("Id").GetValue(i) == ID);
        }

        public List<T1> SortujPo<T1>(string PoCzymSortuj, T1 Tiem) where T1 : class
        {
            throw new NotImplementedException();
        }

        public T1 SprawdzCzyIstniejeWBazie<T1>(T1 obiekt) where T1 : class
        {
            throw new NotImplementedException();
        }

        public Task<T1> UpdateTAsync<T1>(T1 updatedT) where T1 : class
        {
            throw new NotImplementedException();
        }

        public List<T1> WszystkieOpcje<T1>(string PoCzym, string Nazwa, string PoCzymSortuj, T1 Titem) where T1 : class
        {
            throw new NotImplementedException();
        }

        public List<T1> WyszukajPoSymbolu<T1>(string PoCzym, string Nazwa, T1 Tiem) where T1 : class
        {
            throw new NotImplementedException();
        }
    }
}

