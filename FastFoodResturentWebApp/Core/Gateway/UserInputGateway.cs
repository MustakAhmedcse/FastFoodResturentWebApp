﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FastFoodResturentWebApp.Models;

namespace FastFoodResturentWebApp.Core.Gateway
{
    public class UserInputGateway : Gateway
    {
        public int Insert(UserInput userInput)
        {
            Query = "UPDATE UserInput_Table SET CalculateTime=" + userInput.CalculateTime + ",InterArrivalTime=" + userInput.InterArrivalTime + ",ServiceTime=" + userInput.ServiceTime + " WHERE Id=1";
            Command.CommandText = Query;
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public UserInput InputInfo()
        {
            UserInput userInput = new UserInput();
            Query = "SELECT * FROM UserInput_Table";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            if (Reader.Read())
            {
                userInput.CalculateTime = Convert.ToInt32(Reader["CalculateTime"]);
                userInput.InterArrivalTime = Convert.ToInt32(Reader["InterArrivalTime"]);
                userInput.ServiceTime = Convert.ToInt32(Reader["ServiceTime"]);

            }
            Reader.Close();
            Connection.Close();
            return userInput;
        }

        public List<FinalResult> GetAllFinalInfo()
        {
            List<FinalResult> finalResults = new List<FinalResult>();
            Query = "SELECT * FROM FinalResult_Table";
            Command.CommandText = Query;
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                FinalResult finalResult = new FinalResult();
                finalResult.InterArrivalTime = Convert.ToInt32(Reader["InterArrivalTime"]);
                finalResult.ArrivalTime = Convert.ToInt32(Reader["ArrivalTime"]);
                finalResult.ServiceTime = Convert.ToInt32(Reader["ServiceTime"]);
                finalResult.ServiceStartTime = Convert.ToInt32(Reader["ServiceStartTime"]);
                finalResult.ServiceEndTime = Convert.ToInt32(Reader["ServiceEndTime"]);
                finalResults.Add(finalResult);
            }
            Reader.Close();
            Connection.Close();
            return finalResults;
        }

        public void FinalResultSave(FinalResult finalResult)
        {
            Query = "INSERT INTO FinalResult_Table VALUES (" + finalResult.InterArrivalTime + "," + finalResult.ArrivalTime + "," + finalResult.ServiceTime + "," + finalResult.ServiceStartTime + "," + finalResult.ServiceEndTime + ") ";
            Command.CommandText = Query;
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();

        }

        public void DedeteFinalResultTable()
        {
            Query = "DROP TABLE FinalResult_Table";
             Command.CommandText = Query;
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
            
           

            //Query = "CREATE TABLE FinalREsult_Table 
            //        (Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
            //         InterArrivalTime int,
            //        ArrivalTime int,
            //         ServiceTime int,
            //        ServiceStartTime int,
            //        ServiceEndTime int,
            //    )";
            //Query = "CREATE TABLE FinalResult_Table (Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,InterArrivalTime int,ArrivalTime int,ServiceTime int,ServiceStartTime int,ServiceEndTime int) ";
            //Command.CommandText = Query;
            //Connection.Open();
            //Command.ExecuteNonQuery();
            //Connection.Close();
        }
    }
}