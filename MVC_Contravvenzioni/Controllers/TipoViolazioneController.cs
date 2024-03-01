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
    public class TipoViolazioneController : Controller
    {
        // GET: TipoViolazione
        public ActionResult Index()
        {
            List<TipoViolazione> listaTipiViolazione = new List<TipoViolazione>();
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "SELECT * FROM TipoViolazione WHERE Contestabile = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TipoViolazione tv = new TipoViolazione();
                    tv.IDViolazione = Convert.ToInt16(reader["IDViolazione"]);
                    tv.Descrizione = reader["Descrizione"].ToString();
                    tv.IDAnagrafica = Convert.ToInt32(reader["IDAnagrafica"]);
                    tv.Contestabile = Convert.ToBoolean(reader["Contestabile"]);
                    listaTipiViolazione.Add(tv);
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

            return View(listaTipiViolazione);
        }

        public ActionResult NonContestabili()
        {
            List<TipoViolazione> listaTipiViolazioneNon = new List<TipoViolazione>();
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "SELECT * FROM TipoViolazione WHERE Contestabile = 0";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TipoViolazione tv = new TipoViolazione();
                    tv.IDViolazione = Convert.ToInt16(reader["IDViolazione"]);
                    tv.Descrizione = reader["Descrizione"].ToString();
                    tv.IDAnagrafica = Convert.ToInt32(reader["IDAnagrafica"]);
                    tv.Contestabile = Convert.ToBoolean(reader["Contestabile"]);
                    listaTipiViolazioneNon.Add(tv);
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

            return View(listaTipiViolazioneNon);
        }
    }
}