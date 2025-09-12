using AgentProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AgentProject.Dao
{
    public class AgentDaoImpl : IAgentDao
    {
        static List<Agent> AgentList;
        static AgentDaoImpl()
        {
            AgentList = new List<Agent>();
        }
        public int GenerateAgentId()
        {
            if (AgentList.Count == 0)
            {
                return 1;
            }
            int agentId = AgentList.ElementAt(AgentList.Count-1).AgentId;
            agentId++;
            return agentId;
        }
        public string AddAgentDao(Agent agent)
        {
            int id =GenerateAgentId();
            agent.AgentId=id;
            AgentList.Add(agent);
            return "Added Successfully.....";
        }

        public string DeleteAgentDao(int agentId)
        {
            Agent AgentFound = SearchAgentDao(agentId);
            if (AgentFound != null)
            {
                AgentList.Remove(AgentFound);
                return "Agent Record Deleted Sucessfully";
            }
            return "Agent Not Found ";
        }

        public List<Agent> ShowAgentsDao()
        {
            
            return AgentList;
        }

        public string ReadFromFileDao()
        {
            FileStream fs = new FileStream(@"c:\files\Agent.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            AgentList = (List<Agent>)formatter.Deserialize(fs);
            return "Data Retrieved from the File Successfully...";
        }

        public string UpdateAgentDao(Agent AgentUpdated)
        {
            Agent AgentFound = SearchAgentDao(AgentUpdated.AgentId);
            if (AgentFound != null) {
                AgentFound.FirstName = AgentUpdated.FirstName;
                AgentFound.LastName = AgentUpdated.LastName;
                AgentFound.City = AgentUpdated.City;
                AgentFound.Gender = AgentUpdated.Gender;
                AgentFound.PremimumAmount = AgentUpdated.PremimumAmount;

                return "Update Agent Record.....";
            }
            return "Agent Not Found";
        }

        public string WriteToFileDao()
        {
            FileStream fs = new FileStream(@"c:\files\Agent.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, AgentList);
            fs.Close();
            return "Data Stored in Files Successfully...";
        }

        public Agent SearchAgentDao(int agentId)
        {
            Agent agentFound = null;
            foreach (Agent agent in AgentList)
            {
                if (agent.AgentId == agentId)
                {
                    agentFound = agent;
                    break;
                }
            }
            return agentFound;

        }
    }
}
