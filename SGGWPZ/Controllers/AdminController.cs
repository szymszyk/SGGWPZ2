using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGGWPZ.Repositories;
using SGGWPZ.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using SGGWPZ.ViewModels;

namespace SGGWPZ.Controllers
{
    public class AdminController : Controller
    {
        PlanContext Db;
        IUniversalRepositoryTypeOf uni;

        public AdminController(IUniversalRepositoryTypeOf UNI, PlanContext _DB)
        {
            uni = UNI;
            Db = _DB;
        }

        public IActionResult Index()
        {
            return View("New");
        }

        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public string InnerMessage { get; set; }

        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        [BindProperty]
        public dynamic Obiekt { get; set; }

        private string nazwaObiektu;
        //[BindProperty]
        //public string NazwaObiektu
        //{
        //    get { return SessionExt.Get<string>(HttpContext.Session, TabKeys.NazwaTabeli); }
        //}


        [BindProperty]
        public List<string> ListaKluczy { get; set; }

        [BindProperty]
        public List<string> ListaKluczyObcych { get; set; }

        [BindProperty]
        public List<string> ListaItemowDoDodania { get; set; }

        public IActionResult OnCreate(string co)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Obiekt = uni.Obiekt(co);
                    List<string> wartosci = new List<string>();
                    //ListaKluczyObcych = new List<string>();
                    ListaItemowDoDodania = new List<string>(); // Konstruktor

                    //IEnumerable<IForeignKey> foreignKeys = Db.Model.FindEntityType($"SGGWPZ.Models.{co}").GetForeignKeys();
                    //foreach (var foreignKey in foreignKeys)
                    //    ListaKluczyObcych.Add(foreignKey.PrincipalKey.ToString().Split(' ')[1].Split("PK")[0]);

                    ListaKluczy = uni.PartsOfAlternativeKey(Obiekt);

                    foreach (var item in Obiekt.GetType().GetProperties())
                    {
                        ListaItemowDoDodania.Add(item.Name);
                        wartosci.Add("");
                    }
                                   
                    ViewLista viewLista = new ViewLista(ListaItemowDoDodania, wartosci, co);
                    //Wykladowcy wykladowcy = new Wykladowcy();

                    return View("Create", viewLista);
                }
                catch (Exception ex) { Message = ex.Message; if (ex.InnerException != null) InnerMessage = ex.InnerException.Message.ToString(); return View(); }
            }
            return View("Lista",co);
        }

        public IActionResult OnCreateItem(string cos)
        {
            return View("Lista");
        }

        public IActionResult Lista(string co)
        {               
            Obiekt = uni.Obiekt(co);

            ListaItemowDoDodania = new List<string>();  
            foreach (var item in Obiekt.GetType().GetProperties())
                ListaItemowDoDodania.Add(item.Name);

            IEnumerable<dynamic> lista = uni.ReadAllT(uni.Obiekt(co));

            ViewLista viewLista = new ViewLista(ListaItemowDoDodania,lista,co);

            return View("View", viewLista);
        }
    }
}