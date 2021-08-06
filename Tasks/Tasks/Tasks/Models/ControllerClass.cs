using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Models
{
    public class Controller
    {
        static int id = 0;
        private int _deviceId;

        public Controller()
        {
            _deviceId = id++;
            DeviceName = "ABC";
            Email = "ABC@gmail.com";
            Password = "ABC";
            
        }
        public int DeviceId
        {
            get { return _deviceId; }
            set { _deviceId = value; }
        }

        private string _deviceName;

        public string DeviceName
        {
            get { return _deviceName; }
            set { _deviceName = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }



    }
}
