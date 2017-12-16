﻿using System;
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

        public async Task<T> CreateTAsync<T>(T newT) where T : class
        {
            await db.Set<T>().AddAsync(newT);     
            await db.SaveChangesAsync();

            return newT;
        }

        public async Task<bool> DeleteTAsync<T>(int ID, T Titem) where T : class
        {
            //throw new NotImplementedException();

            var nazwaId = PartsOfPrimaryKey(Titem)[0];
            var deletedT = await db.Set<T>().FirstOrDefaultAsync(a => (int)a.GetType().GetProperty(nazwaId).GetValue(a) == ID);

            if (deletedT != null)
            {

                db.Set<T>().Remove(deletedT);
                //db.SaveChanges();
                await db.SaveChangesAsync();
            }

            return (db.Set<T>().FirstOrDefault(a => (int)a.GetType().GetProperty(nazwaId).GetValue(a) == ID) == null);
        }

        public List<string> ListOfProperties<T>(T obiektT) where T : class
        {
            //throw new NotImplementedException();
            List<string> listWlasci = new List<string>();

            foreach (var item in obiektT.GetType().GetProperties())
            {
                listWlasci.Add(item.Name);
            }

            return listWlasci;
        }

        public dynamic Obiekt(string nazwaTabeli) => Activator.CreateInstance(Type.GetType($"SGGWPZ.Models.{nazwaTabeli}"));


        /// <summary>
        /// Pobierz klucze alternatywne obiektu
        /// </summary>
        /// <typeparam name="T1">Generyczny T</typeparam>
        /// <param name="obiekt"></param>
        /// <returns></returns>
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
            //throw new NotImplementedException();

            List<string> listaKluczy = new List<string>();

            foreach (var item in db.Model.FindEntityType($"SGGWPZ.Models.{obiekt.GetType().Name}").FindPrimaryKey().Properties.ToList())
                listaKluczy.Add(item.Name);

            return listaKluczy;
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

        public async Task<List<T>> ReadAllTAsync<T>(T item) where T : class
        {
            //throw new NotImplementedException();
            return await db.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> ReadTAsync<T>(int ID, T Tiem) where T : class //bylo bez string nazwaId
        {
            var nazwaId = PartsOfPrimaryKey(Tiem)[0];
            return await db.Set<T>().AsNoTracking().FirstOrDefaultAsync(i => (int)i.GetType().GetProperty(nazwaId).GetValue(i) == ID); // bylo Id
        }

        public List<T1> SortujPo<T1>(string PoCzymSortuj, T1 Tiem) where T1 : class
        {
            throw new NotImplementedException();
        }

        public T1 SprawdzCzyIstniejeWBazie<T1>(T1 obiekt) where T1 : class
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateTAsync<T>(T updatedT) where T : class
        {
            //throw new NotImplementedException();

            var nazwaId = PartsOfPrimaryKey(updatedT)[0];
            var orginalT = await db.Set<T>().FirstOrDefaultAsync(p => (int)p.GetType().GetProperty(nazwaId).GetValue(p) == (int)updatedT.GetType().GetProperty(nazwaId).GetValue(updatedT));

            foreach (var item in updatedT.GetType().GetProperties()) //Przepisuje wszystkie Wlasciwosci
            {
                orginalT.GetType().GetProperty(item.Name).SetValue(
                    orginalT,
                    item.GetValue(updatedT)
                    );
            }

            //db.SaveChanges();
            await db.SaveChangesAsync();

            return orginalT;
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

