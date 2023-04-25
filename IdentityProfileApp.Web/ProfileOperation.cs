using IdentityProfileApp.Domain.Entities.Enums;
using IdentityProfileApp.Domain.Entities.Models;
using IdentityProfileApp.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace IdentityProfileApp.Web
{
    public class ProfileOperation
    {
        public static string GetProfile(List<ProfileResult> profileResults)
        {
            StringBuilder profile = new StringBuilder();
            double E = profileResults.FirstOrDefault(x => x.Part == ProfileParts.E).Value;
            double I = profileResults.FirstOrDefault(x => x.Part == ProfileParts.I).Value;
            double F = profileResults.FirstOrDefault(x => x.Part == ProfileParts.F).Value;
            double T = profileResults.FirstOrDefault(x => x.Part == ProfileParts.T).Value;
            double N = profileResults.FirstOrDefault(x => x.Part == ProfileParts.N).Value;
            double S = profileResults.FirstOrDefault(x => x.Part == ProfileParts.S).Value;
            double P = profileResults.FirstOrDefault(x => x.Part == ProfileParts.P).Value;
            double J = profileResults.FirstOrDefault(x => x.Part == ProfileParts.J).Value;


            profile.Append(E >= I ? "E" : "I");
            profile.Append(N >= S ? "N" : "S");
            profile.Append(F >= T ? "F" : "T");
            profile.Append(P >= J ? "P" : "J");

            return profile.ToString();
        }

        public static List<StatisticResult> StatisticResult(List<ProfileResult> profileResults)
        {
            List<StatisticResult> result = new List<StatisticResult>();
            double E = profileResults.FirstOrDefault(x => x.Part == ProfileParts.E).Value;
            double I = profileResults.FirstOrDefault(x => x.Part == ProfileParts.I).Value;
            double F = profileResults.FirstOrDefault(x => x.Part == ProfileParts.F).Value;
            double T = profileResults.FirstOrDefault(x => x.Part == ProfileParts.T).Value;
            double N = profileResults.FirstOrDefault(x => x.Part == ProfileParts.N).Value;
            double S = profileResults.FirstOrDefault(x => x.Part == ProfileParts.S).Value;
            double P = profileResults.FirstOrDefault(x => x.Part == ProfileParts.P).Value;
            double J = profileResults.FirstOrDefault(x => x.Part == ProfileParts.J).Value;
            var E_Statistic = new StatisticResult() { Part = ProfileParts.E, Value = E / (E + I) == 0.5 ? 51 : Math.Round(E / (E + I) * 100), OppositePart = ProfileParts.I,Color=Color.Blue };
            //var I_Statistic = new StatisticResult() { Part = ProfileParts.I, Value = 100 - E_Statistic.Value };
            var N_Statistic = new StatisticResult() { Part = ProfileParts.N, Value = N / (N + S) == 0.5 ? 51 : Math.Round(N / (N + S) * 100), OppositePart = ProfileParts.S,Color=Color.HotPink };
            //var S_Statistic = new StatisticResult() { Part = ProfileParts.S, Value = 100 - N_Statistic.Value };
            var F_Statistic = new StatisticResult() { Part = ProfileParts.F, Value = F / (F + T) == 0.5 ? 51 : Math.Round(F / (F + T) * 100),OppositePart=ProfileParts.T,Color=Color.OrangeRed};
            //var T_Statistic = new StatisticResult() { Part = ProfileParts.T, Value = 100 - F_Statistic.Value };
            var P_Statistic = new StatisticResult() { Part = ProfileParts.P, Value = P / (P + J) == 0.5 ? 51 : Math.Round(P / (P + J) * 100),OppositePart=ProfileParts.J,Color = Color.Gold };
            //var J_Statistic = new StatisticResult() { Part = ProfileParts.J, Value = 100 - P_Statistic.Value };


            result.AddRange(new List<StatisticResult> { E_Statistic, N_Statistic, F_Statistic, P_Statistic });

            return result;
        }
    }
}
