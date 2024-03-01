using MVC_Contravvenzioni.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Contravvenzioni.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            List<Persona> listaPersone = new List<Persona>();
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Anagrafica";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Persona p = new Persona();
                    p.IDAnagrafica = Convert.ToInt16(reader["IDAnagrafica"]);
                    p.Nome = reader["Nome"].ToString();
                    p.Cognome = reader["Cognome"].ToString();
                    p.Indirizzo = reader["Indirizzo"].ToString();
                    p.Citta = reader["Citta"].ToString();
                    p.Cap = reader["Cap"].ToString();
                    p.CodiceFiscale = reader["CodiceFiscale"].ToString();
                    listaPersone.Add(p);
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return View(listaPersone);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( Persona p )
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "INSERT INTO Anagrafica (Nome, Cognome, Indirizzo, Citta, Cap, CodiceFiscale) VALUES (@Nome, @Cognome, @Indirizzo, @Citta, @Cap, @CodiceFiscale)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IDAnagrafica", p.IDAnagrafica);
                cmd.Parameters.AddWithValue("@Nome", p.Nome);
                cmd.Parameters.AddWithValue("@Cognome", p.Cognome);
                cmd.Parameters.AddWithValue("@Indirizzo", p.Indirizzo);
                cmd.Parameters.AddWithValue("@Citta", p.Citta);
                cmd.Parameters.AddWithValue("@Cap", p.Cap);
                cmd.Parameters.AddWithValue("@CodiceFiscale", p.CodiceFiscale);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return RedirectToAction("Index");
        }
    }
}