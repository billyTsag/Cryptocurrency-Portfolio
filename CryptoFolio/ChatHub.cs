using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CryptoFolio.Models;
using Microsoft.AspNet.SignalR;

namespace CryptoFolio
{
    public class ChatHub : Hub
    {
        public void Send(string user, string message)
        {
            Clients.All.addNewMessageToPage(user, message);
        }
    }
}