using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region tightly coupled
            //A a = new A();
            //a.OperatiOnClassB();
            #endregion

            #region Constructors dependency injection
            //User _user1 = new User(new TextLogger());
            //_user1.SaveData("Save and log into text file");
            //_user1.DeleteData("Delete and log into text file");

            //User _user2 = new User(new XMLLogger());
            //_user2.SaveData("Save and log into xml file");
            //_user2.DeleteData("Delete and log into xml file");
            #endregion

            #region Methods dependency injection
            //userVehicle uservehicle = new userVehicle();
            //iVehicle vehicle = new Vehicle();
            //vehicle.Company = "Honda";
            //vehicle.Model = "City";
            //string result = uservehicle.getData(vehicle);
            //Console.WriteLine(result);

            #endregion

            #region property dependency injection
            //UserSubject _usersubject = new UserSubject();
            //_usersubject.iSubjectDisplay = new Subject();
            //_usersubject.ShowData("property dependency inject message");
            #endregion

            Console.ReadKey();
        }


        #region tightly coupled
        public class A
        {
            B b;
            public void OperatiOnClassB()
            {
                b = new B();
                b.Id = 1;
                b.Name = "Atanu";
                string c = Convert.ToString(b.Id) + "" + b.Name;
                Console.WriteLine(c);
            }
        }
        public class B
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        #endregion

        #region Constructors dependency injection
        public interface ILogger
        {
            void LogInfo(string info);
        }
        public class TextLogger : ILogger
        {
            // text file
            public void LogInfo(string info)
            {
                Console.WriteLine(info);
            }
        }
        public class XMLLogger : ILogger
        {
            //xml file
            public void LogInfo(string info)
            {
                Console.WriteLine(info);
            }
        }

        public class User
        {
            ILogger _iLogger;
            public User(ILogger iLogger)
            {
                _iLogger = iLogger;
            }
            public void SaveData(string message)
            {
                _iLogger.LogInfo(message);
            }
            public void DeleteData(string message)
            {
                _iLogger.LogInfo(message);
            }
        }
        #endregion

        #region Methods dependency injection
        public interface iVehicle
        {
            string Company { get; set; }
            string Model { get; set; }
        }
        public class Vehicle : iVehicle
        {
            public string Company { get; set; }
            public string Model { get; set; }
        }

        public class userVehicle
        {
            public string getData(iVehicle vehicle)
            {
                return vehicle.Company + " " + vehicle.Model;
            }
        }
        #endregion

        #region property dependency injection
        public interface iSubject
        {
            void Display(string message);
        }
        public class Subject : iSubject
        {
            public void Display(string message)
            {
                Console.WriteLine(message);
            }
        }

        public class UserSubject
        {
            iSubject _isubject = null;
            public iSubject iSubjectDisplay
            {
                get { return _isubject; }
                set { _isubject = value; }
            }

            public void ShowData(string message)
            {
                _isubject.Display(message);
            }

        }
        #endregion
    }
}
