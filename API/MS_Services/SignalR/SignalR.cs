using MS_Data.AppContext;
using MS_Models.Model;
using MS_Models.ViewModel;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.SignalR
{
    public class SignalR : Hub
    {
        private readonly AppDbContext context;
        public SignalR(AppDbContext context)
        {
            this.context = context;
        }

        public async Task GetItems()
        {
            var items = await context.Employees.ToListAsync();
            await Clients.Caller.SendAsync("ReceiveItems", items);
        }

        public async Task CreateItem(Employee item)
        {
            context.Employees.Add(item);
            await context.SaveChangesAsync();
            await Clients.All.SendAsync("ReceiveItem", item);
        }

        public async Task UpdateItem(Employee item)
        {
            context.Employees.Update(item);
            await context.SaveChangesAsync();
            await Clients.All.SendAsync("UpdateItem", item);
        }

        public async Task DeleteItem(int id)
        {
            var item = await context.Employees.FindAsync(id);
            context.Employees.Remove(item!);
            await context.SaveChangesAsync();
            await Clients.All.SendAsync("DeleteItem", id);
        }
    }
}
