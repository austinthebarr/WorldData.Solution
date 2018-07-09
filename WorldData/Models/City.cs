using System.Collections.Generic;
using MySql.Data.MySqlClient;
using WorldData;
using System;

namespace WorldData.Models
{
  public class City
  {
    private int _id;
    private string _name;
    private string _district;
    private int _population;


    public City(string NewName, string NewDistrict, int NewPopulation, int Id = 0)
    {
      _name = NewName;
      _district = NewDistrict;
      _population = NewPopulation;
      _id = Id;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetDistrict()
    {
      return _district;
    }

    public int GetPopulation()
    {
      return _population;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<City> GetAll()
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city ORDER BY name ASC;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int cityId = rdr.GetInt32(0);
        string cityName = rdr.GetString(1);
        string cityDistrict = rdr.GetString(3);
        int cityPopulation = rdr.GetInt32(4);
        City newCity = new City(cityName, cityDistrict, cityPopulation, cityId);
        allCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }
  }
}
