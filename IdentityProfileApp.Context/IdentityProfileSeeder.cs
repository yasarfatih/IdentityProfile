using IdentityProfileApp.Domain.Entities.Enums;
using IdentityProfileApp.Domain.Entities.Models;
using IdentityProfileApp.Utils;
using IdentityProfileApp.Utils.Extensions;
using IdentityProfileApp.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace IdentityProfileApp.Context
{
    public class IdentityProfileSeeder
    {
        public static void Seed(IdentityProfileAppContext context)
        {
            #region UserAndRoles

            Role adminRole = new Role() { Id = Guid.NewGuid(), Name = "Admin" };
            Role userRole = new Role() { Id = Guid.NewGuid(), Name = "AppUser" };
            Role autRole = new Role() { Id = Guid.NewGuid(), Name = "Author" };

            context.Roles.AddOrUpdate(r => r.Name,
                    adminRole, userRole, autRole
                    );


            User adminUser = new User();
            adminUser.Id = Guid.NewGuid();
            adminUser.Name = "John";
            adminUser.Surname = "Doe";
            adminUser.EmailAdress = "noreply@gmail.com";
            adminUser.CityId = 6;
            adminUser.DistrictId = 1;
            adminUser.Gender = Gender.Male;
            adminUser.MobileTelNo = "+905553332266";
            adminUser.Password = "Aa123456!".Encrypt("Identity");
            adminUser.UserRoles.Add(new UserInRole() { RoleId = adminRole.Id, UserId = adminUser.Id });
            adminUser.UserRoles.Add(new UserInRole() { RoleId = userRole.Id, UserId = adminUser.Id });

            User appUser = new User();
            appUser.Name = "Jessica";
            appUser.Surname = "Kesley";
            appUser.EmailAdress = "jkesley@gmail.com";
            appUser.CityId = 6;
            appUser.DistrictId = 1;
            appUser.Gender = Gender.Male;
            appUser.MobileTelNo = "+905069685253";
            appUser.Password = "Aa123456!".Encrypt("Identity");
            appUser.Id = Guid.NewGuid();
            appUser.UserRoles.Add(new UserInRole() { RoleId = userRole.Id, UserId = appUser.Id });

            User autUser = new User();
            autUser.Name = "Hakan";
            autUser.Surname = "Almaz";
            autUser.EmailAdress = "hakanalmaz2907@gmail.com";
            autUser.CityId = 6;
            autUser.DistrictId = 1;
            autUser.Gender = Gender.Male;
            autUser.MobileTelNo = "+905069685253";
            autUser.Password = "Aa123456!".Encrypt("Identity");
            autUser.Id = Guid.NewGuid();
            autUser.UserRoles.Add(new UserInRole() { RoleId = autRole.Id, UserId = autUser.Id });

            context.User.AddOrUpdate(u => u.EmailAdress,
                 adminUser, appUser, autUser
                );

            #endregion

            #region ProfileAndFeatures
            var intj = new Profile() { Id = Guid.NewGuid(), Part1 = ProfileParts.I, Part2 = ProfileParts.N, Part3 = ProfileParts.T, Part4 = ProfileParts.J, Title = "Mimar" };
            var intp = new Profile() { Id = Guid.NewGuid(), Part1 = ProfileParts.I, Part2 = ProfileParts.N, Part3 = ProfileParts.T, Part4 = ProfileParts.P, Title = "Mantıkçı" };
            var entj = new Profile() { Id = Guid.NewGuid(), Part1 = ProfileParts.E, Part2 = ProfileParts.N, Part3 = ProfileParts.T, Part4 = ProfileParts.J, Title = "Buyurucu" };
            var entp = new Profile() { Id = Guid.NewGuid(), Part1 = ProfileParts.E, Part2 = ProfileParts.N, Part3 = ProfileParts.T, Part4 = ProfileParts.P, Title = "Tartışmacı" };
            var infj = new Profile() { Id = Guid.NewGuid(), Part1 = ProfileParts.I, Part2 = ProfileParts.N, Part3 = ProfileParts.F, Part4 = ProfileParts.J, Title = "Savunucu" };
            var infp = new Profile() { Id = Guid.NewGuid(), Part1 = ProfileParts.I, Part2 = ProfileParts.N, Part3 = ProfileParts.F, Part4 = ProfileParts.P, Title = "Arabulucu" };
            var enfj = new Profile() { Id = Guid.NewGuid(), Part1 = ProfileParts.E, Part2 = ProfileParts.N, Part3 = ProfileParts.F, Part4 = ProfileParts.J, Title = "Önder" };
            var enfp = new Profile() { Id = Guid.NewGuid(), Part1 = ProfileParts.E, Part2 = ProfileParts.N, Part3 = ProfileParts.F, Part4 = ProfileParts.P, Title = "Kampanyacı" };
            var istj = new Profile() { Id = Guid.NewGuid(), Part1 = ProfileParts.I, Part2 = ProfileParts.S, Part3 = ProfileParts.T, Part4 = ProfileParts.J, Title = "Lojistikçi" };
            var isfj = new Profile() { Id = Guid.NewGuid(), Part1 = ProfileParts.I, Part2 = ProfileParts.S, Part3 = ProfileParts.F, Part4 = ProfileParts.J, Title = "Savunmacı" };
            var estj = new Profile() { Id = Guid.NewGuid(), Part1 = ProfileParts.E, Part2 = ProfileParts.S, Part3 = ProfileParts.T, Part4 = ProfileParts.J, Title = "Yönetici" };
            var esfj = new Profile() { Id = Guid.NewGuid(), Part1 = ProfileParts.E, Part2 = ProfileParts.S, Part3 = ProfileParts.F, Part4 = ProfileParts.J, Title = "Konsül" };
            var istp = new Profile() { Id = Guid.NewGuid(), Part1 = ProfileParts.I, Part2 = ProfileParts.S, Part3 = ProfileParts.T, Part4 = ProfileParts.P, Title = "Becerilki" };
            var isfp = new Profile() { Id = Guid.NewGuid(), Part1 = ProfileParts.I, Part2 = ProfileParts.S, Part3 = ProfileParts.F, Part4 = ProfileParts.P, Title = "Maceracı" };
            var estp = new Profile() { Id = Guid.NewGuid(), Part1 = ProfileParts.E, Part2 = ProfileParts.S, Part3 = ProfileParts.T, Part4 = ProfileParts.P, Title = "Girişimci" };
            var esfp = new Profile() { Id = Guid.NewGuid(), Part1 = ProfileParts.E, Part2 = ProfileParts.S, Part3 = ProfileParts.F, Part4 = ProfileParts.P, Title = "Eğlendirici" };


            #region intj+
            string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum eu varius leo, a fermentum odio. Phasellus porttitor velit tincidunt, convallis ligula ut, faucibus velit. Cras risus ante, tempor lacinia gravida nec, commodo at arcu. Fusce id porttitor turpis. Aliquam ultrices arcu eget nisi consectetur rhoncus. Integer euismod eu nunc ut varius. Vestibulum et mi ac purus placerat facilisis. Cras facilisis rutrum ornare. Nullam scelerisque neque sit amet leo porta, a ullamcorper dolor finibus. In ac odio tincidunt, accumsan metus at, euismod ante. Nulla eleifend euismod eros, non iaculis libero iaculis quis. Ut finibus id dui hendrerit bibendum.\n\nUt a odio fringilla, vulputate magna at, facilisis erat.Vivamus eget vulputate elit, sed dignissim sapien. In rutrum elementum dolor nec molestie. Suspendisse auctor fermentum semper. Maecenas eget placerat ipsum. Quisque viverra, turpis quis fermentum imperdiet, metus lorem vehicula augue, eget feugiat orci ante non mi.Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nam gravida rutrum turpis vulputate consequat. In vel suscipit erat. Donec tincidunt, leo feugiat consectetur commodo, ipsum libero sagittis velit, non lacinia lorem elit elementum nibh.Nulla condimentum viverra faucibus. Ut a luctus urna, nec sodales ex. Sed ultrices non elit vel convallis.";

            string intjCareerPath = loremIpsum;
            string intjFriendShips = loremIpsum;
            string intjInroduction = loremIpsum;
            string intjParentHood = loremIpsum;
            string intjRomanticRelationships = loremIpsum;
            string intjStrengts = loremIpsum;
            string intjWeaknesses = loremIpsum;
            string intjWorkplaceHabits = loremIpsum;

            intj.Features.Add(new Feature() { Characteristic = Characteristics.CareerPahts, Body = intjCareerPath, ProfileId = intj.Id, Title = Characteristics.CareerPahts.GetDisplayName(), Order = 7 });
            intj.Features.Add(new Feature() { Characteristic = Characteristics.FriendShips, Body = intjFriendShips, ProfileId = intj.Id, Title = Characteristics.FriendShips.GetDisplayName(), Order = 2 });
            intj.Features.Add(new Feature() { Characteristic = Characteristics.Inroduction, Body = intjInroduction, ProfileId = intj.Id, Title = Characteristics.Inroduction.GetDisplayName(), Order = 1 });
            intj.Features.Add(new Feature() { Characteristic = Characteristics.Parenthood, Body = intjParentHood, ProfileId = intj.Id, Title = Characteristics.Parenthood.GetDisplayName(), Order = 4 });
            intj.Features.Add(new Feature() { Characteristic = Characteristics.RomanticRelationships, Body = intjRomanticRelationships, ProfileId = intj.Id, Title = Characteristics.RomanticRelationships.GetDisplayName(), Order = 3 });
            intj.Features.Add(new Feature() { Characteristic = Characteristics.Strengts, Body = intjStrengts, ProfileId = intj.Id, Title = Characteristics.Strengts.GetDisplayName(), Order = 5 });
            intj.Features.Add(new Feature() { Characteristic = Characteristics.Weaknesses, Body = intjWeaknesses, ProfileId = intj.Id, Title = Characteristics.Weaknesses.GetDisplayName(), Order = 6 });
            intj.Features.Add(new Feature() { Characteristic = Characteristics.WorkplaceHabits, Body = intjWorkplaceHabits, ProfileId = intj.Id, Title = Characteristics.WorkplaceHabits.GetDisplayName(), Order = 8 });
            #endregion


            #region intp+

            string intpCareerPath = loremIpsum;
            string intpFriendShips = loremIpsum;
            string intpInroduction = loremIpsum;
            string intpParentHood = loremIpsum;
            string intpRomanticRelationships = loremIpsum;
            string intpStrengts = loremIpsum;
            string intpWeaknesses = loremIpsum;
            string intpWorkplaceHabits = loremIpsum;
            intp.Features.Add(new Feature() { Characteristic = Characteristics.CareerPahts, Body = intpCareerPath, ProfileId = intp.Id, Title = Characteristics.CareerPahts.GetDisplayName(), Order = 7 });
            intp.Features.Add(new Feature() { Characteristic = Characteristics.FriendShips, Body = intpFriendShips, ProfileId = intp.Id, Title = Characteristics.FriendShips.GetDisplayName(), Order = 2 });
            intp.Features.Add(new Feature() { Characteristic = Characteristics.Inroduction, Body = intpInroduction, ProfileId = intp.Id, Title = Characteristics.Inroduction.GetDisplayName(), Order = 1 });
            intp.Features.Add(new Feature() { Characteristic = Characteristics.Parenthood, Body = intpParentHood, ProfileId = intp.Id, Title = Characteristics.Parenthood.GetDisplayName(), Order = 4 });
            intp.Features.Add(new Feature() { Characteristic = Characteristics.RomanticRelationships, Body = intpRomanticRelationships, ProfileId = intp.Id, Title = Characteristics.RomanticRelationships.GetDisplayName(), Order = 3 });
            intp.Features.Add(new Feature() { Characteristic = Characteristics.Strengts, Body = intpStrengts, ProfileId = intp.Id, Title = Characteristics.Strengts.GetDisplayName(), Order = 5 });
            intp.Features.Add(new Feature() { Characteristic = Characteristics.Weaknesses, Body = intpWeaknesses, ProfileId = intp.Id, Title = Characteristics.Weaknesses.GetDisplayName(), Order = 6 });
            intp.Features.Add(new Feature() { Characteristic = Characteristics.WorkplaceHabits, Body = intpWorkplaceHabits, ProfileId = intp.Id, Title = Characteristics.WorkplaceHabits.GetDisplayName(), Order = 8 });
            #endregion


            #region entj+

            string entjCareerPath = loremIpsum;
            string entjFriendShips = loremIpsum;
            string entjInroduction = loremIpsum;
            string entjParentHood = loremIpsum;
            string entjRomanticRelationships = loremIpsum;
            string entjStrengts = loremIpsum;
            string entjWeaknesses = loremIpsum;
            string entjWorkplaceHabits = loremIpsum;
            entj.Features.Add(new Feature() { Characteristic = Characteristics.CareerPahts, Body = entjCareerPath, ProfileId = entj.Id, Title = Characteristics.CareerPahts.GetDisplayName(), Order = 7 });
            entj.Features.Add(new Feature() { Characteristic = Characteristics.FriendShips, Body = entjFriendShips, ProfileId = entj.Id, Title = Characteristics.FriendShips.GetDisplayName(), Order = 2 });
            entj.Features.Add(new Feature() { Characteristic = Characteristics.Inroduction, Body = entjInroduction, ProfileId = entj.Id, Title = Characteristics.Inroduction.GetDisplayName(), Order = 1 });
            entj.Features.Add(new Feature() { Characteristic = Characteristics.Parenthood, Body = entjParentHood, ProfileId = entj.Id, Title = Characteristics.Parenthood.GetDisplayName(), Order = 4 });
            entj.Features.Add(new Feature() { Characteristic = Characteristics.RomanticRelationships, Body = entjRomanticRelationships, ProfileId = entj.Id, Title = Characteristics.RomanticRelationships.GetDisplayName(), Order = 3 });
            entj.Features.Add(new Feature() { Characteristic = Characteristics.Strengts, Body = entjStrengts, ProfileId = entj.Id, Title = Characteristics.Strengts.GetDisplayName(), Order = 5 });
            entj.Features.Add(new Feature() { Characteristic = Characteristics.Weaknesses, Body = entjWeaknesses, ProfileId = entj.Id, Title = Characteristics.Weaknesses.GetDisplayName(), Order = 6 });
            entj.Features.Add(new Feature() { Characteristic = Characteristics.WorkplaceHabits, Body = entjWorkplaceHabits, ProfileId = entj.Id, Title = Characteristics.WorkplaceHabits.GetDisplayName(), Order = 8 });
            #endregion


            #region entp+

            string entpCareerPath = loremIpsum;
            string entpFriendShips = loremIpsum;
            string entpInroduction = loremIpsum;
            string entpParentHood = loremIpsum;
            string entpRomanticRelationships = loremIpsum;
            string entpStrengts = loremIpsum;
            string entpWeaknesses = loremIpsum;
            string entpWorkplaceHabits = loremIpsum;
            entp.Features.Add(new Feature() { Characteristic = Characteristics.CareerPahts, Body = entpCareerPath, ProfileId = entp.Id, Title = Characteristics.CareerPahts.GetDisplayName(), Order = 7 });
            entp.Features.Add(new Feature() { Characteristic = Characteristics.FriendShips, Body = entpFriendShips, ProfileId = entp.Id, Title = Characteristics.FriendShips.GetDisplayName(), Order = 2 });
            entp.Features.Add(new Feature() { Characteristic = Characteristics.Inroduction, Body = entpInroduction, ProfileId = entp.Id, Title = Characteristics.Inroduction.GetDisplayName(), Order = 1 });
            entp.Features.Add(new Feature() { Characteristic = Characteristics.Parenthood, Body = entpParentHood, ProfileId = entp.Id, Title = Characteristics.Parenthood.GetDisplayName(), Order = 4 });
            entp.Features.Add(new Feature() { Characteristic = Characteristics.RomanticRelationships, Body = entpRomanticRelationships, ProfileId = entp.Id, Title = Characteristics.RomanticRelationships.GetDisplayName(), Order = 3 });
            entp.Features.Add(new Feature() { Characteristic = Characteristics.Strengts, Body = entpStrengts, ProfileId = entp.Id, Title = Characteristics.Strengts.GetDisplayName(), Order = 5 });
            entp.Features.Add(new Feature() { Characteristic = Characteristics.Weaknesses, Body = entpWeaknesses, ProfileId = entp.Id, Title = Characteristics.Weaknesses.GetDisplayName(), Order = 6 });
            entp.Features.Add(new Feature() { Characteristic = Characteristics.WorkplaceHabits, Body = entpWorkplaceHabits, ProfileId = entp.Id, Title = Characteristics.WorkplaceHabits.GetDisplayName(), Order = 8 });
            #endregion


            #region infj+

            string infjCareerPath = loremIpsum;
            string infjFriendShips = loremIpsum;
            string infjInroduction = loremIpsum;
            string infjParentHood = loremIpsum;
            string infjRomanticRelationships = loremIpsum;
            string infjStrengts = loremIpsum;
            string infjWeaknesses = loremIpsum;
            string infjWorkplaceHabits = loremIpsum;
            infj.Features.Add(new Feature() { Characteristic = Characteristics.CareerPahts, Body = infjCareerPath, ProfileId = infj.Id, Title = Characteristics.CareerPahts.GetDisplayName() });
            infj.Features.Add(new Feature() { Characteristic = Characteristics.FriendShips, Body = infjFriendShips, ProfileId = infj.Id, Title = Characteristics.FriendShips.GetDisplayName() });
            infj.Features.Add(new Feature() { Characteristic = Characteristics.Inroduction, Body = infjInroduction, ProfileId = infj.Id, Title = Characteristics.Inroduction.GetDisplayName() });
            infj.Features.Add(new Feature() { Characteristic = Characteristics.Parenthood, Body = infjParentHood, ProfileId = infj.Id, Title = Characteristics.Parenthood.GetDisplayName() });
            infj.Features.Add(new Feature() { Characteristic = Characteristics.RomanticRelationships, Body = infjRomanticRelationships, ProfileId = infj.Id, Title = Characteristics.RomanticRelationships.GetDisplayName() });
            infj.Features.Add(new Feature() { Characteristic = Characteristics.Strengts, Body = infjStrengts, ProfileId = infj.Id, Title = Characteristics.Strengts.GetDisplayName() });
            infj.Features.Add(new Feature() { Characteristic = Characteristics.Weaknesses, Body = infjWeaknesses, ProfileId = infj.Id, Title = Characteristics.Weaknesses.GetDisplayName() });
            infj.Features.Add(new Feature() { Characteristic = Characteristics.WorkplaceHabits, Body = infjWorkplaceHabits, ProfileId = infj.Id, Title = Characteristics.WorkplaceHabits.GetDisplayName() });
            #endregion


            #region infp+

            string infpCareerPath = loremIpsum;
            string infpFriendShips = loremIpsum;
            string infpInroduction = loremIpsum;
            string infpParentHood = loremIpsum;
            string infpRomanticRelationships = loremIpsum;
            string infpStrengts = loremIpsum;
            string infpWeaknesses = loremIpsum;
            string infpWorkplaceHabits = loremIpsum;
            infp.Features.Add(new Feature() { Characteristic = Characteristics.CareerPahts, Body = infpCareerPath, ProfileId = infp.Id, Title = Characteristics.CareerPahts.GetDisplayName(), Order = 7 });
            infp.Features.Add(new Feature() { Characteristic = Characteristics.FriendShips, Body = infpFriendShips, ProfileId = infp.Id, Title = Characteristics.FriendShips.GetDisplayName(), Order = 2 });
            infp.Features.Add(new Feature() { Characteristic = Characteristics.Inroduction, Body = infpInroduction, ProfileId = infp.Id, Title = Characteristics.Inroduction.GetDisplayName(), Order = 1 });
            infp.Features.Add(new Feature() { Characteristic = Characteristics.Parenthood, Body = infpParentHood, ProfileId = infp.Id, Title = Characteristics.Parenthood.GetDisplayName(), Order = 4 });
            infp.Features.Add(new Feature() { Characteristic = Characteristics.RomanticRelationships, Body = infpRomanticRelationships, ProfileId = infp.Id, Title = Characteristics.RomanticRelationships.GetDisplayName(), Order = 3 });
            infp.Features.Add(new Feature() { Characteristic = Characteristics.Strengts, Body = infpStrengts, ProfileId = infp.Id, Title = Characteristics.Strengts.GetDisplayName(), Order = 5 });
            infp.Features.Add(new Feature() { Characteristic = Characteristics.Weaknesses, Body = infpWeaknesses, ProfileId = infp.Id, Title = Characteristics.Weaknesses.GetDisplayName(), Order = 6 });
            infp.Features.Add(new Feature() { Characteristic = Characteristics.WorkplaceHabits, Body = infpWorkplaceHabits, ProfileId = infp.Id, Title = Characteristics.WorkplaceHabits.GetDisplayName(), Order = 8 });
            #endregion


            #region enfj+

            #region ENFJTexts
            string enfjCareerPath = "Career Paths\n\nWhen it comes to finding a career, people with the Protagonist personality type cast their eyes towards anything that lets them do what they love most – helping other people! Lucky for them, people like being helped, and are even willing to pay for it, which means that Protagonists are rarely wanting for inspiration and opportunity in their search for meaningful work.\n\nProtagonist careers\nDon’t Worry When You Are Not Recognized, but Strive to Be Worthy of Recognition\nProtagonists take a genuine interest in other people, approaching them with warm sociability and a helpful earnestness that rarely goes unnoticed.Altruistic careers like social and religious work, teaching, counseling, and advising of all sorts are popular avenues, giving people with the Protagonist personality type a chance to help others learn, grow, and become more independent.This attitude, alongside their social skills, emotional intelligence and tendency to be “that person who knows everybody”, can be adapted to quite a range of other careers as well, making Protagonists natural HR administrators, event coordinators, and politicians – anything that helps a community or organization to operate more smoothly.\n\nTo top it all off, Protagonists are able to express themselves both creatively and honestly, allowing them to approach positions as sales representatives and advertising consultants from a certain idealistic perspective, intuitively picking up on the needs and wants of their customers, and working to make them happier. However, Protagonists need to make sure they get to focus on people, not systems and spreadsheets, and they are unlikely to have the stomach for making the sort of decisions required in corporate governance positions – they will feel haunted, knowing that their decision cost someone their job, or that their product cost someone their life.\n\nHaving a preference for Intuitive (N) trait over its Observant(S) counterpart also means that careers demanding exceptional situational awareness, such as law enforcement, military service, and emergency response, will cause Protagonists to burn out quickly.While great at organizing willing parties and winning over skeptics, in dangerous situations Protagonists just won’t be able to maintain the sort of focus on their immediate physical surroundings that they inevitably demand of themselves hour after hour, day after day.\n\nAlways Bear in Mind That Your Own Resolution to Succeed Is More Important Than Any Other \n\nIt makes a great deal more sense for Protagonists to be the force keeping these vital services organized and running well, taking their long-term views, people skills and idealism, and using them to shape the situation on the ground, while more physical personality types manage the moment-to-moment crises.People with the Protagonist personality type are always up for a good challenge – and nothing thrills them quite like helping others. But while willing to train the necessary skills, Protagonists will always show an underlying preference for the sort of help that draws a positive long-term trend, that effects change that really sticks.\n\nAt the heart of it, Protagonists need to see how the story ends, to feel and experience the gratitude and appreciation of the people they’ve helped in order to be happy.\n\nCareers operating behind enemy lines and arriving at the scene of the crime too late to help will simply weigh on Protagonists’ sensitive hearts and minds, especially if criticized despite their efforts. On the other hand, Protagonists are a driven, versatile group, and that same vision that pulls them towards administration and politics can help them focus through the stress of the moment, knowing that each second of effort contributes to something bigger than themselves.";

            string enfjFriendShips = "Friendships \nWhen it comes to friendships, Protagonists are anything but passive.While some personality types may accept the circumstantial highs and lows of friendship, their feelings waxing and waning with the times, Protagonists will put active effort into maintaining these connections, viewing them as substantial and important, not something to let slip away through laziness or inattention. \n\nThis philosophy of genuine connection is core to the Protagonist personality type, and while it is visible in the workplace and in romance, it is clearest in the breadth and depth of Protagonist friendships.\n\nProtagonist friends \n\nAll My Life I Have Tried to Pluck a Thistle and Plant a Flower Wherever the Flower Would Grow... \n\nPeople with the Protagonist personality type take genuine pleasure in getting to know other people, and have no trouble talking with people of all types and modes of thought. Even in disagreement, other perspectives are fascinating to Protagonists – though like most people, they connect best with individuals who share their principles and ideals, and types in Diplomat and Analyst Role groups are best able to explore Protagonists’ viewpoints with them, which are simply too idealistic for most.It is with these closest friends that Protagonists will truly open up, keeping their many other connections in a realm of lighthearted but genuine support and encouragement.\n\nOthers truly value their Protagonist friends, appreciating the warmth, kindness, and sincere optimism and cheer they bring to the table.Protagonists want to be the best friends possible, and it shows in how they work to find out not just the superficial interests of their friends, but their strengths, passions, hopes and dreams.Nothing makes Protagonists happier than to see the people they care about do well, and they are more than happy to take their own time and energy to help make it happen.\n\nWe Should Be Too Big to Take Offense, and Too Noble to Give It\n\nWhile Protagonists enjoy lending this helping hand, other personality types may simply not have the energy or drive to keep up with it – creating further strain, people with the Protagonist personality type can become offended if their efforts aren’t reciprocated when the opportunity arises. Ultimately, Protagonists’ give and take can become stifling to types who are more interested in the moment than the future, or who simply have Identities that rest firmly on the Assertive side, making them content with who they are and uninterested in the sort of self-improvement and goal-setting that Protagonists hold so dear.\n\nWhen this happens Protagonist personalities can be critical, if they believe it necessary.While usually tactful and often helpful, if their friend is already annoyed by Protagonists’ attempts to push them forward, it can simply cause them to dig in their heels further.Protagonists should try to avoid taking this personally when it happens, and relax their inflexibility into an occasional “live and let live” attitude. \n\nUltimately though, Protagonists will find that their excitement and unyielding optimism will yield them many satisfying relationships with people who appreciate and share their vision and authenticity. The joy Protagonists take in moving things forward means that there is always a sense of purpose behind their friendships, creating bonds that are not easily shaken.";
            string enfjInroduction = "Introduction Everything you do right now ripples outward and affects everyone. Your posture can shine your heart or transmit anxiety.Your breath can radiate love or muddy the room in depression.Your glance can awaken joy.Your words can inspire freedom.Your every act can open hearts and minds. DAVID DEIDA Protagonists are natural - born leaders, full of passion and charisma.Forming around two percent of the population, they are oftentimes our politicians, our coaches and our teachers, reaching out and inspiring others to achieve and to do good in the world. With a natural confidence that begets influence, Protagonists take a great deal of pride and joy in guiding others to work together to improve themselves and their community. Protagonist personality Firm Believers in the People People are drawn to strong personalities, and Protagonists radiate authenticity, concern and altruism, unafraid to stand up and speak when they feel something needs to be said. They find it natural and easy to communicate with others, especially in person, and their Intuitive(N) trait helps people with the Protagonist personality type to reach every mind, be it through facts and logic or raw emotion. Protagonists easily see people’s motivations and seemingly disconnected events, and are able to bring these ideas together and communicate them as a common goal with an eloquence that is nothing short of mesmerizing The interest Protagonists have in others is genuine, almost to a fault – when they believe in someone, they can become too involved in the other person’s problems, place too much trust in them.Luckily, this trust tends to be a self-fulfilling prophecy, as Protagonists’ altruism and authenticity inspire those they care about to become better themselves. But if they aren’t careful, they can overextend their optimism, sometimes pushing others further than they’re ready or willing to go. Protagonists are vulnerable to another snare as well: they have a tremendous capacity for reflecting on and analyzing their own feelings, but if they get too caught up in another person’s plight, they can develop a sort of emotional hypochondria, seeing other people’s problems in themselves, trying to fix something in themselves that isn’t wrong. If they get to a point where they are held back by limitations someone else is experiencing, it can hinder Protagonists’ ability to see past the dilemma and be of any help at all.When this happens, it’s important for Protagonists to pull back and use that self - reflection to distinguish between what they really feel, and what is a separate issue that needs to be looked at from another perspective.\n...The Struggle Ought Not to Deter Us From the Support of a Cause We Believe to Be Just \nProtagonists are genuine, caring people who talk the talk and walk the walk, and nothing makes them happier than leading the charge, uniting and motivating their team with infectious enthusiasm. \nPeople with the Protagonist personality type are passionate altruists, sometimes even to a fault, and they are unlikely to be afraid to take the slings and arrows while standing up for the people and ideas they believe in. It is no wonder that many famous Protagonists are cultural or political icons – this personality type wants to lead the way to a brighter future, whether it’s by leading a nation to prosperity, or leading their little league softball team to a hard - fought victory.";
            string enfjParentHood = "Parenthood \nAs natural leaders, Protagonists make excellent parents, striving to strike a balance between being encouraging and supportive friends to their children, while also working to instil strong values and a sense of personal responsibility.If there’s one strong trend with the Protagonist personality type, it’s that they are a bedrock of empathetic support, not bullheadedly telling people what they ought to do, but helping them to explore their options and encouraging them to follow their hearts.\n\nProtagonist parents will encourage their children to explore and grow, recognizing and appreciating the individuality of the people they bring into this world and help to raise.\nProtagonist parents \nWhatever You Are, Be a Good One\nProtagonist parents take pride in nurturing and inspiring strong values, and they take care to ensure that the basis for these values comes from understanding, not blind obedience.Whatever their children need in order to learn and grow, Protagonist parents give the time and energy necessary to provide it.While in their weaker moments they may succumb to more manipulative behavior, Protagonists mostly rely on their charm and idealism to make sure their children take these lessons to heart.\n\nOwing to their aversion to conflict, Protagonist parents strive to ensure that their homes provide a safe and conflict - free environment.While they can deliver criticism, it’s not Protagonists’ strong suit, and laying down the occasionally necessary discipline won’t come naturally.But, people with the Protagonist personality type have high standards for their children, encouraging them to be the best they can be, and when these confrontations do happen, they try to frame the lessons as archetypes, moral constants in life which they hope their children will embrace.\n\nAs their children enter adolescence, they begin to truly make their own decisions, sometimes contrary to what their parents want – while Protagonists will do their best to meet this with grace and humor, they can feel hurt, and even unloved, in the face of this rebellion.Protagonists are sensitive, and if their child goes so far as to launch into criticisms, they may become truly upset, digging in their heels and locking horns.\n\n these occasions will likely be rare. Protagonists’ intuition gives them a talent for understanding, and regardless of the heat of the moment, their children will move on, remembering the genuine warmth, care, love and encouragement they’ve always received from their Protagonist parents.They grow up feeling the lessons that have been woven into the fabric of their character, and recognize that they are the better for their parents’ efforts.";
            string enfjRomanticRelationships = "Romantic Relationships\nPeople who share the Protagonist personality type feel most at home when they are in a relationship, and few types are more eager to establish a loving commitment with their chosen partners. Protagonists take dating and relationships seriously, selecting partners with an eye towards the long haul, rather than the more casual approach that might be expected from some types in the Explorer Role group. There’s really no greater joy for Protagonists than to help along the goals of someone they care about, and the interweaving of lives that a committed relationship represents is the perfect opportunity to do just that.\n\nI’m a Slow Walker, but I Never Walk Back\nEven in the dating phase, people with the Protagonist personality type are ready to show their commitment by taking the time and effort to establish themselves as dependable, trustworthy partners.\nProtagonist romantic relationships\nTheir Intuitive(N) trait helps them to keep up with the rapidly shifting moods that are common early in relationships, but Protagonists will still rely on conversations about their mutual feelings, checking the pulse of the relationship by asking how things are, and if there’s anything else they can do.While this can help to keep conflict, which Protagonists abhor, to a minimum, they also risk being overbearing or needy – Protagonists should keep in mind that sometimes the only thing that’s wrong is being asked what’s wrong too often.\n\nProtagonists don’t need much to be happy, just to know that their partner is happy, and for their partner to express that happiness through visible affection.Making others’ goals come to fruition is often the chiefest concern of Protagonists, and they will spare no effort in helping their partner to live the dream.If they aren’t careful though, Protagonists’ quest for their partners’ satisfaction can leave them neglecting their own needs, and it’s important for them to remember to express those needs on occasion, especially early on.\n\nYou Cannot Escape the Responsibility of Tomorrow by Evading It Today\nProtagonists’ tendency to avoid any kind of conflict, sometimes even sacrificing their own principles to keep the peace, can lead to long - term problems if these efforts never fully resolve the underlying issues that they mask. On the other hand, people with the Protagonist personality type can sometimes be too preemptive in resolving their conflicts, asking for criticisms and suggestions in ways that convey neediness or insecurity.Protagonists invest their emotions wholly in their relationships, and are sometimes so eager to please that it actually undermines the relationship – this can lead to resentment, and even the failure of the relationship.When this happens, Protagonists experience strong senses of guilt and betrayal, as they see all their efforts slip away.\nIf potential partners appreciate these qualities though, and make an effort themselves to look after the needs of their Protagonist partners, they will enjoy long, happy, passionate relationships.Protagonists are known to be dependable lovers, perhaps more interested in routine and stability than spontaneity in their sex lives, but always dedicated to the selfless satisfaction of their partners.Ultimately, Protagonist personality types believe that the only true happiness is mutual happiness, and that’s the stuff successful relationships are made of.";
            string enfjStrengts = "Protagonist Strengths\nTolerant – Protagonists are true team players, and they recognize that that means listening to other peoples’ opinions, even when they contradict their own. They admit they don’t have all the answers, and are often receptive to dissent, so long as it remains constructive.\nReliable – The one thing that galls Protagonists the most is the idea of letting down a person or cause they believe in. If it’s possible, Protagonists can always be counted on to see it through.\nCharismatic – Charm and popularity are qualities Protagonists have in spades.They instinctively know how to capture an audience, and pick up on mood and motivation in ways that allow them to communicate with reason, emotion, passion, restraint – whatever the situation calls for. Talented imitators, Protagonists are able to shift their tone and manner to reflect the needs of the audience, while still maintaining their own voice.\nAltruistic – Uniting these qualities is Protagonists’ unyielding desire to do good in and for their communities, be it in their own home or the global stage.Warm and selfless, Protagonists genuinely believe that if they can just bring people together, they can do a world of good.\nNatural Leaders – More than seeking authority themselves, Protagonists often end up in leadership roles at the request of others, cheered on by the many admirers of their strong personality and positive vision.";
            string enfjWeaknesses = "Protagonist Weaknesses\nOverly Idealistic – People with the Protagonist personality type can be caught off guard as they find that, through circumstance or nature, or simple misunderstanding, people fight against them and defy the principles they’ve adopted, however well - intentioned they may be.They are more likely to feel pity for this opposition than anger, and can earn a reputation of naïveté.\nToo Selfless – Protagonists can bury themselves in their hopeful promises, feeling others’ problems as their own and striving hard to meet their word.If they aren’t careful, they can spread themselves too thin, and be left unable to help anyone.\nToo Sensitive – While receptive to criticism, seeing it as a tool for leading a better team, it’s easy for Protagonists to take it a little too much to heart.Their sensitivity to others means that Protagonists sometimes feel problems that aren’t their own and try to fix things they can’t fix, worrying if they are doing enough.\nFluctuating Self-Esteem – Protagonists define their self-esteem by whether they are able to live up to their ideals, and sometimes ask for criticism more out of insecurity than out of confidence, always wondering what they could do better.If they fail to meet a goal or to help someone they said they’d help, their self - confidence will undoubtedly plummet.\nStruggle to Make Tough Decisions – If caught between a rock and a hard place, Protagonists can be stricken with paralysis, imagining all the consequences of their actions, especially if those consequences are humanitarian.";
            string enfjWorkplaceHabits = "Workplace Habits \n\nPeople with the Protagonist personality type are intelligent, warm, idealistic, charismatic, creative, social... With this wind at their backs, Protagonists are able to thrive in many diverse roles, at any level of seniority.Moreover, they are simply likeable people, and this quality propels them to success wherever they have a chance to work with others.\n\nProtagonist Subordinates\nAs subordinates, Protagonists will often underestimate themselves – nevertheless, they quickly make an impression on their managers. Quick learners and excellent multitaskers, people with the Protagonist personality type are able to take on multiple responsibilities with competence and good cheer. Protagonists are hardworking, reliable and eager to help – but this can all be a double-edged sword, as some managers will take advantage of Protagonists’ excellent quality of character by making too many requests and overburdening their Protagonist subordinates with extra work.Protagonists are conflict - averse and try to avoid unnecessary criticism, and in all likelihood will accept these extra tasks in an attempt to maintain a positive impression and frictionless environment.\nProtagonist workplace habits\nProtagonist Colleagues\nAs colleagues, Protagonists’ desire to assist and cooperate is even more evident as they draw their coworkers into teams where everyone can feel comfortable expressing their opinions and suggestions, working together to develop win - win situations that get the job done. Protagonists’ tolerance, open - mindedness and easy sociability make it easy for them to relate to their colleagues, but also make it perhaps a little too easy for their colleagues to shift their problems onto Protagonists’ plates.People with the Protagonist personality type are sensitive to the needs of others, and their role as a social nexus means that problems inevitably find their way to Protagonists’ doorsteps, where colleagues will find a willing, if overburdened, associate.\n\nProtagonist Managers\nWhile perfectly capable as subordinates and colleagues, Protagonists’ true calling, where their capacity for insightful and inspiring communication and sensitivity to the needs of others really shows, is in managing teams.As managers, Protagonists combine their skill in recognizing individual motivations with their natural charisma to not only push their teams and projects forward, but to make their teams want to push forward.They may sometimes stoop to manipulation, the alternative often being a more direct confrontation, but Protagonists’ end goal is always to get done what they set out to do in a way that leaves everyone involved satisfied with their roles and the results they achieved together.";
            #endregion
            enfj.Features.Add(new Feature() { Characteristic = Characteristics.CareerPahts, Body = enfjCareerPath, ProfileId = enfj.Id, Title = Characteristics.CareerPahts.GetDisplayName(), Order = 7 });
            enfj.Features.Add(new Feature() { Characteristic = Characteristics.FriendShips, Body = enfjFriendShips, ProfileId = enfj.Id, Title = Characteristics.FriendShips.GetDisplayName(), Order = 2 });
            enfj.Features.Add(new Feature() { Characteristic = Characteristics.Inroduction, Body = enfjInroduction, ProfileId = enfj.Id, Title = Characteristics.Inroduction.GetDisplayName(), Order = 1 });
            enfj.Features.Add(new Feature() { Characteristic = Characteristics.Parenthood, Body = enfjParentHood, ProfileId = enfj.Id, Title = Characteristics.Parenthood.GetDisplayName(), Order = 4 });
            enfj.Features.Add(new Feature() { Characteristic = Characteristics.RomanticRelationships, Body = enfjRomanticRelationships, ProfileId = enfj.Id, Title = Characteristics.RomanticRelationships.GetDisplayName(), Order = 3 });
            enfj.Features.Add(new Feature() { Characteristic = Characteristics.Strengts, Body = enfjStrengts, ProfileId = enfj.Id, Title = Characteristics.Strengts.GetDisplayName(), Order = 5 });
            enfj.Features.Add(new Feature() { Characteristic = Characteristics.Weaknesses, Body = enfjWeaknesses, ProfileId = enfj.Id, Title = Characteristics.Weaknesses.GetDisplayName(), Order = 6 });
            enfj.Features.Add(new Feature() { Characteristic = Characteristics.WorkplaceHabits, Body = enfjWorkplaceHabits, ProfileId = enfj.Id, Title = Characteristics.WorkplaceHabits.GetDisplayName(), Order = 8 });
            #endregion


            #region enfp+

            string enfpCareerPath = loremIpsum;
            string enfpFriendShips = loremIpsum;
            string enfpInroduction = loremIpsum;
            string enfpParentHood = loremIpsum;
            string enfpRomanticRelationships = loremIpsum;
            string enfpStrengts = loremIpsum;
            string enfpWeaknesses = loremIpsum;
            string enfpWorkplaceHabits = loremIpsum;
            enfp.Features.Add(new Feature() { Characteristic = Characteristics.CareerPahts, Body = enfjCareerPath, ProfileId = enfp.Id, Title = Characteristics.CareerPahts.GetDisplayName(), Order = 7 });
            enfp.Features.Add(new Feature() { Characteristic = Characteristics.FriendShips, Body = enfpFriendShips, ProfileId = enfp.Id, Title = Characteristics.FriendShips.GetDisplayName(), Order = 2 });
            enfp.Features.Add(new Feature() { Characteristic = Characteristics.Inroduction, Body = enfpInroduction, ProfileId = enfp.Id, Title = Characteristics.Inroduction.GetDisplayName(), Order = 1 });
            enfp.Features.Add(new Feature() { Characteristic = Characteristics.Parenthood, Body = enfpParentHood, ProfileId = enfp.Id, Title = Characteristics.Parenthood.GetDisplayName(), Order = 4 });
            enfp.Features.Add(new Feature() { Characteristic = Characteristics.RomanticRelationships, Body = enfpRomanticRelationships, ProfileId = enfp.Id, Title = Characteristics.RomanticRelationships.GetDisplayName(), Order = 3 });
            enfp.Features.Add(new Feature() { Characteristic = Characteristics.Strengts, Body = enfpStrengts, ProfileId = enfp.Id, Title = Characteristics.Strengts.GetDisplayName(), Order = 5 });
            enfp.Features.Add(new Feature() { Characteristic = Characteristics.Weaknesses, Body = enfpWeaknesses, ProfileId = enfp.Id, Title = Characteristics.Weaknesses.GetDisplayName(), Order = 6 });
            enfp.Features.Add(new Feature() { Characteristic = Characteristics.WorkplaceHabits, Body = enfpWorkplaceHabits, ProfileId = enfp.Id, Title = Characteristics.WorkplaceHabits.GetDisplayName(), Order = 8 });
            #endregion


            #region istj+

            string istjCareerPath = loremIpsum;
            string istjFriendShips = loremIpsum;
            string istjInroduction = loremIpsum;
            string istjParentHood = loremIpsum;
            string istjRomanticRelationships = loremIpsum;
            string istjStrengts = loremIpsum;
            string istjWeaknesses = loremIpsum;
            string istjWorkplaceHabits = loremIpsum;
            istj.Features.Add(new Feature() { Characteristic = Characteristics.CareerPahts, Body = istjCareerPath, ProfileId = istj.Id, Title = Characteristics.CareerPahts.GetDisplayName(), Order = 7 });
            istj.Features.Add(new Feature() { Characteristic = Characteristics.FriendShips, Body = istjFriendShips, ProfileId = istj.Id, Title = Characteristics.FriendShips.GetDisplayName(), Order = 2 });
            istj.Features.Add(new Feature() { Characteristic = Characteristics.Inroduction, Body = istjInroduction, ProfileId = istj.Id, Title = Characteristics.Inroduction.GetDisplayName(), Order = 1 });
            istj.Features.Add(new Feature() { Characteristic = Characteristics.Parenthood, Body = istjParentHood, ProfileId = istj.Id, Title = Characteristics.Parenthood.GetDisplayName(), Order = 4 });
            istj.Features.Add(new Feature() { Characteristic = Characteristics.RomanticRelationships, Body = istjRomanticRelationships, ProfileId = istj.Id, Title = Characteristics.RomanticRelationships.GetDisplayName(), Order = 3 });
            istj.Features.Add(new Feature() { Characteristic = Characteristics.Strengts, Body = istjStrengts, ProfileId = istj.Id, Title = Characteristics.Strengts.GetDisplayName(), Order = 5 });
            istj.Features.Add(new Feature() { Characteristic = Characteristics.Weaknesses, Body = istjWeaknesses, ProfileId = istj.Id, Title = Characteristics.Weaknesses.GetDisplayName(), Order = 6 });
            istj.Features.Add(new Feature() { Characteristic = Characteristics.WorkplaceHabits, Body = istjWorkplaceHabits, ProfileId = istj.Id, Title = Characteristics.WorkplaceHabits.GetDisplayName(), Order = 8 });
            #endregion


            #region isfj+

            string isfjCareerPath = loremIpsum;
            string isfjFriendShips = loremIpsum;
            string isfjInroduction = loremIpsum;
            string isfjParentHood = loremIpsum;
            string isfjRomanticRelationships = loremIpsum;
            string isfjStrengts = loremIpsum;
            string isfjWeaknesses = loremIpsum;
            string isfjWorkplaceHabits = loremIpsum;
            isfj.Features.Add(new Feature() { Characteristic = Characteristics.CareerPahts, Body = isfjCareerPath, ProfileId = isfj.Id, Title = Characteristics.CareerPahts.GetDisplayName(), Order = 7 });
            isfj.Features.Add(new Feature() { Characteristic = Characteristics.FriendShips, Body = isfjFriendShips, ProfileId = isfj.Id, Title = Characteristics.FriendShips.GetDisplayName(), Order = 2 });
            isfj.Features.Add(new Feature() { Characteristic = Characteristics.Inroduction, Body = isfjInroduction, ProfileId = isfj.Id, Title = Characteristics.Inroduction.GetDisplayName(), Order = 1 });
            isfj.Features.Add(new Feature() { Characteristic = Characteristics.Parenthood, Body = isfjParentHood, ProfileId = isfj.Id, Title = Characteristics.Parenthood.GetDisplayName(), Order = 4 });
            isfj.Features.Add(new Feature() { Characteristic = Characteristics.RomanticRelationships, Body = isfjRomanticRelationships, ProfileId = isfj.Id, Title = Characteristics.RomanticRelationships.GetDisplayName(), Order = 3 });
            isfj.Features.Add(new Feature() { Characteristic = Characteristics.Strengts, Body = isfjStrengts, ProfileId = isfj.Id, Title = Characteristics.Strengts.GetDisplayName(), Order = 5 });
            isfj.Features.Add(new Feature() { Characteristic = Characteristics.Weaknesses, Body = isfjWeaknesses, ProfileId = isfj.Id, Title = Characteristics.Weaknesses.GetDisplayName(), Order = 6 });
            isfj.Features.Add(new Feature() { Characteristic = Characteristics.WorkplaceHabits, Body = isfjWorkplaceHabits, ProfileId = isfj.Id, Title = Characteristics.WorkplaceHabits.GetDisplayName(), Order = 8 });
            #endregion


            #region estj+
            string estjCareerPath = loremIpsum;
            string estjFriendShips = loremIpsum;
            string estjInroduction = loremIpsum;
            string estjParentHood = loremIpsum;
            string estjRomanticRelationships = loremIpsum;
            string estjStrengts = loremIpsum;
            string estjWeaknesses = loremIpsum;
            string estjWorkplaceHabits = loremIpsum;

            estj.Features.Add(new Feature() { Characteristic = Characteristics.CareerPahts, Body = estjCareerPath, ProfileId = estj.Id, Title = Characteristics.CareerPahts.GetDisplayName(), Order = 7 });
            estj.Features.Add(new Feature() { Characteristic = Characteristics.FriendShips, Body = estjFriendShips, ProfileId = estj.Id, Title = Characteristics.FriendShips.GetDisplayName(), Order = 2 });
            estj.Features.Add(new Feature() { Characteristic = Characteristics.Inroduction, Body = estjInroduction, ProfileId = estj.Id, Title = Characteristics.Inroduction.GetDisplayName(), Order = 1 });
            estj.Features.Add(new Feature() { Characteristic = Characteristics.Parenthood, Body = estjParentHood, ProfileId = estj.Id, Title = Characteristics.Parenthood.GetDisplayName(), Order = 4 });
            estj.Features.Add(new Feature() { Characteristic = Characteristics.RomanticRelationships, Body = estjRomanticRelationships, ProfileId = estj.Id, Title = Characteristics.RomanticRelationships.GetDisplayName(), Order = 3 });
            estj.Features.Add(new Feature() { Characteristic = Characteristics.Strengts, Body = estjStrengts, ProfileId = estj.Id, Title = Characteristics.Strengts.GetDisplayName(), Order = 5 });
            estj.Features.Add(new Feature() { Characteristic = Characteristics.Weaknesses, Body = estjWeaknesses, ProfileId = estj.Id, Title = Characteristics.Weaknesses.GetDisplayName(), Order = 6 });
            estj.Features.Add(new Feature() { Characteristic = Characteristics.WorkplaceHabits, Body = estjWorkplaceHabits, ProfileId = estj.Id, Title = Characteristics.WorkplaceHabits.GetDisplayName(), Order = 8 });
            #endregion


            #region esfj+
            string esfjCareerPath = loremIpsum;
            string esfjFriendShips = loremIpsum;
            string esfjInroduction = loremIpsum;
            string esfjParentHood = loremIpsum;
            string esfjRomanticRelationships = loremIpsum;
            string esfjStrengts = loremIpsum;
            string esfjWeaknesses = loremIpsum;
            string esfjWorkplaceHabits = loremIpsum;

            esfj.Features.Add(new Feature() { Characteristic = Characteristics.CareerPahts, Body = esfjCareerPath, ProfileId = esfj.Id, Title = Characteristics.CareerPahts.GetDisplayName(), Order = 7 });
            esfj.Features.Add(new Feature() { Characteristic = Characteristics.FriendShips, Body = esfjFriendShips, ProfileId = esfj.Id, Title = Characteristics.FriendShips.GetDisplayName(), Order = 2 });
            esfj.Features.Add(new Feature() { Characteristic = Characteristics.Inroduction, Body = esfjInroduction, ProfileId = esfj.Id, Title = Characteristics.Inroduction.GetDisplayName(), Order = 1 });
            esfj.Features.Add(new Feature() { Characteristic = Characteristics.Parenthood, Body = esfjParentHood, ProfileId = esfj.Id, Title = Characteristics.Parenthood.GetDisplayName(), Order = 4 });
            esfj.Features.Add(new Feature() { Characteristic = Characteristics.RomanticRelationships, Body = esfjRomanticRelationships, ProfileId = esfj.Id, Title = Characteristics.RomanticRelationships.GetDisplayName(), Order = 3 });
            esfj.Features.Add(new Feature() { Characteristic = Characteristics.Strengts, Body = esfjStrengts, ProfileId = esfj.Id, Title = Characteristics.Strengts.GetDisplayName(), Order = 5 });
            esfj.Features.Add(new Feature() { Characteristic = Characteristics.Weaknesses, Body = esfjWeaknesses, ProfileId = esfj.Id, Title = Characteristics.Weaknesses.GetDisplayName(), Order = 6 });
            esfj.Features.Add(new Feature() { Characteristic = Characteristics.WorkplaceHabits, Body = esfjWorkplaceHabits, ProfileId = esfj.Id, Title = Characteristics.WorkplaceHabits.GetDisplayName(), Order = 8 });
            #endregion



            #region istp+

            string istpCareerPath = loremIpsum;
            string istpFriendShips = loremIpsum;
            string istpInroduction = loremIpsum;
            string istpParentHood = loremIpsum;
            string istpRomanticRelationships = loremIpsum;
            string istpStrengts = loremIpsum;
            string istpWeaknesses = loremIpsum;
            string istpWorkplaceHabits = loremIpsum;
            istp.Features.Add(new Feature() { Characteristic = Characteristics.CareerPahts, Body = istpCareerPath, ProfileId = istp.Id, Title = Characteristics.CareerPahts.GetDisplayName(), Order = 7 });
            istp.Features.Add(new Feature() { Characteristic = Characteristics.FriendShips, Body = istpFriendShips, ProfileId = istp.Id, Title = Characteristics.FriendShips.GetDisplayName(), Order = 2 });
            istp.Features.Add(new Feature() { Characteristic = Characteristics.Inroduction, Body = istpInroduction, ProfileId = istp.Id, Title = Characteristics.Inroduction.GetDisplayName(), Order = 1 });
            istp.Features.Add(new Feature() { Characteristic = Characteristics.Parenthood, Body = istpParentHood, ProfileId = istp.Id, Title = Characteristics.Parenthood.GetDisplayName(), Order = 4 });
            istp.Features.Add(new Feature() { Characteristic = Characteristics.RomanticRelationships, Body = istpRomanticRelationships, ProfileId = istp.Id, Title = Characteristics.RomanticRelationships.GetDisplayName(), Order = 3 });
            istp.Features.Add(new Feature() { Characteristic = Characteristics.Strengts, Body = istpStrengts, ProfileId = istp.Id, Title = Characteristics.Strengts.GetDisplayName(), Order = 5 });
            istp.Features.Add(new Feature() { Characteristic = Characteristics.Weaknesses, Body = istpWeaknesses, ProfileId = istp.Id, Title = Characteristics.Weaknesses.GetDisplayName(), Order = 6 });
            istp.Features.Add(new Feature() { Characteristic = Characteristics.WorkplaceHabits, Body = istpWorkplaceHabits, ProfileId = istp.Id, Title = Characteristics.WorkplaceHabits.GetDisplayName(), Order = 8 });
            #endregion



            #region isfp+

            string isfpCareerPath = loremIpsum;
            string isfpFriendShips = loremIpsum;
            string isfpInroduction = loremIpsum;
            string isfpParentHood = loremIpsum;
            string isfpRomanticRelationships = loremIpsum;
            string isfpStrengts = loremIpsum;
            string isfpWeaknesses = loremIpsum;
            string isfpWorkplaceHabits = loremIpsum;
            isfp.Features.Add(new Feature() { Characteristic = Characteristics.CareerPahts, Body = isfpCareerPath, ProfileId = isfp.Id, Title = Characteristics.CareerPahts.GetDisplayName(), Order = 7 });
            isfp.Features.Add(new Feature() { Characteristic = Characteristics.FriendShips, Body = isfpFriendShips, ProfileId = isfp.Id, Title = Characteristics.FriendShips.GetDisplayName(), Order = 2 });
            isfp.Features.Add(new Feature() { Characteristic = Characteristics.Inroduction, Body = isfpInroduction, ProfileId = isfp.Id, Title = Characteristics.Inroduction.GetDisplayName(), Order = 1 });
            isfp.Features.Add(new Feature() { Characteristic = Characteristics.Parenthood, Body = isfpParentHood, ProfileId = isfp.Id, Title = Characteristics.Parenthood.GetDisplayName(), Order = 4 });
            isfp.Features.Add(new Feature() { Characteristic = Characteristics.RomanticRelationships, Body = isfpRomanticRelationships, ProfileId = isfp.Id, Title = Characteristics.RomanticRelationships.GetDisplayName(), Order = 3 });
            isfp.Features.Add(new Feature() { Characteristic = Characteristics.Strengts, Body = isfpStrengts, ProfileId = isfp.Id, Title = Characteristics.Strengts.GetDisplayName(), Order = 5 });
            isfp.Features.Add(new Feature() { Characteristic = Characteristics.Weaknesses, Body = isfpWeaknesses, ProfileId = isfp.Id, Title = Characteristics.Weaknesses.GetDisplayName(), Order = 6 });
            isfp.Features.Add(new Feature() { Characteristic = Characteristics.WorkplaceHabits, Body = isfpWorkplaceHabits, ProfileId = isfp.Id, Title = Characteristics.WorkplaceHabits.GetDisplayName(), Order = 8 });
            #endregion



            #region estp+

            string estpCareerPath = loremIpsum;
            string estpFriendShips = loremIpsum;
            string estpInroduction = loremIpsum;
            string estpParentHood = loremIpsum;
            string estpRomanticRelationships = loremIpsum;
            string estpStrengts = loremIpsum;
            string estpWeaknesses = loremIpsum;
            string estpWorkplaceHabits = loremIpsum;

            estp.Features.Add(new Feature() { Characteristic = Characteristics.CareerPahts, Body = estpCareerPath, ProfileId = estp.Id, Title = Characteristics.CareerPahts.GetDisplayName(), Order = 7 });
            estp.Features.Add(new Feature() { Characteristic = Characteristics.FriendShips, Body = estpFriendShips, ProfileId = estp.Id, Title = Characteristics.FriendShips.GetDisplayName(), Order = 2 });
            estp.Features.Add(new Feature() { Characteristic = Characteristics.Inroduction, Body = estpInroduction, ProfileId = estp.Id, Title = Characteristics.Inroduction.GetDisplayName(), Order = 1 });
            estp.Features.Add(new Feature() { Characteristic = Characteristics.Parenthood, Body = estpParentHood, ProfileId = estp.Id, Title = Characteristics.Parenthood.GetDisplayName(), Order = 4 });
            estp.Features.Add(new Feature() { Characteristic = Characteristics.RomanticRelationships, Body = estpRomanticRelationships, ProfileId = estp.Id, Title = Characteristics.RomanticRelationships.GetDisplayName(), Order = 3 });
            estp.Features.Add(new Feature() { Characteristic = Characteristics.Strengts, Body = estpStrengts, ProfileId = estp.Id, Title = Characteristics.Strengts.GetDisplayName(), Order = 5 });
            estp.Features.Add(new Feature() { Characteristic = Characteristics.Weaknesses, Body = estpWeaknesses, ProfileId = estp.Id, Title = Characteristics.Weaknesses.GetDisplayName(), Order = 6 });
            estp.Features.Add(new Feature() { Characteristic = Characteristics.WorkplaceHabits, Body = estpWorkplaceHabits, ProfileId = estp.Id, Title = Characteristics.WorkplaceHabits.GetDisplayName(), Order = 8 });
            #endregion


            #region esfp+

            string esfpCareerPath = loremIpsum;
            string esfpFriendShips = loremIpsum;
            string esfpInroduction = loremIpsum;
            string esfpParentHood = loremIpsum;
            string esfpRomanticRelationships = loremIpsum;
            string esfpStrengts = loremIpsum;
            string esfpWeaknesses = loremIpsum;
            string esfpWorkplaceHabits = loremIpsum;
            esfp.Features.Add(new Feature() { Characteristic = Characteristics.CareerPahts, Body = esfpCareerPath, ProfileId = esfp.Id, Title = Characteristics.CareerPahts.GetDisplayName(), Order = 7 });
            esfp.Features.Add(new Feature() { Characteristic = Characteristics.FriendShips, Body = esfpFriendShips, ProfileId = esfp.Id, Title = Characteristics.FriendShips.GetDisplayName(), Order = 2 });
            esfp.Features.Add(new Feature() { Characteristic = Characteristics.Inroduction, Body = esfpInroduction, ProfileId = esfp.Id, Title = Characteristics.Inroduction.GetDisplayName(), Order = 1 });
            esfp.Features.Add(new Feature() { Characteristic = Characteristics.Parenthood, Body = esfpParentHood, ProfileId = esfp.Id, Title = Characteristics.Parenthood.GetDisplayName(), Order = 4 });
            esfp.Features.Add(new Feature() { Characteristic = Characteristics.RomanticRelationships, Body = esfpRomanticRelationships, ProfileId = esfp.Id, Title = Characteristics.RomanticRelationships.GetDisplayName(), Order = 3 });
            esfp.Features.Add(new Feature() { Characteristic = Characteristics.Strengts, Body = esfpStrengts, ProfileId = esfp.Id, Title = Characteristics.Strengts.GetDisplayName(), Order = 5 });
            esfp.Features.Add(new Feature() { Characteristic = Characteristics.Weaknesses, Body = esfpWeaknesses, ProfileId = esfp.Id, Title = Characteristics.Weaknesses.GetDisplayName(), Order = 6 });
            esfp.Features.Add(new Feature() { Characteristic = Characteristics.WorkplaceHabits, Body = esfpWorkplaceHabits, ProfileId = esfp.Id, Title = Characteristics.WorkplaceHabits.GetDisplayName(), Order = 8 });
            #endregion



            context.Profile.AddRange(new List<Profile>()
            {
                intj,intp,entj,entp,infj,infp,enfj,enfp,istj,isfj,estj,esfj,istp,isfp,estp,esfp
            });
            #endregion

            #region Questions
            context.Question.AddRange(new List<Question>()
            {
                new Question(){Id=Guid.NewGuid(),Body="Gruplar içinde kendimi rahat hissederim.",AgreePart=ProfileParts.E,DisagreePart=ProfileParts.I,},

                new Question(){Id=Guid.NewGuid(),Body="Kararlarımı duygularıma göre veririm ve şefkatli olmak isterim.",AgreePart=ProfileParts.F,DisagreePart=ProfileParts.T,},

                new Question(){Id=Guid.NewGuid(),Body="Genellikle bir durumun artılarını ve eksilerini analiz ederim.",AgreePart=ProfileParts.N,DisagreePart=ProfileParts.S,},

                new Question(){Id=Guid.NewGuid(),Body="Harekete geçmeyi ve bir şeyleri gerçekleştirmek için uğraşmayı severim.",AgreePart=ProfileParts.E,DisagreePart=ProfileParts.I,},

                new Question(){Id=Guid.NewGuid(),Body="Gelişigüzel ve rahat davranmayı severim. Planlarımı asgaride tutmayı tercih ederim.",AgreePart=ProfileParts.P,DisagreePart=ProfileParts.J,},

                new Question(){Id=Guid.NewGuid(),Body="İş arkadaşlarımla bir sorun yaşıyorsam bu sorunu duygularımla değil mantığımla çözmeyi tercih ederim.",AgreePart=ProfileParts.T,DisagreePart=ProfileParts.F,},

                new Question(){Id=Guid.NewGuid(),Body="İşime eğlence olarak yaklaşmayı severim, ya da iş ve eğlenceyi karıştırırım.",AgreePart=ProfileParts.N,DisagreePart=ProfileParts.S,},

                new Question(){Id=Guid.NewGuid(),Body="Uyuma oldukça önem veririm",AgreePart=ProfileParts.F,DisagreePart=ProfileParts.T,},

                new Question(){Id=Guid.NewGuid(),Body="Yeni ve değişik olan şeyleri deneyimlemeyi severim",AgreePart=ProfileParts.E,DisagreePart=ProfileParts.I},

                new Question(){Id=Guid.NewGuid(),Body="Yalnız olmaktan ya da rahat hissettiğim birkaç kişiyle beraber bir şeyler yapmaktan hoşlanırım.",AgreePart=ProfileParts.I,DisagreePart=ProfileParts.E},

                new Question(){Id=Guid.NewGuid(),Body="Yapılacaklar listesi yapmayı severim",AgreePart=ProfileParts.J,DisagreePart=ProfileParts.P,},

                new Question(){Id=Guid.NewGuid(),Body="Evde kendimi yalnız hissedersem hemen dışarı çıkar birkaç arkadaşımı ararım",AgreePart=ProfileParts.E,DisagreePart=ProfileParts.I},

                new Question(){Id=Guid.NewGuid(),Body="Hoşuma gitmese de doğru olanı yapmayı tercih ederim",AgreePart=ProfileParts.T,DisagreePart=ProfileParts.F},

                new Question(){Id=Guid.NewGuid(),Body="Yeni deneyimlere ve bilgilere açık olmayı tercih ederim",AgreePart=ProfileParts.P,DisagreePart=ProfileParts.J},

                new Question(){Id=Guid.NewGuid(),Body="Deneyim benim için ilk gelir, sembollere ve kelimelere daha az güvenirim",AgreePart=ProfileParts.F,DisagreePart=ProfileParts.T},

                new Question(){Id=Guid.NewGuid(),Body="Zihnimin derinliklerinde zaman geçirmeyi sıklıkla tercih ederim",AgreePart=ProfileParts.I,DisagreePart=ProfileParts.E},

                new Question(){Id=Guid.NewGuid(),Body="Gerçekte ne deneyimlediğimden çok sembollere ve metaforlara daha çok güvenirim",AgreePart=ProfileParts.F,DisagreePart=ProfileParts.T},

                new Question(){Id=Guid.NewGuid(),Body="Daha esnek ve spontane bir hayat tarzını kendime daha yakın bulurum",AgreePart=ProfileParts.P,DisagreePart=ProfileParts.J},

                new Question(){Id=Guid.NewGuid(),Body="Benim için birisine karşı nazik olmak, çıplak gerçeği söylemekten daha önemlidir",AgreePart=ProfileParts.N,DisagreePart=ProfileParts.S},

                new Question(){Id=Guid.NewGuid(),Body="Acele iş yapmaktan kaçınmak için o işi son bitiş tarihinden önce bitirecek şekilde planlarım",AgreePart=ProfileParts.J,DisagreePart=ProfileParts.P},

                new Question(){Id=Guid.NewGuid(),Body="Gerçekte ne olduğu ile ilgilenirim",AgreePart=ProfileParts.T,DisagreePart=ProfileParts.F,},

                new Question(){Id=Guid.NewGuid(),Body="Prensip ve kurallara odaklı bir yapım vardır",AgreePart=ProfileParts.T,DisagreePart=ProfileParts.F},

                new Question(){Id=Guid.NewGuid(),Body="Mümkün olabildiğince hayatımı kontrol altında tutmayı severim",AgreePart=ProfileParts.J,DisagreePart=ProfileParts.P},

                new Question(){Id=Guid.NewGuid(),Body="Diğerleri için neyin önemli olduğunu önemserim",AgreePart=ProfileParts.F,DisagreePart=ProfileParts.T},

                new Question(){Id=Guid.NewGuid(),Body="Karar verirken mantığımı kullanırım ve tarafsız olmak isterim",AgreePart=ProfileParts.T,DisagreePart=ProfileParts.F},

                new Question(){Id=Guid.NewGuid(),Body="Seçimlerimi kişisel yargılardan bağımsız yaparım",AgreePart=ProfileParts.T,DisagreePart=ProfileParts.F},

                new Question(){Id=Guid.NewGuid(),Body="Satır aralarını okuyarak olayları hatırlarım",AgreePart=ProfileParts.P,DisagreePart=ProfileParts.J},

                new Question(){Id=Guid.NewGuid(),Body="Her şeyin daha önceden karar verilmiş olmasından hoşlanırım",AgreePart=ProfileParts.J,DisagreePart=ProfileParts.P},

                new Question(){Id=Guid.NewGuid(),Body="Birkaç insanı iyi tanımak benim için yeterlidir",AgreePart=ProfileParts.I,DisagreePart=ProfileParts.E},

                new Question(){Id=Guid.NewGuid(),Body="Geniş bir arkadaş çevrem vardır ve birçok insan tanırım",AgreePart=ProfileParts.E,DisagreePart=ProfileParts.I},

                new Question(){Id=Guid.NewGuid(),Body="Bazen gerçekler üzerinde çok durduğum için yeni olasılıkları gözden kaçırırım",AgreePart=ProfileParts.J,DisagreePart=ProfileParts.P},

                new Question(){Id=Guid.NewGuid(),Body="Olasılıkları değerlendirebilirim",AgreePart=ProfileParts.N,DisagreePart=ProfileParts.S},

                new Question(){Id=Guid.NewGuid(),Body="Uyumun yokluğu beni tedirgin edebilir",AgreePart=ProfileParts.E,DisagreePart=ProfileParts.I},
            });

            #endregion

            #region Category
            Category category = new Category();
            category.Id = Guid.NewGuid();
            category.CategoryName = "Kişilik Tipleri";
            context.Category.AddOrUpdate(category);
            #endregion

            var turkish = new Language() { ResourceCode = "tr-TR", ResourceName = "Türkçe" };
            turkish.LanguageDefinitions.Add(new LanguageResource() { Body = "Merhaba Dünya", LanguageId = 1, ResourceNo = "1000" });
            var english = new Language() { ResourceCode = "en-US", ResourceName = "English" };
            english.LanguageDefinitions.Add(new LanguageResource() { Body = "Hello World", LanguageId = 2, ResourceNo = "1000" });

            context.Language.AddRange(new List<Language>()
            {
                turkish,english
            });



            context.SaveChanges();
        }
    }
}
