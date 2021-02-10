using ClaimsApi.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace ClaimsApi.ClaimsServices
{
    public class CsvDataLoader
    {
        public const string csvMemFilePath = "C:/test_webapi/Member.csv";
        public List<MemberModel> GetMembersFromCsv()
        {
            List<MemberModel> members = null;
            try 
            { 
                if (File.Exists(csvMemFilePath))
                {
                    //using CSVHelper
                    using (var reader = new StreamReader(csvMemFilePath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        members = csv.GetRecords<MemberModel>().ToList();
                    }
                }
                return members;
            }

            catch (UnauthorizedAccessException e)
            {
                throw new Exception(e.Message);
            }
            catch (FileNotFoundException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public const string csvClmsFilePath = "C:/test_webapi/Claim.csv";
        public List<ClaimsModel> GetClaimsFromCsv()
        {
            List<ClaimsModel> claims = null;
            try
            {
                if (File.Exists(csvClmsFilePath))
                {
                    using(var strmReader = new StreamReader(csvClmsFilePath))
                    using(var csvRdr = new CsvReader(strmReader, CultureInfo.InvariantCulture))
                    {
                        claims = csvRdr.GetRecords<ClaimsModel>().ToList();                    }
                }
                return claims;
            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception(e.Message);
            }
            catch (FileNotFoundException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}