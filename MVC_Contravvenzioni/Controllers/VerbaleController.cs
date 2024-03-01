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
    public class VerbaleController : Controller
    {
        // GET: Verbale
        public ActionResult Index()
        {
            List<Verbale> listaVerbali = new List<Verbale>();
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Verbale";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Verbale v = new Verbale();
                    v.IDVerbale = Convert.ToInt16(reader["IDVerbale"]);
                    v.DataViolazione = Convert.ToDateTime(reader["DataViolazione"]);
                    v.IndirizzoViolazione = reader["IndirizzoViolazione"].ToString();
                    v.NominativoAgente = reader["NominativoAgente"].ToString();
                    v.DataTrascrizioneVerbale = Convert.ToDateTime(reader["DataTrascrizioneVerbale"]);
                    v.Importo = Convert.ToInt32(reader["Importo"]);
                    v.DecurtamentoPunti = Convert.ToInt32(reader["DecurtamentoPunti"]);
                    v.IDAnagrafica = Convert.ToInt32(reader["IDAnagrafica"]);
                    v.IDViolazione = Convert.ToInt16(reader["IDViolazione"]);
                    listaVerbali.Add(v);
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

            return View(listaVerbali);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Verbale v)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "INSERT INTO Verbale (IDVerbale, DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IDAnagrafica) VALUES (@IDVerbale, @DataViolazione, @IndirizzoViolazione, @NominativoAgente, @DataTrascrizioneVerbale, @Importo, @DecurtamentoPunti, @IDAnagrafica)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IDVerbale", v.IDVerbale);
                cmd.Parameters.AddWithValue("@DataViolazione", v.DataViolazione);
                cmd.Parameters.AddWithValue("@IndirizzoViolazione", v.IndirizzoViolazione);
                cmd.Parameters.AddWithValue("@NominativoAgente", v.NominativoAgente);
                cmd.Parameters.AddWithValue("@DataTrascrizioneVerbale", v.DataTrascrizioneVerbale);
                cmd.Parameters.AddWithValue("@Importo", v.Importo);
                cmd.Parameters.AddWithValue("@DecurtamentoPunti", v.DecurtamentoPunti);
                cmd.Parameters.AddWithValue("@IDAnagrafica", v.IDAnagrafica);
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