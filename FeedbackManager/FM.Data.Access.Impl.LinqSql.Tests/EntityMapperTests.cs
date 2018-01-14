using FM.Data.Access.Impl.LinqSql.GeneratedDAL;
using FM.Data.Access.Impl.LinqSql.Mappers;
using FM.Domain.Model.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM.Data.Access.Impl.LinqSql.Tests
{
    [TestFixture]
    public class EntityMapperTests
    {
        #region FM_Feedback and Feedback
        [Test]
        public void Map_FmFeedback_to_Feedback()
        {
            FM_Feedback fmFeedback = new FM_Feedback();
            fmFeedback.id = 1;
            fmFeedback.create_date = DateTime.MaxValue;
            fmFeedback.update_date = DateTime.MaxValue;
            fmFeedback.comment = "Test";
            fmFeedback.rating = 3;
            fmFeedback.game_session_id = 2;
            fmFeedback.user_id = 3;

            Feedback feedback = EntityMapper.MapToModel<Feedback, FM_Feedback>(fmFeedback);

            Assert.IsNotNull(feedback);
            Assert.AreEqual(fmFeedback.id, feedback.Id);
            Assert.AreEqual(fmFeedback.create_date, feedback.CreateDate);
            Assert.AreEqual(fmFeedback.update_date, feedback.UpdateDate);
            Assert.AreEqual(fmFeedback.comment, feedback.Comment);
            Assert.AreEqual(fmFeedback.rating, feedback.Rating);
            Assert.AreEqual(fmFeedback.game_session_id, feedback.GameSessionId);
            Assert.AreEqual(fmFeedback.user_id, feedback.UserId);
        }

        [Test]
        public void Map_Feedback_to_FmFeedback()
        {
            Feedback feedback = new Feedback();
            feedback.Id = 1;
            feedback.CreateDate = DateTime.MaxValue;
            feedback.UpdateDate = DateTime.MaxValue;
            feedback.Comment = "Test";
            feedback.Rating = 3;
            feedback.GameSessionId = 2;
            feedback.UserId = 3;

            FM_Feedback fmFeedback = EntityMapper.MapToDatabase<Feedback, FM_Feedback>(feedback);

            Assert.IsNotNull(feedback);
            Assert.AreEqual(fmFeedback.id, feedback.Id);
            Assert.AreEqual(fmFeedback.create_date, feedback.CreateDate);
            Assert.AreEqual(fmFeedback.update_date, feedback.UpdateDate);
            Assert.AreEqual(fmFeedback.comment, feedback.Comment);
            Assert.AreEqual(fmFeedback.rating, feedback.Rating);
            Assert.AreEqual(fmFeedback.game_session_id, feedback.GameSessionId);
            Assert.AreEqual(fmFeedback.user_id, feedback.UserId);
        }
        #endregion

        #region FM_User and User
        [Test]
        public void Map_FmUser_to_User()
        {
            FM_User fmUser = new FM_User();
            fmUser.id = 1;
            fmUser.create_date = DateTime.MinValue;
            fmUser.update_date = DateTime.MaxValue;
            fmUser.name = "Vlado";
            fmUser.surname = "Kragujevski";
            fmUser.email = "myemail@gmail.com";
            fmUser.role_id = Int32.Parse(Role.PLAYER);
            fmUser.user_login = "test";
            fmUser.user_password = "1234";

            User user = EntityMapper.MapToModel<User, FM_User>(fmUser);

            Assert.IsNotNull(user);
            Assert.AreEqual(user.Id, fmUser.id);
            Assert.AreEqual(user.CreateDate, fmUser.create_date);
            Assert.AreEqual(user.UpdateDate, fmUser.update_date);
            Assert.AreEqual(user.Name, fmUser.name);
            Assert.AreEqual(user.Surname, fmUser.surname);
            Assert.AreEqual(user.Email, fmUser.email);
            Assert.AreEqual(user.RoleId, fmUser.role_id);
            Assert.AreEqual(user.UserLogin, fmUser.user_login);
            Assert.AreEqual(user.UserPassword, fmUser.user_password);

        }

        [Test]
        public void Map_User_to_FmUser()
        {
            User user = new User();
            user.Id = 1;
            user.CreateDate = DateTime.MinValue;
            user.UpdateDate = DateTime.MaxValue;
            user.Name = "Vlado";
            user.Surname = "Kragujevski";
            user.Email  = "myemail@gmail.com";
            user.RoleId = Int32.Parse(Role.PLAYER);
            user.UserLogin = "test";
            user.UserPassword = "1234";

            FM_User fmUser = EntityMapper.MapToDatabase<User, FM_User>(user);

            Assert.IsNotNull(fmUser);
            Assert.AreEqual(user.Id, fmUser.id);
            Assert.AreEqual(user.CreateDate, fmUser.create_date);
            Assert.AreEqual(user.UpdateDate, fmUser.update_date);
            Assert.AreEqual(user.Name, fmUser.name);
            Assert.AreEqual(user.Surname, fmUser.surname);
            Assert.AreEqual(user.Email, fmUser.email);
            Assert.AreEqual(user.RoleId, fmUser.role_id);
            Assert.AreEqual(user.UserLogin, fmUser.user_login);
            Assert.AreEqual(user.UserPassword, fmUser.user_password);
        }

        #endregion

        #region FM_Game and Game
        [Test]
        public void Map_FmGame_to_Game()
        {
            FM_Game fmGame = new FM_Game();
            fmGame.id = 1;
            fmGame.create_date = DateTime.Now;
            fmGame.update_date = DateTime.MaxValue;
            fmGame.name = "Rainbow Six Siege";

            Game game = EntityMapper.MapToModel<Game, FM_Game>(fmGame);

            Assert.IsNotNull(game);
            Assert.AreEqual(fmGame.id, game.Id);
            Assert.AreEqual(fmGame.create_date, game.CreateDate);
            Assert.AreEqual(fmGame.update_date, game.UpdateDate);
            Assert.AreEqual(fmGame.name, game.Name);
        }

        [Test]
        public void Map_Game_to_FmGame()
        {
            Game game = new Game();
            game.Id = 1;
            game.CreateDate = DateTime.Now;
            game.UpdateDate = DateTime.MaxValue;
            game.Name = "Rainbow Six Siege";

            FM_Game fmGame = EntityMapper.MapToDatabase<Game, FM_Game>(game);

            Assert.IsNotNull(game);
            Assert.AreEqual(fmGame.id, game.Id);
            Assert.AreEqual(fmGame.create_date, game.CreateDate);
            Assert.AreEqual(fmGame.update_date, game.UpdateDate);
            Assert.AreEqual(fmGame.name, game.Name);
        }
        #endregion

        #region FM_Game_Session and GameSession
        [Test]
        public void Map_FmGameSession_to_GameSession()
        {
            FM_Game_Session fmGameSession = new FM_Game_Session();
            fmGameSession.id = 1;
            fmGameSession.create_date = DateTime.Now;
            fmGameSession.update_date = DateTime.MaxValue;
            fmGameSession.end_date = DateTime.Now;
            fmGameSession.game_id = 100;
            fmGameSession.session_identifier = new Guid();

            GameSession gameSession = EntityMapper.MapToModel<GameSession, FM_Game_Session>(fmGameSession);

            Assert.IsNotNull(gameSession);
            Assert.AreEqual(gameSession.Id, fmGameSession.id);
            Assert.AreEqual(gameSession.CreateDate, fmGameSession.create_date);
            Assert.AreEqual(gameSession.UpdateDate, fmGameSession.update_date);
            Assert.AreEqual(gameSession.EndDate, fmGameSession.end_date);
            Assert.AreEqual(gameSession.GameId, fmGameSession.game_id);
            Assert.AreEqual(gameSession.SessionIdentifier, fmGameSession.session_identifier);
        }

        [Test]
        public void Map_GameSession_to_FmGameSession()
        {
            GameSession gameSession = new GameSession();
            gameSession.Id = 1;
            gameSession.CreateDate = DateTime.Now;
            gameSession.UpdateDate = DateTime.MaxValue;
            gameSession.EndDate = DateTime.Now;
            gameSession.GameId = 100;
            gameSession.SessionIdentifier = new Guid();

            FM_Game_Session fmGameSession = EntityMapper.MapToDatabase<GameSession, FM_Game_Session>(gameSession);

            Assert.IsNotNull(fmGameSession);

            Assert.AreEqual(gameSession.Id, fmGameSession.id);
            Assert.AreEqual(gameSession.CreateDate, fmGameSession.create_date);
            Assert.AreEqual(gameSession.UpdateDate, fmGameSession.update_date);
            Assert.AreEqual(gameSession.EndDate, fmGameSession.end_date);
            Assert.AreEqual(gameSession.GameId, fmGameSession.game_id);
            Assert.AreEqual(gameSession.SessionIdentifier, fmGameSession.session_identifier);
        }

        #endregion
    }
}
