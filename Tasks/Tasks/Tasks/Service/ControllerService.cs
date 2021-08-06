using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Models;

namespace Tasks.Service
{
    public  class ControllerService
    {
        List<Controller> listOfControllers;
        
        public ControllerService()
        {
            
            listOfControllers = new List<Controller>()
            {
                new Controller()
                {
                    
                    DeviceName="A",
                    Email="A@gmail.com",
                    Password="a"
                },
                new Controller()
                {
                    
                    DeviceName="B",
                    Email="B@gmail.com",
                    Password="b"
                },
                new Controller()
                {
                    
                    DeviceName="C",
                    Email="C@gmail.com",
                    Password="c"
                }
            };
        }
        public List<Controller> GetControllersList()
        {
            return listOfControllers;
        }
        public void AddControllerToList(string controllerDeviceName, string controllerEmail,string controllerPassword)
        {
            listOfControllers.Add(new Controller()
            {
                DeviceName = controllerDeviceName,
                Email = controllerEmail,
                Password = controllerPassword

            }) ;
        }
    }
}
