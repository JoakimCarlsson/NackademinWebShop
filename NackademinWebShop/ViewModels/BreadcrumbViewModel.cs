using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace NackademinWebShop.Models
{
    public class BreadcrumbViewModel
    {
        public string Text { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public bool Active { get; set; }
        public int? Id { get; set; }

        public BreadcrumbViewModel() { }

        public BreadcrumbViewModel(string text, string action, string controller, bool active, int id)
        {
            Text = text;
            Action = action;
            Controller = controller;
            Active = active;
            Id = id;
        }
        public BreadcrumbViewModel(string text, string action, string controller, bool active)
        {
            Text = text;
            Action = action;
            Controller = controller;
            Active = active;
        }
    }
}
