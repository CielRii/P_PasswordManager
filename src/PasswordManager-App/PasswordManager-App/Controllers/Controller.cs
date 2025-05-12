using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager_App
{
    public class Controller
    {
        // Connexion to main page of MCD model 
        private Model _model;
        private HomePage _home;

        public Controller(Model model, HomePage home)
        {
            _model = model; //Initialization of the model
            _home = home; //Initialization of the main view

            _model.Controller = this;
            _home.Controller = this;
        }
    }
}
