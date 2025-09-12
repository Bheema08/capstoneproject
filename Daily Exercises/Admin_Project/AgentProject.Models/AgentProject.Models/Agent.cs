    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace AgentProject.Models
    {
        public class Agent
        {
            public int AgentId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City {  get; set; }
            public string Gender { get; set; }
            public double PremimumAmount {  get; set; }

            public Agent() { }
            public Agent(int agentId,string firstName,string lastName,string city,string gender,double premimumAmount)
            {
                AgentId = agentId;
                FirstName = firstName;
                LastName = lastName;
                City = city;
                Gender = gender;
                PremimumAmount = premimumAmount;
            }
            public override string ToString()
            {
                return "AgentId " + AgentId +
                       "FirstName" + FirstName +
                       "LAstName" + LastName +
                       "City" + City +
                       "Gender" + Gender +
                       "PreimimumAmount" + PremimumAmount;
            }
        }

    }
