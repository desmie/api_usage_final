using Microsoft.AspNetCore.Mvc;
using API_Usage.DataAccess;
using API_Usage.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

/*
 * Acknowledgments
 *  v1 of the project was created for the Fall 2018 class by Dhruv Dhiman, MS BAIS '18
 *    This example showed how to use v1 of the IEXTrading API
 *    
 *  Kartikay Bali (MS BAIS '19) extended the project for Spring 2019 by demonstrating 
 *    how to use similar methods to access Azure ML models
*/

namespace API_Usage.Controllers
{
  public class HomeController : Controller
  {
    public ApplicationDbContext dbContext;

    //Base URL for the IEXTrading API. Method specific URLs are appended to this base URL.
    string BASE_URL = "https://api.iextrading.com/1.0/";
    HttpClient httpClient;

   
    public HomeController(ApplicationDbContext context)
    {
      dbContext = context;

      httpClient = new HttpClient();
      httpClient.DefaultRequestHeaders.Accept.Clear();
      httpClient.DefaultRequestHeaders.Accept.Add(new
          System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    }

    public IActionResult Index()
    {
      return View();
    }

    
    public IActionResult Symbols()
    {
      //Set ViewBag variable first
      ViewBag.dbSucessComp = 0;
      List<Company> companies = GetSymbols();

      //Save companies in TempData, so they do not have to be retrieved again
      TempData["Companies"] = JsonConvert.SerializeObject(companies);
      //TempData["Companies"] = companies;

      return View(companies);
    }
        public IActionResult History()
        {
            //Set ViewBag variable first
            ViewBag.dbSucessComp = 0;
            List<Historical_Summary> history = GetHistorical();

            
            TempData["History"] = JsonConvert.SerializeObject(history);
            

            return View(history);
        }

        public IActionResult Gainers()
        {
            
            ViewBag.dbSucessComp = 0;
            List<Gainers_Model> gainers = GetGainers();

            
            TempData["Gainers"] = JsonConvert.SerializeObject(gainers);
            

            return View(gainers);
        }

        public IActionResult InFocus()
        {
            
            ViewBag.dbSucessComp = 0;
            List<Infocus_Model> inFocus = GetInFocus();

            
            TempData["InFocus"] = JsonConvert.SerializeObject(inFocus);
           
            return View(inFocus);
        }
        public IActionResult SectorPerformance()
        {
            
            ViewBag.dbSucessComp = 0;
            List<SectorPerformance_Model> performance = GetSectorPerformance();

           
            TempData["SectorPerform"] = JsonConvert.SerializeObject(performance);
          

            return View(performance);
        }

        public IActionResult Dividend()
        {
            
            ViewBag.dbSucessComp = 0;
            List<Dividend_Model> div = GetDividend();
            
            TempData["Dividend"] = JsonConvert.SerializeObject(div);
            
            return View(div);
        }

        public IActionResult News()
        {
           
            ViewBag.dbSucessComp = 0;
            List<News_Model> news = GetNews();
            TempData["News"] = JsonConvert.SerializeObject(news);

            return View(news);
        }

        
        public IActionResult Chart(string symbol)
      {
      
      ViewBag.dbSuccessChart = 0;
      List<Equity> equities = new List<Equity>();

      if (symbol != null)
      {
        equities = GetChart(symbol);
        equities = equities.OrderBy(c => c.date).ToList(); //Make sure the data is in ascending order of date.
      }

      CompaniesEquities companiesEquities = getCompaniesEquitiesModel(equities);

      return View(companiesEquities);
    }

    
    public List<Company> GetSymbols()
    {
      string IEXTrading_API_PATH = BASE_URL + "ref-data/symbols";
      string companyList = "";
      List<Company> companies = null;

      
      httpClient.BaseAddress = new Uri(IEXTrading_API_PATH);
      HttpResponseMessage response = httpClient.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();

      // read the Json objects in the API response
      if (response.IsSuccessStatusCode)
      {
        companyList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
      }

      // now, parse the Json strings as C# objects
      if (!companyList.Equals(""))
      {
        // https://stackoverflow.com/a/46280739
        //JObject result = JsonConvert.DeserializeObject<JObject>(companyList);
        companies = JsonConvert.DeserializeObject<List<Company>>(companyList);
        companies = companies.GetRange(0, 50);
      }

      return companies;
    }

        public List<Gainers_Model> GetGainers()
        {
            string IEXTrading_Gainers_API_PATH = BASE_URL + "stock/market/list/gainers";
            string gainersList = "";
            List<Gainers_Model> gainers = null;

           
            httpClient.BaseAddress = new Uri(IEXTrading_Gainers_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_Gainers_API_PATH).GetAwaiter().GetResult();

            
            if (response.IsSuccessStatusCode)
            {
                gainersList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            
            if (!gainersList.Equals(""))
            {
                gainers = JsonConvert.DeserializeObject<List<Gainers_Model>>(gainersList);
                
            }

            return gainers;
        }

        public List<Infocus_Model> GetInFocus()
        {
            string IEXTrading_Infocus_API_PATH= BASE_URL + "stock/market/list/infocus";
            string inFocusList = "";
            List<Infocus_Model> inFocus = null;

            
            httpClient.BaseAddress = new Uri(IEXTrading_Infocus_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_Infocus_API_PATH).GetAwaiter().GetResult();

           
            if (response.IsSuccessStatusCode)
            {
                inFocusList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

           
            if (!inFocusList.Equals(""))
            {
                // https://stackoverflow.com/a/46280739
               
                inFocus = JsonConvert.DeserializeObject<List<Infocus_Model>>(inFocusList);
                
            }

            return inFocus;
        }


        public List<Historical_Summary> GetHistorical()
        {
            string IEXTrading_History_Infocus_API_PATH = BASE_URL + "stats/historical";
            string historyList = "";
            List<Historical_Summary> history = null;

            
            httpClient.BaseAddress = new Uri(IEXTrading_History_Infocus_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_History_Infocus_API_PATH).GetAwaiter().GetResult();

            
            if (response.IsSuccessStatusCode)
            {
                historyList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

           
            if (!historyList.Equals(""))
            {
                // https://stackoverflow.com/a/46280739
                
                history = JsonConvert.DeserializeObject<List<Historical_Summary>>(historyList);
              
            }

            return history;
        }


        public List<SectorPerformance_Model> GetSectorPerformance()
        {
            string IEXTrading_SectorPerformance_API_PATH = BASE_URL + "stock/market/sector-performance";
            string sectorPerformanceList = "";
            List<SectorPerformance_Model> performance = null;

            
            httpClient.BaseAddress = new Uri(IEXTrading_SectorPerformance_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_SectorPerformance_API_PATH).GetAwaiter().GetResult();

            
            if (response.IsSuccessStatusCode)
            {
                sectorPerformanceList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            
            if (!sectorPerformanceList.Equals(""))
            {
                // https://stackoverflow.com/a/46280739
                
                performance = JsonConvert.DeserializeObject<List<SectorPerformance_Model>>(sectorPerformanceList);
                
            }

            return performance;
        }
        public List<Dividend_Model> GetDividend()
        {
            string IEXTrading_Dividend_API_PATH = BASE_URL + "stock/aapl/dividends/1y";
            string dividendList = "";
            List<Dividend_Model> div = null;

           
            httpClient.BaseAddress = new Uri(IEXTrading_Dividend_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_Dividend_API_PATH).GetAwaiter().GetResult();

            
            if (response.IsSuccessStatusCode)
            {
                dividendList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            
            if (!dividendList.Equals(""))
            {
                // https://stackoverflow.com/a/46280739
               
                div = JsonConvert.DeserializeObject<List<Dividend_Model>>(dividendList);
                
            }

            return div;
        }
        
        public List<News_Model> GetNews()
        {
            string IEXTrading_News_API_PATH = BASE_URL + "stock/aapl/news";
            string newsList = "";
            List<News_Model> news = null;

            
            httpClient.BaseAddress = new Uri(IEXTrading_News_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_News_API_PATH).GetAwaiter().GetResult();

            
            if (response.IsSuccessStatusCode)
            {
                newsList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            
            if (!newsList.Equals(""))
            {
                // https://stackoverflow.com/a/46280739
                
                news = JsonConvert.DeserializeObject<List<News_Model>>(newsList);
               
            }

            return news;
        }

        public List<Equity> GetChart(string symbol)
    {
      
      string IEXTrading_API_PATH = BASE_URL + "stock/" + symbol + "/batch?types=chart&range=1y";

     
      string charts = "";
      List<Equity> Equities = new List<Equity>();
      httpClient.BaseAddress = new Uri(IEXTrading_API_PATH);

      // connect to the API and obtain the response
      HttpResponseMessage response = httpClient.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();

      // now, obtain the Json objects in the response as a string
      if (response.IsSuccessStatusCode)
      {
        charts = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
      }

      // parse the string into appropriate objects
      if (!charts.Equals(""))
      {
        ChartRoot root = JsonConvert.DeserializeObject<ChartRoot>(charts,
          new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        Equities = root.chart.ToList();
      }

      // fix the relations. By default the quotes do not have the company symbol
      //  this symbol serves as the foreign key in the database and connects the quote to the company
      foreach (Equity Equity in Equities)
      {
        Equity.symbol = symbol;
      }

      return Equities;
    }

    /// <summary>
    /// Call the ClearTables method to delete records from a table or all tables.
    ///  Count of current records for each table is passed to the Refresh View
    /// </summary>
    /// <param name="tableToDel">Table to clear</param>
    /// <returns>Refresh view</returns>
    public IActionResult Refresh(string tableToDel)
    {
      ClearTables(tableToDel);
      Dictionary<string, int> tableCount = new Dictionary<string, int>();
      tableCount.Add("Companies", dbContext.Companies.Count());
      tableCount.Add("Charts", dbContext.Equities.Count());
      return View(tableCount);
    }

    /// <summary>
    /// save the quotes (equities) in the database
    /// </summary>
    /// <param name="symbol">Company whose quotes are to be saved</param>
    /// <returns>Chart view for the company</returns>
    public IActionResult SaveCharts(string symbol)
    {
      List<Equity> equities = GetChart(symbol);

      // save the quote if the quote has not already been saved in the database
      foreach (Equity equity in equities)
      {
        if (dbContext.Equities.Where(c => c.date.Equals(equity.date)).Count() == 0)
        {
          dbContext.Equities.Add(equity);
        }
      }

      // persist the data
      dbContext.SaveChanges();

      // populate the models to render in the view
      ViewBag.dbSuccessChart = 1;
      CompaniesEquities companiesEquities = getCompaniesEquitiesModel(equities);
      return View("Chart", companiesEquities);
    }

    /// <summary>
    /// Use the data provided to assemble the ViewModel
    /// </summary>
    /// <param name="equities">Quotes to dsiplay</param>
    /// <returns>The view model to include </returns>
    public CompaniesEquities getCompaniesEquitiesModel(List<Equity> equities)
    {
      List<Company> companies = dbContext.Companies.ToList();

      if (equities.Count == 0)
      {
        return new CompaniesEquities(companies, null, "", "", "", 0, 0);
      }

      Equity current = equities.Last();

      // create appropriately formatted strings for use by chart.js
      string dates = string.Join(",", equities.Select(e => e.date));
      string prices = string.Join(",", equities.Select(e => e.high));
      float avgprice = equities.Average(e => e.high);

      //Divide volumes by million to scale appropriately
      string volumes = string.Join(",", equities.Select(e => e.volume / 1000000));
      double avgvol = equities.Average(e => e.volume) / 1000000;

      return new CompaniesEquities(companies, equities.Last(), dates, prices, volumes, avgprice, avgvol);
    }

    /// <summary>
    /// Save the available symbols in the database
    /// </summary>
    /// <returns></returns>
    public IActionResult PopulateSymbols()
    {
     
      List<Company> companies = JsonConvert.DeserializeObject<List<Company>>(TempData["Companies"].ToString());

      foreach (Company company in companies)
      {
        //Database will give PK constraint violation error when trying to insert record with existing PK.
        //So add company only if it doesnt exist, check existence using symbol (PK)
        if (dbContext.Companies.Where(c => c.symbol.Equals(company.symbol)).Count() == 0)
        {
          dbContext.Companies.Add(company);
        }
      }

      dbContext.SaveChanges();
      ViewBag.dbSuccessComp = 1;
      return View("Symbols", companies);
    }
        public IActionResult PopulateInfocus()
    {
      
      List<Infocus_Model> infocus = JsonConvert.DeserializeObject<List<Infocus_Model>>(TempData["InFocus"].ToString());

      foreach (Infocus_Model inf in infocus)
      {
        //Database will give PK constraint violation error when trying to insert record with existing PK.
        //So add company only if it doesnt exist, check existence using symbol (PK)
        if (dbContext.InFocus.Where(c => c.symbol.Equals(inf.symbol)).Count() == 0)
        {
          dbContext.InFocus.Add(inf);
        }
      }

      dbContext.SaveChanges();
      ViewBag.dbSuccessComp = 1;
      return View("InFocus", infocus);
    }

        public IActionResult PopulateGainers()
        {

            List<Gainers_Model> gainers = JsonConvert.DeserializeObject<List<Gainers_Model>>(TempData["Gainers"].ToString());

            foreach (Gainers_Model g in gainers)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                if (dbContext.Gainers.Where(c => c.symbol.Equals(g.symbol)).Count() == 0)
                {
                    dbContext.Gainers.Add(g);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Gainers", gainers);
        }

        public IActionResult PopulateHistory()
        {

            List<Historical_Summary> history = JsonConvert.DeserializeObject<List<Historical_Summary>>(TempData["History"].ToString());

            foreach (Historical_Summary hist in history)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                if (dbContext.History.Where(c => c.uniqueSymbolsTraded.Equals(hist.uniqueSymbolsTraded)).Count() == 0)
                {
                    dbContext.History.Add(hist);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("History", history);
        }

        public IActionResult PopulatePerformance()
        {
            
            List<SectorPerformance_Model> performance = JsonConvert.DeserializeObject<List<SectorPerformance_Model>>(TempData["SectorPerform"].ToString());

            foreach (SectorPerformance_Model perf in performance)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                 if (dbContext.SectorPerform.Where(c => c.name.Equals(perf.name)).Count() == 0)
                {
                    dbContext.SectorPerform.Add(perf);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("SectorPerformance", performance);
        }

        public IActionResult PopulateDividend()
        {

            List<Dividend_Model> div = JsonConvert.DeserializeObject<List<Dividend_Model>>(TempData["Dividend"].ToString());

            foreach (Dividend_Model d in div)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                if (dbContext.Dividend.Where(c => c.exdate.Equals(d.exdate)).Count() == 0)
                {
                dbContext.Dividend.Add(d);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Dividend", div);
        }

       

        public IActionResult PopulateNews()
        {

            List<News_Model> news = JsonConvert.DeserializeObject<List<News_Model>>(TempData["News"].ToString());

            foreach (News_Model n in news)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                if (dbContext.News.Where(c => c.datetime.Equals(n.datetime)).Count() == 0)
                {
                dbContext.News.Add(n);
                }
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("News", news);
        }
        public IActionResult Implementation()
        {
            return View();
        }
        public void ClearTables(string tableToDel)
    {
      if ("all".Equals(tableToDel))
      {
        //First remove equities and then the companies
        dbContext.Equities.RemoveRange(dbContext.Equities);
        dbContext.Companies.RemoveRange(dbContext.Companies);
      }
      else if ("Companies".Equals(tableToDel))
      {
        //Remove only those companies that don't have related quotes stored in the Equities table
        dbContext.Companies.RemoveRange(dbContext.Companies
                                                 .Where(c => c.Equities.Count == 0)
                                                              );
      }
      else if ("Charts".Equals(tableToDel))
      {
        dbContext.Equities.RemoveRange(dbContext.Equities);
      }
      dbContext.SaveChanges();
      
    }
  }
}