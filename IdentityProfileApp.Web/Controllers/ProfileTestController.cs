using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.Enums;
using IdentityProfileApp.Domain.Entities.DTO;
using IdentityProfileApp.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using IdentityProfileApp.Domain.Entities.ViewModels;

namespace IdentityProfileApp.Web.Controllers
{
    public class ProfileTestController : BaseController
    {
        // GET: ProfileTest
        public ActionResult StartTest()
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            var questions = entities.Question.ToList();
            List<QuestionAnswerVM> questionAnswers = new List<QuestionAnswerVM>();
            for (int i = 0; i < questions.Count; i++)
            {
                questionAnswers.Add(new QuestionAnswerVM()
                {
                    Question = questions[i]
                });
            }
            return View(questionAnswers);
        }
        List<string> Ids;
        List<string> AnswerList;
        public JsonResult FinishTest(string questionIds, string answers)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            Ids = jss.Deserialize<List<string>>(questionIds);
            AnswerList = jss.Deserialize<List<string>>(answers);

            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            List<ProfileResult> profileResults = new List<ProfileResult>();
            foreach (ProfileParts part in (ProfileParts[])Enum.GetValues(typeof(ProfileParts)))
            {
                profileResults.Add(new ProfileResult() { Part = part, Value = 0 });
            }
            for (int i = 0; i < Ids.Count; i++)
            {
                Guid questionId = Guid.Parse(Ids[i]);
                Answers answer = (Answers)Enum.Parse(typeof(Answers), AnswerList[i], true);

                var question = entities.Question.SingleOrDefault(x => x.Id == questionId);
                switch (answer)
                {
                    case Answers.Accept:
                        profileResults.FirstOrDefault(x => x.Part == question.AgreePart).Value = profileResults.FirstOrDefault(x => x.Part == question.AgreePart).Value + 1;
                        break;
                    case Answers.RarelyAccept:
                        profileResults.FirstOrDefault(x => x.Part == question.AgreePart).Value = profileResults.FirstOrDefault(x => x.Part == question.AgreePart).Value + 0.75;
                        profileResults.FirstOrDefault(x => x.Part == question.DisagreePart).Value = profileResults.FirstOrDefault(x => x.Part == question.DisagreePart).Value + 0.25;
                        break;
                    case Answers.NotSure:
                        profileResults.FirstOrDefault(x => x.Part == question.AgreePart).Value = profileResults.FirstOrDefault(x => x.Part == question.AgreePart).Value + 0.5;
                        profileResults.FirstOrDefault(x => x.Part == question.DisagreePart).Value = profileResults.FirstOrDefault(x => x.Part == question.DisagreePart).Value + 0.5;
                        break;
                    case Answers.RarelyReject:
                        profileResults.FirstOrDefault(x => x.Part == question.AgreePart).Value = profileResults.FirstOrDefault(x => x.Part == question.AgreePart).Value + 0.25;
                        profileResults.FirstOrDefault(x => x.Part == question.DisagreePart).Value = profileResults.FirstOrDefault(x => x.Part == question.DisagreePart).Value + 0.75;
                        break;
                    case Answers.Reject:
                        profileResults.FirstOrDefault(x => x.Part == question.DisagreePart).Value = profileResults.FirstOrDefault(x => x.Part == question.DisagreePart).Value + 1;
                        break;
                    default:
                        break;
                }
            }
            var profileName = ProfileOperation.GetProfile(profileResults);
            TempData["statistics"] = ProfileOperation.StatisticResult(profileResults);
            TempData["profile"] = entities.Profile.Include("Features").SingleOrDefault(u => u.Name == profileName);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}