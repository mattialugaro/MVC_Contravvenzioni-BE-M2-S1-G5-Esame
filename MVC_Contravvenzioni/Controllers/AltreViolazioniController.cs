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
    public class AltreViolazioniController : Controller
    {
        // GET: AltreViolazioni
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VerbaliPerTrasgressore()
        {
            List<Persona> listaVerbaliPerTrasgressore = new List<Persona>();
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "SELECT Nome, Cognome, COUNT(*) AS TotaleMulte FROM Anagrafica AS A INNER JOIN Verbale AS V On A.IDAnagrafica = V.IDAnagrafica GROUP BY Nome, Cognome";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Persona vpt = new Persona();
                    vpt.Nome = reader["Nome"].ToString();
                    vpt.Cognome = reader["Cognome"].ToString();
                    vpt.TotaleMulte = Convert.ToInt32(reader["TotaleMulte"]);
                    listaVerbaliPerTrasgressore.Add(vpt);
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

            return View(listaVerbaliPerTrasgressore);
        }
        
        public ActionResult PuntiDecurtatiPerTrasgressore()
        {
            List<Persona> listaPuntiDecurtatiPerTrasgressore = new List<Persona>();
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "SELECT Nome, Cognome, Sum(DecurtamentoPunti) AS TotalePunti FROM Anagrafica AS A INNER JOIN Verbale AS V On A.IDAnagrafica = V.IDAnagrafica GROUP BY Nome, Cognome";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Persona pdpt = new Persona();
                    pdpt.Nome = reader["Nome"].ToString();
                    pdpt.Cognome = reader["Cognome"].ToString();
                    pdpt.SommaPuntiDecurtati = Convert.ToInt32(reader["TotalePunti"]);
                    listaPuntiDecurtatiPerTrasgressore.Add(pdpt);
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

            return View(listaPuntiDecurtatiPerTrasgressore);
        }
        
        public ActionResult ViolazioniImportanti()
        {
            List<Persona> listaViolazioniImportanti = new List<Persona>();
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "SELECT  Nome, Cognome, Importo, DataViolazione, DecurtamentoPunti FROM Anagrafica AS A INNER JOIN Verbale AS V On A.IDAnagrafica = V.IDAnagrafica WHERE DecurtamentoPunti > 10 GROUP BY  Nome, Cognome, Importo, DataViolazione, DecurtamentoPunti";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Persona vi = new Persona();
                    vi.Nome = reader["Nome"].ToString();
                    vi.Cognome = reader["Cognome"].ToString();
                    vi.Importo = Convert.ToInt32(reader["Importo"]);
                    vi.DataViolazione = Convert.ToDateTime(reader["DataViolazione"]);
                    vi.PuntiDecurtati = Convert.ToInt32(reader["DecurtamentoPunti"]);
                    listaViolazioniImportanti.Add(vi);
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

            return View(listaViolazioniImportanti);
        }
        
        public ActionResult MulteSalate()
        {
            List<Verbale> listaMulteSalate = new List<Verbale>();
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "SELECT  * FROM Verbale WHERE Importo > 400";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Verbale ms = new Verbale();
                    ms.IDVerbale = Convert.ToInt16(reader["IDVerbale"]);
                    ms.DataViolazione = Convert.ToDateTime(reader["DataViolazione"]);
                    ms.IndirizzoViolazione = reader["IndirizzoViolazione"].ToString();
                    ms.NominativoAgente = reader["NominativoAgente"].ToString();
                    ms.DataTrascrizioneVerbale = Convert.ToDateTime(reader["DataTrascrizioneVerbale"]);
                    ms.Importo = Convert.ToInt32(reader["Importo"]);
                    ms.DecurtamentoPunti = Convert.ToInt32(reader["DecurtamentoPunti"]);
                    listaMulteSalate.Add(ms);
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

            return View(listaMulteSalate);
        }
    }
}