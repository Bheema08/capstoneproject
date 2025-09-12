using AgentProject.Dao;
using AgentProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentProject.Exception;
namespace AgentProject.Bal
{
    public class AgentBal
    {
        private AgentDaoImpl daoImpl = new AgentDaoImpl();
        public StringBuilder sb = new StringBuilder();
            //public static AgentDaoImpl daoImpl;

            //static AgentBal()
            //{
            //    daoImpl = new AgentDaoImpl();
            //}

            public List<Agent> ShowAgentBal()
            {
                return daoImpl.ShowAgentsDao();
            }



            public string WriteFileBal()
            {
                return daoImpl.WriteToFileDao();
            }

            public string ReadFileBal()
            {
                return daoImpl.ReadFromFileDao();
            }

            public string DeleteAgentBal(int agentId)
            {
                return daoImpl.DeleteAgentDao(agentId);
            }
            public string UpdateAgentBal(Agent agentUpdated)
            {
                if (ValidateAgent(agentUpdated))
                {
                    return daoImpl.UpdateAgentDao(agentUpdated);
                }
                throw new AgentException(sb.ToString());
            }

            public Agent SearchAgentBal(int agentId)
            {
                return daoImpl.SearchAgentDao(agentId);
            }

            public string AddAgentBal(Agent agent)
            {
                if (ValidateAgent(agent))
                {
                    return daoImpl.AddAgentDao(agent);
                }
                throw new AgentException(sb.ToString());
            }

            public bool ValidateAgent(Agent agent)
            {
                bool flag = true;
                //if (agent.AgentId <= 0)
                //{ 
                //    sb.Append("Employ No Cannot be Zero or Negative...\n");
                //    flag = false;
                //}
                if (agent.FirstName.Length < 5)
                {
                    sb.Append("Name Contains Min. 5 characters...\n");
                    flag = false;
                }
                if (agent.PremimumAmount <= 10000)
                {
                    sb.Append("Premimum amount must be greater than 10000..\n");
                    flag = false;
                }
                return flag;
            }
        //public static string DeleteEmployBal(object agentId)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
