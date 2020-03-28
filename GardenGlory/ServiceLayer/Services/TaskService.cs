using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GardenGlory.Context;
using GardenGlory.EfClasses;
using Microsoft.EntityFrameworkCore;


namespace ServiceLayer
{
    public class TaskService
    {
        private GardenGloryContext _context;

        //Get, add, and update
        public TaskService(GardenGloryContext context)
        {
            _context = context;
        }

        public IQueryable<Task> GetTasks()
        {
            return _context.Tasks
                .Include(c => c.EmployeeLink)
                .Include(c => c.ServiceLink);
        }
        public IQueryable<Task> GetTasks(Service service)
        {
            return _context.Tasks
                .Where(c=>c.ServiceId == service.ServiceId)
                .Include(c => c.EmployeeLink)
                .Include(c => c.ServiceLink);
        }

        public IQueryable<Task> GetTasks(Employee employee)
        {
            return _context.Tasks
                .Where(c => c.EmployeeId == employee.EmployeeId)
                .Include(c => c.EmployeeLink)
                .Include(c => c.ServiceLink);
        }
        public void AddTask(Task task)
        {
            using (var context = new GardenGloryContext())
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
            }
        }

        public void UpdateTask(int taskId, DateTime dateConducted, double hourWorked, string taskName)
        {
            var task = _context.Tasks.Find(taskId);

            task.DateConducted = dateConducted;
            task.HoursWorked = hourWorked;
            task.TaskName = taskName;
            _context.SaveChanges();

        }
    }
}