using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;
using System;

namespace WorldData.Models
{
  public class Country
  {
    private string _name;
    private string _continent;
    private int _capital;
    private int _population;
    private float _lifeExpectancy;

    public Country(string NewName, string NewContinent, int NewCapital, int NewPopulation, float NewLifeExpectancy)
    {
      _name = NewName;
      _continent = NewContinent;
      _capital = NewCapital;
      _population = NewPopulation;
      _lifeExpectancy =NewLifeExpectancy;
    }

    public string GetName()
    {
      return _name;
    }
    public string GetContinent()
    {
      return _continent;
    }
    public int GetCapital()
    {
      return _capital;
    }
    public int GetPopulation()
    {
      return _population;
    }
    public float GetLifeEcpectancy()
    {
      return _lifeExpectancy;
    }

    public static List<Country> GetAll()
    {
      List<Country> allCountries = new List<Country>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country ORDER BY name asc;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        string countryName = rdr.GetString(1);
        string countryContinent = rdr.GetString(2);
        int countryCapital = 0;
        if(!rdr.IsDBNull(13))
        {
          countryCapital = rdr.GetInt32(13);
        }
        int countryPopulation = rdr.GetInt32(6);
        float countryLifeExpectancy = 0;
        if(!rdr.IsDBNull(7))
        {
          countryLifeExpectancy = rdr.GetFloat(7);
        }
        Country newCountry = new Country(countryName, countryContinent, countryCapital, countryPopulation, countryLifeExpectancy);
        allCountries.Add(newCountry);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCountries;
    }
  }
}
